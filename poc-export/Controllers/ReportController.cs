using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poc_export.Entities;
using poc_export.Persistence;
using System.Runtime.CompilerServices;

using System.IO;
using System.Text;

namespace poc_export.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly ReportDbContext _context;
        public ReportController(ReportDbContext context)
        {
            _context = context;
        }

        [HttpGet("report")]
        public IActionResult GetReport()
        {
            try
            {
                string sql = @"
                 select 
		            'F200' as F200,
		            '02' as F2,
		            descr_obr,
		            Identificador_unid,
		            NumVend_Itv,
		            cpf_pes,
		            CONVERT(VARCHAR(10), Data_Ven, 103) as Data_Ven,
		            REPLACE(FORMAT(ValorTot_Ven, 'C', 'pt-BR'), 'R$', '') AS ValorTot_Ven
                from Obras
                    inner join Vendas on
                        Obra_Ven = cod_obr
                    LEFT JOIN ItensVenda ON
                        Empresa_ven = Empresa_itv AND
                        Obra_Ven = Obra_Itv AND
                        Num_Ven = NumVend_Itv
                    LEFT JOIN Recebidas ON
                        Empresa_ven = Empresa_rec AND
                        Obra_Ven = Obra_Rec AND
                        Num_ven = NumVend_Rec
                    LEFT JOIN PrdSrv ON
                        Produto_Itv = NumProd_psc
                    LEFT JOIN PrdSrvCat ON
                        Produto_Itv = CodProd_cp
                    LEFT JOIN Empresas ON
                        Codigo_emp = Empresa_ven
                    LEFT JOIN Pessoas ON
                        Cliente_Ven = cod_pes
                    LEFT JOIN PesFis ON
                        cod_pf = Cliente_Ven
                    LEFT JOIN VendaDistrato ON
                        Empresa_vdd = Empresa_ven AND
                        Obra_vdd = Obra_Ven AND
                        NumVend_vdd = Num_Ven
                    LEFT JOIN CategoriasDeDistrato ON
                        Codigo_cd = CategDistrato_vdd
                    LEFT JOIN UnidadePer ON  
                        Empresa_ven = UnidadePer.Empresa_unid AND
                        Produto_Itv = UnidadePer.Prod_unid AND
                        CodPerson_Itv = UnidadePer.NumPer_unid
	                    group by cpf_pes, descr_obr, Identificador_unid, NumVend_Itv, Data_Ven, ValorTot_Ven
	                    order by Identificador_unid;
                ";


                FormattableString formattableQuery = FormattableStringFactory.Create(sql);

                var result = _context.Speds.FromSql(formattableQuery).ToList();

                List<Sped> speds = new List<Sped>();

                foreach (var item in result)
                {
                    speds.Add(new Sped
                    {
                        F200 = item.F200,
                        F2 = item.F2,
                        cpf_pes = item.cpf_pes,
                        Data_Ven = item.Data_Ven,
                        descr_obr = item.descr_obr,
                        Identificador_unid = item.Identificador_unid,
                        NumVend_Itv = item.NumVend_Itv,
                        ValorTot_Ven = item.ValorTot_Ven
                    });
                }

                

                StringBuilder spedContentBuilder = new StringBuilder();

                foreach (Sped sped in speds)
                {
                    spedContentBuilder.AppendLine(sped.ToSpedFormat());
                }

                string spedContent = spedContentBuilder.ToString();
                byte[] spedBytes = Encoding.UTF8.GetBytes(spedContent);

                // Retornando o arquivo SPED como resposta
                return File(spedBytes, "text/plain", "speds.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}


namespace poc_export.Entities
{
    public class Sped
    {
        public string F200;
        public string F2;
        public string descr_obr;
        public string Identificador_unid;
        public int NumVend_Itv;
        public string cpf_pes;
        public string Data_Ven;
        public string ValorTot_Ven;

        public string ToSpedFormat()
        {
            return $"{F200.PadRight(20)}" +
                   $"{F2.PadRight(20)}" +
                   $"{descr_obr.PadRight(50)}" +
                   $"{Identificador_unid.PadRight(20)}" +
                   $"{NumVend_Itv.ToString().PadRight(20)}" +
                   $"{cpf_pes.PadRight(20)}" +
                   $"{Data_Ven.PadRight(20)}" +
                   $"{ValorTot_Ven.PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"01".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"0,6500".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"01".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"3,0000".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"##".PadRight(20)}" +
                   $"{"4".PadRight(20)}" +
                   $"{"".PadRight(20)}";
        }

        public static string HeaderLine()
        {
            return $"{"F200".PadRight(20)}" +
                   $"{"F2".PadRight(20)}" +
                   $"{"NOME OBRA".PadRight(50)}" +
                   $"{"QUADRA E LOTE".PadRight(20)}" +
                   $"{"NUMERO VENDA".PadRight(20)}" +
                   $"{"cpf_pes".PadRight(20)}" +
                   $"{"Data_Ven".PadRight(20)}" +
                   $"{"ValorTot_Ven".PadRight(20)}" +
                   $"{"VR.RECE.ANT".PadRight(20)}" +
                   $"{"VLR.TOT.REC".PadRight(20)}" +
                   $"{"COD.SIT.PIS".PadRight(20)}" +
                   $"{"BASE CALC.PIS".PadRight(20)}" +
                   $"{"%PIS".PadRight(20)}" +
                   $"{"VR.PIS".PadRight(20)}" +
                   $"{"COD.SIT.COFINS".PadRight(20)}" +
                   $"{"BASE CALC. COFINS".PadRight(20)}" +
                   $"{"% COFINS".PadRight(20)}" +
                   $"{"VR.COFINS".PadRight(20)}" +
                   $"{"%RECEBIDO".PadRight(20)}" +
                   $"{"X NT".PadRight(20)}" +
                   $"{"COMPLEMENTO".PadRight(20)}";
        }


    }


}

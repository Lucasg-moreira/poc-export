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
            return $"{F200}|{F2}|{F2}|{descr_obr}|{Identificador_unid}|{NumVend_Itv.ToString().PadLeft(6, '0')}|{cpf_pes}|{Data_Ven}|{ValorTot_Ven}|##|##|01|##|0,6500|##|01|##|3,0000|##|##|4||";
        }

        public static string HeaderLine()
        {
            return $"{"F200".PadRight(10)}" +
                   $"{"F2".PadRight(20)}" +
                   $"{"NOME OBRA".PadRight(50)}" +
                   $"{"QUADRA E LOTE".PadRight(15)}" +
                   $"{"NUMERO VENDA".PadRight(6, '0')}" +
                   $"{"cpf_pes".PadRight(11)}" +
                   $"{"Data_Ven".PadRight(8)}" +
                   $"{"ValorTot_Ven".PadRight(15, '0')}" +
                   $"{"VR.RECE.ANT".PadRight(10)}" +
                   $"{"VLR.TOT.REC".PadRight(10)}" +
                   $"{"COD.SIT.PIS".PadRight(10)}" +
                   $"{"BASE CALC.PIS".PadRight(10)}" +
                   $"{"%PIS".PadRight(10)}" +
                   $"{"VR.PIS".PadRight(10)}" +
                   $"{"COD.SIT.COFINS".PadRight(10)}" +
                   $"{"BASE CALC. COFINS".PadRight(10)}" +
                   $"{"% COFINS".PadRight(10)}" +
                   $"{"VR.COFINS".PadRight(10)}" +
                   $"{"%RECEBIDO".PadRight(10)}" +
                   $"{"X NT".PadRight(10)}" +
                   $"{"COMPLEMENTO".PadRight(10)}";
        }


    }


}

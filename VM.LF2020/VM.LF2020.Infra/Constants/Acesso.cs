namespace VM.LF2020.Infra.Constants
{
    public static class Acesso
    {
        public static string DataBase(string dataBase)
        {
            var str = "";
            switch (dataBase)
            {
                case "LF":
                    str = @"Data Source=NOTE-VERONE\SQLEXPRESS;Initial Catalog=LF;Integrated Security=True";
                    break;
                case "X":
                    str = "X";
                    break;
                default:
                    break;
            }

            return str;
        }
    }
}

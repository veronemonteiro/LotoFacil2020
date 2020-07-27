using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VM.LF2020.Infra.Constants;
using VM.LF2020.Model;
using VM.LF2020.Model.Utils;

namespace VM.LF2020.Infra.Repository.Views
{
    public class PossiveisView
    {
        public List<Jogo> RetornarTodos()
        {
            try
            {
                var queryStr = "SELECT * FROM POSSIVEIS;";

                var listaPossiveis = Retornar(queryStr);

                return listaPossiveis;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<Jogo> Retornar(string query)
        {
            List<Jogo> lista = new List<Jogo>();

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                SqlCommand comando = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(LFConverter.EmJogo(reader));
                }
                reader.Close();

                return lista;
            }
        }

        private Jogo ConverteJogo(SqlDataReader reader)
        {
            return new Jogo
            {
                Id = Convert.ToInt32(reader[0]),
                N1 = Convert.ToInt32(reader[1]),
                N2 = Convert.ToInt32(reader[2]),
                N3 = Convert.ToInt32(reader[3]),
                N4 = Convert.ToInt32(reader[4]),
                N5 = Convert.ToInt32(reader[5]),
                N6 = Convert.ToInt32(reader[6]),
                N7 = Convert.ToInt32(reader[7]),
                N8 = Convert.ToInt32(reader[8]),
                N9 = Convert.ToInt32(reader[9]),
                N10 = Convert.ToInt32(reader[10]),
                N11 = Convert.ToInt32(reader[11]),
                N12 = Convert.ToInt32(reader[12]),
                N13 = Convert.ToInt32(reader[13]),
                N14 = Convert.ToInt32(reader[14]),
                N15 = Convert.ToInt32(reader[15]),
                Texto = reader[16].ToString()
            };
        }

    }
}

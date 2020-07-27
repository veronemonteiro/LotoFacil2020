using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VM.LF2020.Infra.Constants;
using VM.LF2020.Model;
using VM.LF2020.Model.Utils;

namespace VM.LF2020.Infra.Repository.Table
{
    public class PossiveisRepository
    {
        public JogoCompleto Retornar(int jogo)
        {
            var query = "SELECT P.JOGO, P.B1, P.B2, P.B3, P.B4, P.B5, P.B6, P.B7, P.B8, P.B9, P.B10, P.B11, P.B12, P.B13, " +
                                "P.B14, P.B15, 0 as QTD_ANTERIOR, P.PAR, P.IMPAR, P.CIMA, P.MEIO, P.BAIXO, P.NR_SEQ " +
                                "FROM TBPOSSIVEIS P WHERE P.JOGO = @jogo";

            JogoCompleto retorno = new JogoCompleto();

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.Add("@jogo", System.Data.SqlDbType.Int).Value = jogo;

                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    retorno = LFConverter.EmJogoCompleto(reader);
                }
                reader.Close();

                return retorno;
            }
        }

        public Jogo Retornar(Numeros numeros)
        {
            var query = "SELECT JOGO, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, SORTEIOS " +
                        "FROM TBPOSSIVEIS WHERE B1 = @B1 AND B2 = @B2 AND B3 = @B3 AND B4 = @B4 AND B5 = @B5 AND " +
                        "B6 = @B6 AND B7 = @B7 AND B8 = @B8 AND B9 = @B9 AND B10 = @B10 AND B11 = @B11 AND " +
                        "B12 = @B12 AND B13 = @B13 AND B14 = @B14 AND B15 = @B15;";

            var lista = LFConverter.ListaDeNumeros(numeros);

            List<Jogo> listaRet = new List<Jogo>();

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                var x = 0;
                SqlCommand comando = new SqlCommand(query, con);
                foreach (var i in lista)
                {
                    x++;
                    comando.Parameters.Add("@B" + x, System.Data.SqlDbType.Int).Value = i;
                }
                
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaRet.Add(LFConverter.EmJogo(reader));
                }
                reader.Close();

                return listaRet[0];
            }
        }

        public bool Atualizar(Jogo jogo)
        {
            var query = "UPDATE TBPOSSIVEIS SET SORTEIOS = @Sorteio, SITUACAO = 0 WHERE JOGO = @Jogo;";

            var lista = LFConverter.ListaDeNumeros(jogo);

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.Add("@Sorteio", System.Data.SqlDbType.VarChar, 50).Value = jogo.Texto;
                comando.Parameters.Add("@Jogo", System.Data.SqlDbType.Int).Value = jogo.Id;

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

    }
}

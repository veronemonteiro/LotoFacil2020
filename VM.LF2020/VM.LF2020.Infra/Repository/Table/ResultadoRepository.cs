using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VM.LF2020.Infra.Constants;
using VM.LF2020.Model;
using VM.LF2020.Model.Utils;

namespace VM.LF2020.Infra.Repository.Table
{
    public class ResultadosRepository
    {
        public Jogo Retornar(int concurso)
        {
            try
            {
                var queryStr = "SELECT R.CONCURSO, R.B1, R.B2, R.B3, R.B4, R.B5, R.B6, R.B7, " +
                                       "R.B8, R.B9, R.B10, R.B11, R.B12, R.B13, R.B14, R.B15, '' as Texto " +
                                "FROM TBRESULTADOS R " +
                                "WHERE R.CONCURSO = " + concurso +"; ";

                var retorno = Retornar(queryStr);

                return retorno[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Jogo RetornarUltimo()
        {
            try
            {
                var queryStr = "SELECT R.CONCURSO, R.B1, R.B2, R.B3, R.B4, R.B5, R.B6, R.B7, " +
                                       "R.B8, R.B9, R.B10, R.B11, R.B12, R.B13, R.B14, R.B15, '' as Texto " + 
                                "FROM TBRESULTADOS R " +
                                "WHERE R.CONCURSO IN(select max(CONCURSO) from TBRESULTADOS); ";

                var retorno = Retornar(queryStr);

                return retorno[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Jogo> RetornarTodos()
        {
            try
            {
                var queryStr = "SELECT R.CONCURSO, R.B1, R.B2, R.B3, R.B4, R.B5, R.B6, R.B7, " +
                                       "R.B8, R.B9, R.B10, R.B11, R.B12, R.B13, R.B14, R.B15, '' as Texto " +
                                "FROM TBRESULTADOS R; ";

                var retorno = Retornar(queryStr);

                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<JogoCompleto> RetornarTodosCompleto()
        {
            try
            {
                var queryStr = "SELECT R.CONCURSO, R.B1, R.B2, R.B3, R.B4, R.B5, R.B6, R.B7, R.B8, R.B9, R.B10, R.B11, R.B12, " +
                               "R.B13, R.B14, R.B15, R.QTD_ANTERIOR, R.PAR, R.IMPAR, R.CIMA, R.MEIO, R.BAIXO, R.SEQ " +
                               "FROM TBRESULTADOS R; ";

                var retorno = RetornarCompleto(queryStr);

                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Incluir(JogoCompleto jogo)
        {
            var query = "INSERT INTO TBRESULTADOS (CONCURSO, DATA_SORTEIO, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, QTD_ANTERIOR, PAR, IMPAR, CIMA, MEIO, BAIXO, SEQ) " +
                           "VALUES (@Concurso, @Data, @B1, @B2, @B3, @B4, @B5, @B6, @B7, @B8, @B9, @B10, @B11, @B12, @B13, @B14, @B15, @QtdAnterior, @Par, @Impar, @Cima, @Meio, @Baixo, @Seq);";

            var lista = LFConverter.ListaDeNumeros(jogo);

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                var x = 0;

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.Add("@Concurso", System.Data.SqlDbType.Int).Value = jogo.Concurso;
                comando.Parameters.Add("@Data", System.Data.SqlDbType.VarChar, 10).Value = jogo.DataSorteio;
                foreach (var i in lista)
                {
                    x++;
                    comando.Parameters.Add("@B" + x, System.Data.SqlDbType.Int).Value = i;
                }
                comando.Parameters.Add("@QtdAnterior", System.Data.SqlDbType.Int).Value = jogo.QtdAnterior;
                comando.Parameters.Add("@Par", System.Data.SqlDbType.Int).Value = jogo.Par;
                comando.Parameters.Add("@Impar", System.Data.SqlDbType.Int).Value = jogo.Impar;
                comando.Parameters.Add("@Cima", System.Data.SqlDbType.Int).Value = jogo.Cima;
                comando.Parameters.Add("@Meio", System.Data.SqlDbType.Int).Value = jogo.Meio;
                comando.Parameters.Add("@Baixo", System.Data.SqlDbType.Int).Value = jogo.Baixo;
                comando.Parameters.Add("@Seq", System.Data.SqlDbType.Int).Value = jogo.Sequencia;

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            return true;
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

        private List<JogoCompleto> RetornarCompleto(string query)
        {
            List<JogoCompleto> lista = new List<JogoCompleto>();

            using (SqlConnection con = new SqlConnection(Acesso.DataBase("LF")))
            {
                SqlCommand comando = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(LFConverter.EmJogoCompleto(reader));
                }
                reader.Close();

                return lista;
            }
        }
    }
}

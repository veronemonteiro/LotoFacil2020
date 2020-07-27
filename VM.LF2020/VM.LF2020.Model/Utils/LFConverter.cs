using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VM.LF2020.Model.Utils
{
    public static class LFConverter
    {
        public static Jogo EmJogo(SqlDataReader reader)
        {
            var newJogo = new Jogo
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

            if(string.IsNullOrEmpty(newJogo.Texto))
            {
                newJogo.Texto = "#" + newJogo.N1 + "#" + newJogo.N2 + "#" + newJogo.N3 + 
                                "#" + newJogo.N4 + "#" + newJogo.N5 + "#" + newJogo.N6 + 
                                "#" + newJogo.N7 + "#" + newJogo.N8 + "#" + newJogo.N9 + 
                                "#" + newJogo.N10 + "#" + newJogo.N11 + "#" + newJogo.N12 + 
                                "#" + newJogo.N13 + "#" + newJogo.N14 + "#" + newJogo.N15 + "#";
            }
            
            return newJogo;
        }

        public static JogoCompleto EmJogoCompleto(SqlDataReader reader)
        {
            var jogoC = new JogoCompleto
            {
                Concurso = Convert.ToInt32(reader[0]),
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
                QtdAnterior = Convert.ToInt32(reader[16]),
                Par = Convert.ToInt32(reader[17]),
                Impar = Convert.ToInt32(reader[18]),
                Cima = Convert.ToInt32(reader[19]),
                Meio = Convert.ToInt32(reader[20]),
                Baixo = Convert.ToInt32(reader[21]),
                Sequencia = Convert.ToInt32(reader[22])
            };

            jogoC.Texto = "#" + jogoC.N1 + "#" + jogoC.N2 + "#" + jogoC.N3 +
                          "#" + jogoC.N4 + "#" + jogoC.N5 + "#" + jogoC.N6 +
                          "#" + jogoC.N7 + "#" + jogoC.N8 + "#" + jogoC.N9 +
                          "#" + jogoC.N10 + "#" + jogoC.N11 + "#" + jogoC.N12 +
                          "#" + jogoC.N13 + "#" + jogoC.N14 + "#" + jogoC.N15 + "#";

            return jogoC;
        }

        public static List<int> ListaDeNumeros(Numeros nums)
        {
            List<int> listaInt = new List<int>();
            listaInt.Add(nums.N1);
            listaInt.Add(nums.N2);
            listaInt.Add(nums.N3);
            listaInt.Add(nums.N4);
            listaInt.Add(nums.N5);
            listaInt.Add(nums.N6);
            listaInt.Add(nums.N7);
            listaInt.Add(nums.N8);
            listaInt.Add(nums.N9);
            listaInt.Add(nums.N10);
            listaInt.Add(nums.N11);
            listaInt.Add(nums.N12);
            listaInt.Add(nums.N13);
            listaInt.Add(nums.N14);
            listaInt.Add(nums.N15);

            return listaInt;
        }
    }
}

using System;
using System.Collections.Generic;
using VM.LF2020.Model;

namespace VM.LF2020.Core.Util
{
    public static class Manipular
    {
        public static List<string> QuebraString(string texto_, char separador_)
        {
            var retorno = new List<string>();
            var str = "";

            foreach (var item in texto_)
            {
                if (item == separador_)
                {
                    retorno.Add(str);
                    str = "";
                }
                else
                    str += item;
            }

            return retorno;
        }

        public static string Soma2NumString(string sNum)
        {
            var retorno = "";
            var n1 = Convert.ToInt32(sNum[0].ToString());
            var n2 = Convert.ToInt32(sNum[1].ToString());

            retorno = (n1 + n2).ToString();

            return retorno;
        }

        public static string TransFormaJogoString(Jogo j)
        {
            var retorno = "";

            retorno += j.Id + "#" + j.N1 + "#" + j.N2 + "#" + j.N3 + "#" + j.N4 + "#" + j.N5
                     + "#" + j.N6 + "#" + j.N7 + "#" + j.N8 + "#" + j.N9 + "#" + j.N10
                     + "#" + j.N11 + "#" + j.N12 + "#" + j.N13 + "#" + j.N14 + "#" + j.N15 + "#";

            return retorno;
        }

        public static string MontaJogoString(Jogo j)
        {
            var retorno = "";

            retorno += j.Id + ";" + j.N1 + ";" + j.N2 + ";" + j.N3 + ";" + j.N4 + ";" + j.N5
                     + ";" + j.N6 + ";" + j.N7 + ";" + j.N8 + ";" + j.N9 + ";" + j.N10
                     + ";" + j.N11 + ";" + j.N12 + ";" + j.N13 + ";" + j.N14 + ";" + j.N15;

            return retorno;
        }
    }
}

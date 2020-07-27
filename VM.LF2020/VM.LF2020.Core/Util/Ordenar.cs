using System;
using System.Collections.Generic;

namespace VM.LF2020.Core.Util
{
    public static class Ordenar
    {
        public static List<int> ListaDeInteiros(List<int> lista_)
        {
            for (int i = 0; i < lista_.Count - 1; i++)
            {
                for (int n = i + 1; n < lista_.Count; n++)
                {
                    if (lista_[n] < lista_[i])
                    {
                        var tmpN = lista_[i];
                        lista_[i] = lista_[n];
                        lista_[n] = tmpN;
                    }
                }
            }

            return lista_;
        }

        public static List<string> ListaDeStringComNumeros(List<string> lista_)
        {
            for (int i = 0; i < lista_.Count - 1; i++)
            {
                for (int n = i + 1; n < lista_.Count; n++)
                {
                    if (Convert.ToInt32(lista_[n]) < Convert.ToInt32(lista_[i]))
                    {
                        var tmpN = lista_[i];
                        lista_[i] = lista_[n];
                        lista_[n] = tmpN;
                    }
                }
            }

            return lista_;
        }

    }
}

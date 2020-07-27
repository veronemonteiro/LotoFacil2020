using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM.LF2020.Domain.Resultado;
using VM.LF2020.Model;

namespace VM.FL2020.Testes
{
    [TestClass]
    public class TestesAdicionarResultados
    {
        private Resultados res;

        [TestMethod]
        public void TestesAdicionaResultado()
        {
            res = new Resultados();

            res.IncluirResultado(new JogoCompleto
            {
                Concurso = 1994,
                DataSorteio = "17/07/2020",
                N1 = 3,
                N2 = 4,
                N3 = 5,
                N4 = 6,
                N5 = 7,
                N6 = 8,
                N7 = 9,
                N8 = 11,
                N9 = 12,
                N10 = 17,
                N11 = 19,
                N12 = 20,
                N13 = 22,
                N14 = 24,
                N15 = 25
            });

        }


    }
}

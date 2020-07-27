using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM.LF2020.Domain.Levantamento;

namespace VM.FL2020.Testes
{
    [TestClass]
    public class TestesJogosPossiveis
    {
        private JogosPossiveis poss;
        
        [TestMethod]
        public void TestesGerarJogosPossiveis()
        {
            if (poss == null)
                poss = new JogosPossiveis();

            List<int> obrigatorios = new List<int>();
            obrigatorios.Add(4);
            obrigatorios.Add(10);
            obrigatorios.Add(13);
            obrigatorios.Add(23);

            List<int> excluidos = new List<int>();
            excluidos.Add(1);
            excluidos.Add(6);
            excluidos.Add(7);
            excluidos.Add(16);

            poss.GerarJogosProvaveis(obrigatorios, excluidos, @"C:\Projetos\Softwares\VM.LF2020\Testes", "JogosFinal.csv");
        }

        [TestMethod]
        public void TestesLevantamentos()
        {
            Levantamentos levantamentos = new Levantamentos();

            levantamentos.RealizarLevantamentos(@"C:\Projetos\Softwares\VM.LF2020\Testes", "Analises_");
        }

    }
}

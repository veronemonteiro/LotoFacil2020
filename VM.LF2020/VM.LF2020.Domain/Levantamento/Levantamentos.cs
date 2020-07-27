using System;
using System.Collections.Generic;
using System.Text;
using VM.LF2020.Model;
using VM.LF2020.Domain.Resultado;
using VM.LF2020.Model.Utils;
using VM.LF2020.Core.ManipulaArquivo;
using System.Linq;

namespace VM.LF2020.Domain.Levantamento
{
    public class Levantamentos
    {
        private static List<JogoCompleto> listaLevatamentos = new List<JogoCompleto>();
        private static List<int> listaNumerosGeral = new List<int>();
        private static List<int> listaNumerosTop100 = new List<int>();
        private static List<int> listaNumerosTop10 = new List<int>();
        private static List<int> listaQtdAntesGeral = new List<int>();
        private static List<int> listaQtdAntesTop100 = new List<int>();
        private static List<int> listaQtdAntesTop10 = new List<int>();
        private static List<int> listaImparGeral = new List<int>();
        private static List<int> listaImparTop100 = new List<int>();
        private static List<int> listaImparTop10 = new List<int>();
        private static List<int> listaCimaGeral = new List<int>();
        private static List<int> listaCimaTop100 = new List<int>();
        private static List<int> listaCimaTop10 = new List<int>();
        private static List<int> listaMeioGeral = new List<int>();
        private static List<int> listaMeioTop100 = new List<int>();
        private static List<int> listaMeioTop10 = new List<int>();
        private static List<int> listaBaixoGeral = new List<int>();
        private static List<int> listaBaixoTop100 = new List<int>();
        private static List<int> listaBaixoTop10 = new List<int>();
        private static List<int> listaSeqGeral = new List<int>();
        private static List<int> listaSeqTop100 = new List<int>();
        private static List<int> listaSeqTop10 = new List<int>();
        private List<Analise> listaImprime;

        Resultados resultados;

        public Levantamentos()
        {
            resultados = new Resultados();
            listaLevatamentos = resultados.ListarResultadosCompletos();

            for (int i = 0; i < 25; i++)
            {
                listaNumerosGeral.Add(0);
                listaNumerosTop100.Add(0);
                listaNumerosTop10.Add(0);
            }

            for (int i = 0; i < 15; i++)
            {
                listaQtdAntesGeral.Add(0);
                listaQtdAntesTop100.Add(0);
                listaQtdAntesTop10.Add(0);
                listaSeqGeral.Add(0);
                listaSeqTop100.Add(0);
                listaSeqTop10.Add(0);
            }

            for (int i = 0; i < 13; i++)
            {
                listaImparGeral.Add(0);
                listaImparTop100.Add(0);
                listaImparTop10.Add(0);
            }

            for (int i = 0; i < 10; i++)
            {
                listaCimaGeral.Add(0);
                listaCimaTop100.Add(0);
                listaCimaTop10.Add(0);
                listaBaixoGeral.Add(0);
                listaBaixoTop100.Add(0);
                listaBaixoTop10.Add(0);
            }

            for (int i = 0; i < 5; i++)
            {
                listaMeioGeral.Add(0);
                listaMeioTop100.Add(0);
                listaMeioTop10.Add(0);
            }
        }

        public void RealizarLevantamentos(string caminhoGeracao, string nomeArquivo)
        {
            foreach (var jogo in listaLevatamentos)
            {
                var listaJ = LFConverter.ListaDeNumeros(jogo);
                for (int i = 0; i < listaJ.Count; i++)
                {
                    listaNumerosGeral[listaJ[i] - 1]++;

                    if (jogo.Id >= listaLevatamentos.Count - 100)
                    {
                        listaNumerosTop100[listaJ[i] - 1]++;

                        if (jogo.Id >= listaLevatamentos.Count - 10)
                            listaNumerosTop10[listaJ[i] - 1]++;
                    }
                }

                if (jogo.Id > 1)
                    listaQtdAntesGeral[jogo.QtdAnterior - 1]++;
                listaSeqGeral[jogo.Sequencia - 1]++;
                listaImparGeral[jogo.Impar - 1]++;
                if (jogo.Cima > 0)
                    listaCimaGeral[jogo.Cima - 1]++;
                if (jogo.Meio > 0)
                    listaMeioGeral[jogo.Meio - 1]++;
                if (jogo.Baixo > 0)
                    listaBaixoGeral[jogo.Baixo - 1]++;


                if (jogo.Id >= listaLevatamentos.Count - 100)
                {
                    listaQtdAntesTop100[jogo.QtdAnterior - 1]++;
                    listaSeqTop100[jogo.Sequencia - 1]++;
                    listaImparTop100[jogo.Impar - 1]++;
                    if (jogo.Cima > 0)
                        listaCimaTop100[jogo.Cima - 1]++;
                    if (jogo.Meio > 0)
                        listaMeioTop100[jogo.Meio - 1]++;
                    if (jogo.Baixo > 0)
                        listaBaixoTop100[jogo.Baixo - 1]++;

                    if (jogo.Id >= listaLevatamentos.Count - 10)
                    {
                        listaQtdAntesTop10[jogo.QtdAnterior - 1]++;
                        listaSeqTop10[jogo.Sequencia - 1]++;
                        listaImparTop10[jogo.Impar - 1]++;
                        if (jogo.Cima > 0)
                            listaCimaTop10[jogo.Cima - 1]++;
                        if (jogo.Meio > 0)
                            listaMeioTop10[jogo.Meio - 1]++;
                        if (jogo.Baixo > 0)
                            listaBaixoTop10[jogo.Baixo - 1]++;
                    }
                }
            }

            listaImprime = ConverteOrdena(listaNumerosGeral);
            Imprime(caminhoGeracao, nomeArquivo + "Numeros", "Numeros Geral");

            listaImprime = ConverteOrdena(listaNumerosTop100);
            Imprime(caminhoGeracao, nomeArquivo + "Numeros", "Numeros Top 100");

            listaImprime = ConverteOrdena(listaNumerosTop10);
            Imprime(caminhoGeracao, nomeArquivo + "Numeros", "Numeros Top 10");

            listaImprime = ConverteOrdena(listaSeqGeral);
            Imprime(caminhoGeracao, nomeArquivo + "SEQ", "SEQ Geral");

            listaImprime = ConverteOrdena(listaSeqTop100);
            Imprime(caminhoGeracao, nomeArquivo + "SEQ", "SEQ Top 100");

            listaImprime = ConverteOrdena(listaSeqTop10);
            Imprime(caminhoGeracao, nomeArquivo + "SEQ", "SEQ Top 10");

            listaImprime = ConverteOrdena(listaQtdAntesGeral);
            Imprime(caminhoGeracao, nomeArquivo + "QTDAnterior", "QTDAnterior Geral");

            listaImprime = ConverteOrdena(listaQtdAntesTop100);
            Imprime(caminhoGeracao, nomeArquivo + "QTDAnterior", "QTDAnterior Top 100");

            listaImprime = ConverteOrdena(listaQtdAntesTop10);
            Imprime(caminhoGeracao, nomeArquivo + "QTDAnterior", "QTDAnterior Top 10");

            listaImprime = ConverteOrdena(listaCimaGeral);
            Imprime(caminhoGeracao, nomeArquivo + "Cima", "Cima Geral");

            listaImprime = ConverteOrdena(listaCimaTop100);
            Imprime(caminhoGeracao, nomeArquivo + "Cima", "Cima Top 100");

            listaImprime = ConverteOrdena(listaCimaTop10);
            Imprime(caminhoGeracao, nomeArquivo + "Cima", "Cima Top 10");

            listaImprime = ConverteOrdena(listaMeioGeral);
            Imprime(caminhoGeracao, nomeArquivo + "Meio", "Meio Geral");

            listaImprime = ConverteOrdena(listaMeioTop100);
            Imprime(caminhoGeracao, nomeArquivo + "Meio", "Meio Top 100");

            listaImprime = ConverteOrdena(listaMeioTop10);
            Imprime(caminhoGeracao, nomeArquivo + "Meio", "Meio Top 10");

            listaImprime = ConverteOrdena(listaBaixoGeral);
            Imprime(caminhoGeracao, nomeArquivo + "Baixo", "Baixo Geral");

            listaImprime = ConverteOrdena(listaBaixoTop100);
            Imprime(caminhoGeracao, nomeArquivo + "Baixo", "Baixo Top 100");

            listaImprime = ConverteOrdena(listaBaixoTop10);
            Imprime(caminhoGeracao, nomeArquivo + "Baixo", "Baixo Top 10");

            listaImprime = ConverteOrdena(listaImparGeral);
            Imprime(caminhoGeracao, nomeArquivo + "Impar", "Impar Geral");

            listaImprime = ConverteOrdena(listaImparTop100);
            Imprime(caminhoGeracao, nomeArquivo + "Impar", "Impar Top 100");

            listaImprime = ConverteOrdena(listaImparTop10);
            Imprime(caminhoGeracao, nomeArquivo + "Impar", "Impar Top 10");
        }

        private List<Analise> ConverteOrdena(List<int> lista)
        {
            List<Analise> lTemp = new List<Analise>();

            for (int i = 0; i < lista.Count; i++)
                lTemp.Add(new Analise { Num = i + 1, Total = lista[i] });

            return lTemp.OrderByDescending(x => x.Total).ToList();
        }

        private void Imprime (string caminho, string arquivo, string quebra)
        {
            var val = new Validacoes();
            Arquivo.Escrever(caminho, arquivo + ".csv", quebra, val);

            foreach (var item in listaImprime)
            {
                var texto = item.Num.ToString() + ";" + item.Total.ToString();
                Arquivo.Escrever(caminho, arquivo + ".csv", texto, val);
            }

            Arquivo.Escrever(caminho, arquivo + ".csv", "", val);
            Arquivo.Escrever(caminho, arquivo + ".csv", "", val);
        }



    }
}

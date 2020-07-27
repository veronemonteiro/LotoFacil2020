using System;
using System.Collections.Generic;
using VM.LF2020.Core.ManipulaArquivo;
using VM.LF2020.Core.Util;
using VM.LF2020.Infra.Repository.Table;
using VM.LF2020.Infra.Repository.Views;
using VM.LF2020.Model;
using VM.LF2020.Model.Utils;

namespace VM.LF2020.Domain.Levantamento
{
    public sealed class JogosPossiveis
    {
        private Jogo ultimoJogo;
        private List<Jogo> listaPossiveis;
        private ResultadosRepository resultados;
        private PossiveisView possiveis;

        public JogosPossiveis()
        {
            resultados = new ResultadosRepository();
            possiveis = new PossiveisView();

            ultimoJogo = resultados.RetornarUltimo();
            listaPossiveis = possiveis.RetornarTodos();
        }

        public void GerarJogosProvaveis(List<int> obrigatorios, List<int> excluidos, string caminhoGeracao, string nomeArquivo)
        {
            List<Jogo> listaProvaveis = new List<Jogo>();

            try
            {
                var listaNumeros = LFConverter.ListaDeNumeros(ultimoJogo);

                foreach (var p in listaPossiveis)
                {
                    var cont = 0;

                    foreach (var n in listaNumeros)
                    {
                        if (p.Texto.Contains("#" + n + "#"))
                            cont++;
                    }

                    if (cont >= 7 && cont <= 11)
                    {
                        cont = 0;

                        foreach (var n in excluidos)
                        {
                            if (p.Texto.Contains("#" + n + "#"))
                            {
                                cont++;
                                break;
                            }
                        }

                        if (cont > 0)
                            continue;

                        foreach (var n in obrigatorios)
                        {
                            if (p.Texto.Contains("#" + n + "#"))
                                cont++;
                        }

                        if (cont != obrigatorios.Count)
                            continue;
                        else
                        {
                            var repPoss = new PossiveisRepository();
                            var poss = repPoss.Retornar(p.Id);

                            if ((poss.Sequencia >= 3 && poss.Sequencia <= 7) &&
                                (poss.Impar >= 6 && poss.Impar <= 9) &&
                                (poss.Cima >= 4 && poss.Cima <= 8) &&
                                (poss.Meio >= 2 && poss.Meio <= 4) &&
                                (poss.Baixo >= 4 && poss.Baixo <= 7))
                                listaProvaveis.Add(p);
                        }
                    }
                }

                if (listaProvaveis.Count > 0)
                {
                    var val = new Validacoes();
                    var nr = 0;

                    foreach (var item in listaProvaveis)
                    {
                        var texto = Manipular.MontaJogoString(item);
                        nr++;

                        Arquivo.Escrever(caminhoGeracao, nomeArquivo, nr + ";" + texto, val);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }
               

    }
}

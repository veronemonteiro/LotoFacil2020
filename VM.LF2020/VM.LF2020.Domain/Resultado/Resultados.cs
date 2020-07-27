using System;
using System.Collections.Generic;
using System.Text;
using VM.LF2020.Infra.Repository.Table;
using VM.LF2020.Model;
using VM.LF2020.Model.Utils;

namespace VM.LF2020.Domain.Resultado
{
    public class Resultados
    {
        private ResultadosRepository resultados;
        private PossiveisRepository possiveis;
        private JogoCompleto jogo;

        public Resultados()
        {
            resultados = new ResultadosRepository();
            possiveis = new PossiveisRepository();
        }

        public Jogo UltimoResultado()
        {
            try
            {
                return resultados.RetornarUltimo();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        public List<Jogo> ListarResultados()
        {
            try
            {
                return resultados.RetornarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        public List<JogoCompleto> ListarResultadosCompletos()
        {
            try
            {
                return resultados.RetornarTodosCompleto();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        public void IncluirResultado(JogoCompleto _jogo)
        {
            try
            {
                jogo = _jogo;

                if (CalcularDadosJogo())
                    resultados.Incluir(jogo);

                var ultimo = UltimoResultado();
                var poss = BuscaPossivel(ultimo);
                poss.Texto = string.IsNullOrEmpty(poss.Texto) || poss.Texto == " " ? ultimo.Id.ToString() : poss.Texto + ", " + ultimo.Id.ToString();

                AtualizaPossivel(poss);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        public Jogo BuscaPossivel(Numeros numeros)
        {
            try
            {
                return possiveis.Retornar(numeros);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        public bool AtualizaPossivel(Model.Jogo jogo)
        {
            try
            {
                return possiveis.Atualizar(jogo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }

        private bool CalcularDadosJogo()
        {
            var anterior = resultados.Retornar(jogo.Concurso - 1);
            var listaN = LFConverter.ListaDeNumeros(jogo);
            var seq = 0;
            var retorno = true;

            for (int i = 0; i < listaN.Count; i++)
            {
                if (listaN[i] < 1 || listaN[i] > 25)
                {
                    retorno = false;
                    break;
                }

                if (listaN[i] % 2 == 0)
                    jogo.Par++;
                else
                    jogo.Impar++;

                if (i > 0 && (listaN[i - 1] + 1) == listaN[i])
                    seq++;
                else
                    seq = 0;

                if (seq > jogo.Sequencia)
                    jogo.Sequencia = seq;

                if (listaN[i] >= 1 && listaN[i] <= 10)
                    jogo.Cima++;
                else if (listaN[i] >= 11 && listaN[i] <= 15)
                    jogo.Meio++;
                else if (listaN[i] >= 16)
                    jogo.Baixo++;
            }

            if (jogo.Sequencia > 0)
                jogo.Sequencia++;

            jogo.QtdAnterior = CalculaRepetidosJogoAnterior(jogo, anterior);

            return retorno;
        }

        private int CalculaRepetidosJogoAnterior(Numeros atual, Numeros anterior)
        {
            try
            {
                var NumsAtual = LFConverter.ListaDeNumeros(atual);
                var NumsAnterior = LFConverter.ListaDeNumeros(anterior);

                var qtd = 0;

                foreach (var n in NumsAtual)
                {
                    foreach (var a in NumsAnterior)
                    {
                        if (n == a)
                        {
                            qtd++;
                            break;
                        }
                    }
                }

                return qtd;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ocorrido: " + ex.Message);
            }
        }
    }
}

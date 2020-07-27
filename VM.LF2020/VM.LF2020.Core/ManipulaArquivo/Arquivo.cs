using System;
using System.Collections.Generic;
using System.IO;

namespace VM.LF2020.Core.ManipulaArquivo
{
    public static class Arquivo
    {
        public static bool Existe(string caminho, string arquivo, Validacoes val)
        {
            var caminhoEarquivo = caminho + @"\" + arquivo;

            try
            {
                if (File.Exists(caminhoEarquivo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                val.adicionarProblemas("Ocorreu um erro ao verificar a existencia do arquivo (" + caminhoEarquivo + "). " + ex.Message);
                return false;
            }
        }

        public static bool Criar(string caminho, string arquivo, string texto, Validacoes val)
        {
            try
            {
                var strPathFile = caminho + @"\" + arquivo;

                using (FileStream fs = File.Create(strPathFile))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(texto);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                val.adicionarProblemas("Ocorreu um erro ao criar o arquivo " + arquivo + ". " + ex.Message);
                return false;
            }
        }

        public static void Apagar()
        {

        }

        public static bool Escreve(string caminho, string arquivo, string texto, Validacoes val)
        {
            try
            {
                var strPathFile = caminho + @"\" + arquivo;

                if (File.Exists(strPathFile))
                {
                    using (StreamWriter sw = File.AppendText(strPathFile))
                    {
                        sw.Write("\r\n" + texto);
                    }
                }
                else
                {
                    val.adicionarProblemas("Arquivo não encontrado " + caminho + arquivo);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                val.adicionarProblemas("Ocorreu um erro ao escrever no arquivo " + arquivo + ". " + ex.Message);
                return false;
            }
        }

        public static string Ler(string caminho, string arquivo, Validacoes val)
        {
            try
            {
                var retorno = "";
                var strPathFile = caminho + @"\" + arquivo;

                if (File.Exists(strPathFile))
                {
                    using (StreamReader sr = new StreamReader(strPathFile))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            retorno += linha;
                        }
                    }
                }
                else
                {
                    val.adicionarProblemas("Arquivo não encontrado " + caminho + arquivo);
                    return "";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                val.adicionarProblemas("Ocorreu um erro ao ler o arquivo " + arquivo + ". " + ex.Message);
                return "";
            }
        }

        public static List<string> LerParaLista(string caminho, string arquivo, Validacoes val)
        {
            try
            {
                var retorno = new List<string>();
                var strPathFile = caminho + @"\" + arquivo;

                if (File.Exists(strPathFile))
                {
                    using (StreamReader sr = new StreamReader(strPathFile))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            retorno.Add(linha);
                        }
                    }
                }
                else
                {
                    val.adicionarProblemas("Arquivo não encontrado " + caminho + arquivo);
                    return null;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                val.adicionarProblemas("Ocorreu um erro ao ler o arquivo " + arquivo + ". " + ex.Message);
                return null;
            }
        }

        public static bool Escrever(string caminho, string arquivo, string texto, Validacoes val)
        {
            try
            {
                if (!Existe(caminho, arquivo, val))
                    return Criar(caminho, arquivo, texto, val);
                else
                    return Escreve(caminho, arquivo, texto, val);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

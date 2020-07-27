using System.Collections.Generic;

namespace VM.LF2020.Core.ManipulaArquivo
{
    public sealed class Validacoes
    {
        private List<string> list;

        public Validacoes()
        {
            list = new List<string>();
        }

        public void adicionarProblemas(string mensagem)
        {
            list.Add(mensagem);
        }

        public string retornarProblemas()
        {
            string prob = string.Empty;
            foreach (string p in list)
                prob += p + "\n";
            return prob;
        }

        public bool possuiProblemas()
        {
            return (list.Count > 0);
        }
    }
}

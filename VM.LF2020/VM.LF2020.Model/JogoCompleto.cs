using System;
using System.Collections.Generic;
using System.Text;

namespace VM.LF2020.Model
{
    public class JogoCompleto : Jogo
    {
        public int Concurso { get; set; }

        public string DataSorteio { get; set; }

        public int QtdAnterior { get; set; }

        public int Par { get; set; }

        public int Impar { get; set; }

        public int Cima { get; set; }

        public int Meio { get; set; }

        public int Baixo { get; set; }

        public int Sequencia { get; set; }

        public bool Situacao { get; set; }

        public string Sorteio { get; set; }
    }
}

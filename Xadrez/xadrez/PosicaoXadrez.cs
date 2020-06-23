using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            int aux;
            if (coluna == 'a') aux = 0;
            else if (coluna == 'b') aux = 1;
            else if (coluna == 'c') aux = 2;
            else if (coluna == 'd') aux = 3;
            else if (coluna == 'e') aux = 4;
            else if (coluna == 'f') aux = 5;
            else if (coluna == 'g') aux = 6;
            else if (coluna == 'h') aux = 7;
            else aux = coluna - 'a';

            return new Posicao(8 - linha, aux);
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}

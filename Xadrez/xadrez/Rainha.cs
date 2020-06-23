using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Rainha : Peca
    {

        public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            mat[0, 0] = false;
            return mat;
        }

        public override string ToString()
        {
            return "Ra";
        }
    }
}
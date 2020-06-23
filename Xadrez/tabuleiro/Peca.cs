using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao posicao { get; set; }
        public Cor cor { get; private set; }
        public int qteMovimentos { get; private set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            qteMovimentos = 0;
        }

        public void incrementarQtdMovimentos()
        {
            qteMovimentos++;
        }

     public abstract bool[,] movimentosPossiveis();
    }
}

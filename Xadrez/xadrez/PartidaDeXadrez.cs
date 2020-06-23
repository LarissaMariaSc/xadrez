using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public bool terminada { get; private set; }
        private int turno;
        private Cor jogadorAtual;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            terminada = false;
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void colocarPecas()
        {
            // Pecas brancas
            //for (char i = 'B'; i <= 'H'; i++)
            //{
            //    tab.colocarPeca(new Peao(Cor.Branca, tab), new PosicaoXadrez(i, 2).toPosicao());
            //}
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 1).toPosicao());
            //tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('B', 1).toPosicao());
            //tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('G', 1).toPosicao());
            //tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('C', 1).toPosicao());
            //tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('F', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 1).toPosicao());
            // tab.colocarPeca(new Rainha(Cor.Branca, tab), new PosicaoXadrez('E', 1).toPosicao());

            // Pecas pretas
            //for (char i = 'A'; i <= 'H'; i++)
            // {
            //   tab.colocarPeca(new Peao(Cor.Preta, tab), new PosicaoXadrez(i, 7).toPosicao());
            //}
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 7).toPosicao());
            //tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('B', 8).toPosicao());
            // tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('G', 8).toPosicao());
            // tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('C', 8).toPosicao());
            // tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('F', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 8).toPosicao());
           // tab.colocarPeca(new Rainha(Cor.Preta, tab), new PosicaoXadrez('E', 8).toPosicao());

        }
    }
}

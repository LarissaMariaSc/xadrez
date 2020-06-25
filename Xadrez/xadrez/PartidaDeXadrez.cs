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
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            terminada = false;
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicoesDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        public void colocarPecas()
        {
            // Pecas brancas
            //for (char i = 'B'; i <= 'H'; i++)
            //{
            //    tab.colocarPeca(new Peao(Cor.Branca, tab), new PosicaoXadrez(i, 2).toPosicao());
            //}

            colocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Torre(Cor.Branca, tab));

            //tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('B', 1).toPosicao());
            //tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('G', 1).toPosicao());
            //tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('C', 1).toPosicao());
            //tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('F', 1).toPosicao());
            colocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));
            // tab.colocarPeca(new Rainha(Cor.Branca, tab), new PosicaoXadrez('E', 1).toPosicao());

            // Pecas pretas
            //for (char i = 'A'; i <= 'H'; i++)
            // {
            //   tab.colocarPeca(new Peao(Cor.Preta, tab), new PosicaoXadrez(i, 7).toPosicao());
            //}
            colocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('c', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));
            //tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('B', 8).toPosicao());
            // tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('G', 8).toPosicao());
            // tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('C', 8).toPosicao());
            // tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('F', 8).toPosicao());
            colocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));
            // tab.colocarPeca(new Rainha(Cor.Preta, tab), new PosicaoXadrez('E', 8).toPosicao());

        }
    }
}

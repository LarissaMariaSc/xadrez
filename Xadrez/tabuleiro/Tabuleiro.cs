using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posi)
        {
            return pecas[posi.linha, posi.coluna];
        }

        public bool existePeca(Posicao posi)
        {
            validarPosicao(posi);
            return peca(posi) != null;
        }
        public void colocarPeca(Peca p, Posicao posi)
        {
            if (existePeca(posi))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            pecas[posi.linha, posi.coluna] = p;
            p.posicao = posi;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao posi)
        {
            if (posi.coluna < 0 || posi.coluna > colunas || posi.linha < 0 || posi.linha > linhas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao posi)
        {
            if (!posicaoValida(posi))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}

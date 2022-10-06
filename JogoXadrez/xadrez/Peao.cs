﻿using tabuleiro;

namespace xadrez {

    class Peao : Peca {

        private PartidaDeXadrez Partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            Partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos) {
            return Tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha - 2, Pos.Coluna);
                Posicao p2 = new Posicao(Pos.Linha - 1, Pos.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Pos.Linha == 3) {
                    Posicao esquerda = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant) {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant) {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else {
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha + 2, Pos.Coluna);
                Posicao p2 = new Posicao(Pos.Linha + 1, Pos.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Pos.Linha == 4) {
                    Posicao esquerda = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant) {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant) {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}

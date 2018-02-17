using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using Szachy.Figures;

namespace Chess
{
    class Chessboard : Board
    {
        //figury:
        Pawn[] WhitePawns, BlacKPawns;

        public Chessboard()
            :base(8, 8)//przy wywolywaniu konstruktora klasy bazowej w ktorym uzywam metody ktora nastepnie nadpisuje w kasie pochodnej, wywoywana jest moedota z klasy pochodnej
        {
            InitFigures();
            DeployFigures();
        }

        protected override void CreateNet(int Widht, int Height)
        {
            Net = new Square[Widht, Height];
            bool White = true;
            int field = 65; //ASCII 65=A
            int rank = 1;

            for (int i = 0; i < Widht; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Net[i, j] = new Square(i, j, White, (char)field, rank);
                    field++;
                    White = !White;
                }
                White = !White;
                rank++;
                field = 65;
            }
        }

        private void DeployFigures()
        {
            for(int i = 0; i < 8; i++)
            {
                (Net[i, 1] as Square).SetFigure(g, WhitePawns[i]);
                (Net[i, 1] as Square).SetFigure(g, BlacKPawns[i]);
            }
        }

        private void InitFigures()
        {
            InitPawns();
        }

        private void InitPawns()
        {
            WhitePawns = new Pawn[8];
            BlacKPawns = new Pawn[8];
            for (int i=0; i<8; i++)
            {
                WhitePawns[i] = new Pawn(i, 1, true);
                BlacKPawns[i] = new Pawn(i, 1, false);
            }
        }
    }
}

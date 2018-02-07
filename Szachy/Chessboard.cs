using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;

namespace Chess
{
    class Chessboard : Board
    {
        public Chessboard()
            :base(8, 8)
        {

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
    }
}

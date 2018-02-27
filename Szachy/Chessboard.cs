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
        public Chessboard()
            :base(8, 8)//przy wywolywaniu konstruktora klasy bazowej w ktorym uzywam metody ktora nastepnie nadpisuje w kasie pochodnej, wywoywana jest moedota z klasy pochodnej
        {
            Enabled = true;
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
                    Square squere = new Square(i, j, White, (char)field, rank);
                    Net[i, j] = squere;
                    Controls.Add(squere);
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

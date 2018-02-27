using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    public class Board : Panel, IBoard
    {
        public IField[,] Net { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Board(int Height, int Widht)
        {
            this.Width = 60 * Width;
            this.Height = 60 * Height;
            X = Widht;
            Y = Height;
            CreateNet(X, Y);
            Paint += Board_OnPaint;
        }

        protected virtual void CreateNet(int Widht, int Height )//tworzy siatke
        {
            Net = new Fieldv2[Widht, Height];

            for (int i = 0; i < Widht; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Fieldv2 field = new Fieldv2(i, j);
                    Net[i, j] = field;
                    Controls.Add(field);
                }
            }
        }

        public virtual void RefreshNet()//odswierza siatke
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Net[i, j].Refresh();
                }
            }
        }

        public virtual void ClearNet()//czysci siatke
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Net[i, j].Clear();
                }
            }
        }
        private void Board_OnPaint(object sender, PaintEventArgs e)
        {
            RefreshNet();
        }
    }
}

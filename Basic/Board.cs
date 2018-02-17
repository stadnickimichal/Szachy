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
        public Graphics g { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Board(int Height, int Widht)
        {
            this.Width = 60 * Width;
            this.Height = 60 * Height;
            X = Widht;
            Y = Height;
            CreateNet(X, Y);
            g = CreateGraphics();
            Paint += Board_OnPaint;
        }

        protected virtual void CreateNet(int Widht, int Height )//tworzy siatke
        {
            Net = new Field[Widht, Height];

            for (int i = 0; i < Widht; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Net[i, j] = new Field(i, j);
                }
            }
        }

        public virtual void DrawNet()
        {
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    Net[i, j].Draw(g);
                }
            }
        }

        public virtual void RefreshNet()//odswierza siatke
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Net[i, j].Refresh(g);
                }
            }
        }

        public virtual void ClearNet()//czysci siatke
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Net[i, j].Clear(g);
                }
            }
        }

        public virtual void DrawImageOnNetElement(int X, int Y, Bitmap img)//wrysowuje obrazek w element siatki
        {
            Net[X, Y].DrawImage(g,img);
        }

        public virtual void DrawOnNetElement(int X, int Y, Color color)//koloruje element siatki
        {
            Net[X, Y].Draw(g, color);
        }

        private void Board_OnPaint(object sender, PaintEventArgs e)
        {
            RefreshNet();
        }
    }
}

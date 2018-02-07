using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Basic;
using Szachy.Figures;

namespace Chess
{

    class Square : Field
    {
        public char File { get; set; }
        public int Rank { get; set; }
        private bool FlagIsWhite;
        //public override IFigure Figure { get; protected set; }

        public Square(int X, int Y, bool isWhite, char file, int rank):base(X, Y)
        {
            File = file;
            Rank = Rank;
            FlagIsWhite = isWhite;
            FieldColor = (FlagIsWhite) ? Color.White : Color.Black;
        }

        public Square(int X, int Y, bool isWhite, int file, int rank) : base(X, Y)
        {
            try
            {
                File = Convert.ToChar(file);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: Convertion Char to Int failed!");
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            Rank = Rank;
            FlagIsWhite = isWhite;
            FieldColor = (FlagIsWhite) ? Color.White : Color.Black;
        }
        
        public override void Clear(Graphics g)//nie zmienia koloru pola tylko usuwa z niego figure
        {
            Figure = null;
            FieldImage = null;
            Draw(g);
        }

        public void SetFigure(Graphics g, IFigure figure)//ustawia figure na polu i wrysowywuje ja
        {
            Figure = figure;
            string URL = figure.URLToFigureImage;
            Image img = new Bitmap(URL);
            DrawImage(g, img);
        }
    }
}

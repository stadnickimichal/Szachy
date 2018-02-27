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

    class Square : Fieldv2
    {
        public char File { get; set; }
        public int Rank { get; set; }
        private bool FlagIsWhite;

        public Square(int X, int Y, bool isWhite, char file, int rank):base(X, Y)
        {
            File = file;
            Rank = Rank;
            FlagIsWhite = isWhite;
            FieldColor = (FlagIsWhite) ? Color.White : Color.FromArgb(153, 102, 51);
            BackColor = FieldColor.Value;
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
            FieldColor = (FlagIsWhite) ? Color.White : Color.FromArgb(153, 102, 51);
            BackColor = FieldColor.Value;
        }
    }
}

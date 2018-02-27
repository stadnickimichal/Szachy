using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using System.Drawing;

namespace Szachy.Figures
{
    abstract class FigureAbstract : IFigure
    {
        public FigureAbstract(int X, int Y, FiguresTypes type, IPlayer owner)
        {
            Position = new Point(X, Y);
            FigureType = type;
            Owner = owner;
        }

        protected Dictionary<FiguresTypes, string> ChessFigureImg = new Dictionary<FiguresTypes, string>()
        {
            {FiguresTypes.WhitePawn, @"D:\C#_projekty\Szachy\Szachy\source\WhitePawn.png" },
            {FiguresTypes.WhiteKnight, @"D:\C#_projekty\Szachy\Szachy\source\WhitePawn.png" },
            {FiguresTypes.WhiteRook, @"..\source\RookWhite.png" },
            {FiguresTypes.WhiteBishop, @"..\source\BishopWhite.png" },
            {FiguresTypes.WhiteQueen, @"..\source\QueenWhite.png" },
            {FiguresTypes.WhiteKing, @"..\source\KingWhite.png" },
            {FiguresTypes.BlackPawn, @"D:\C#_projekty\Szachy\Szachy\source\BlackPawn.png" },
            {FiguresTypes.BlackKnight, "" },
            {FiguresTypes.BlackRook, "" },
            {FiguresTypes.BlackBishop, "" },
            {FiguresTypes.BlackQueen, "" },
            {FiguresTypes.BlackKing, "" },
        };
        
#region implementation of IFigure
        public string URLToFigureImage { get; protected set; }

        public string Name { get; protected set; }

        public Point Position { get; set; }

        public abstract bool ValidateMove(IField field);

        public FiguresTypes FigureType { get; set; }

        public IPlayer Owner { get; set; }
        #endregion
    }
}

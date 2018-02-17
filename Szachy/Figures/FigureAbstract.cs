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
        public FigureAbstract(int X, int Y)
        {
            Position = new Point(X, Y);
        }

        protected Dictionary<ChessFigures, string> ChessFigureImg = new Dictionary<ChessFigures, string>()
        {
            {ChessFigures.WhitePawn, @"D:\C#_projekty\Szachy\Szachy\source\WhitePawn.png" },
            {ChessFigures.WhiteKnight, @"..\source\KnightWhite.png" },
            {ChessFigures.WhiteRook, @"..\source\RookWhite.png" },
            {ChessFigures.WhiteBishop, @"..\source\BishopWhite.png" },
            {ChessFigures.WhiteQueen, @"..\source\QueenWhite.png" },
            {ChessFigures.WhiteKing, @"..\source\KingWhite.png" },
            {ChessFigures.BlackPawn, @"D:\C#_projekty\Szachy\Szachy\source\BlackPawn.png" },
            {ChessFigures.BlackKnight, "" },
            {ChessFigures.BlackRook, "" },
            {ChessFigures.BlackBishop, "" },
            {ChessFigures.BlackQueen, "" },
            {ChessFigures.BlackKing, "" },
        };

        public string URLToFigureImage { get; protected set; }

        public string Name { get; protected set; }

        public Point Position { get; set; }

        public ChessFigures FigureType;

        public abstract bool ValidateMove(IField field);
    }
}

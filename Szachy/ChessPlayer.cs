using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using Szachy.Figures;

namespace Szachy
{
    class ChessPlayer : IPlayer
    {

        public ChessPlayer(string name, bool isWhite)
        {
            IsWhire = isWhite;
            Name = name;
            CreateFigureSet();
            FiguresCaptured = new List<IFigure>();
        }

        public bool IsWhire;

        #region Impelemntation of IPlayer
        public string Name { get; set; }

        public List<IFigure> Figures { get; set; }

        public List<IFigure> FiguresCaptured { get; set; }
        #endregion

        private void CreateFigureSet()
        {
            int PawnY = (IsWhire) ? 1 : 6;
            Figures = new List<IFigure>();

            for (int i = 0; i < 8; i++)
            {
                FiguresTypes type = (IsWhire) ? FiguresTypes.WhitePawn : FiguresTypes.BlackPawn;
                Figures.Add(new Pawn(i, PawnY, type, this, IsWhire));
            }
        }
    }
}
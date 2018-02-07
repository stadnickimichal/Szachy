using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using Chess;

namespace Szachy.Figures
{
    class Pawn : FigureAbstract
    {
       
        bool FirstMove;

        public Pawn(int X, int Y, bool isWhite) :base(X,Y)
        {
            FigureType = (isWhite) ? ChessFigures.WhitePawn : ChessFigures.BlackPawn;
            Name = "Pawn";
            URLToFigureImage = ChessFigureImg[FigureType];
            FirstMove = true;
        }

        public override bool ValidateMove(IField field)
        {
            int PassibleMoveForward = 1;
            if (FirstMove)
            {
                FirstMove = false;
                PassibleMoveForward = 2;
            }

            if (!MoveForwardCheckCorrectnes(field.PositionY, PassibleMoveForward))
                return false;

            if (!SidewaysMovementsCheckCorrectnes(field))
                return false;

            return true;
        }

        private bool MoveForwardCheckCorrectnes(int DestinityY, int PassibleMoveForward) =>
            ((DestinityY - Position.Y <= PassibleMoveForward) && (DestinityY - Position.Y > 0));

        private bool SidewaysMovementsCheckCorrectnes(IField field) =>
            ((field.Figure != null) && (field.PositionX - Position.X == 1 || field.PositionX - Position.X == -1) && (field.PositionY - Position.Y == 1));
    }
}

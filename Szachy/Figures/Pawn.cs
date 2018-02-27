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

        public Pawn(int X, int Y, FiguresTypes type, ChessPlayer owner, bool isWhite) :base(X,Y, type, owner)
        {
            FigureType = (isWhite) ? FiguresTypes.WhitePawn : FiguresTypes.BlackPawn;
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

        private bool MoveForwardCheckCorrectnes(int DestinityY, int PassibleMoveForward)
        {
            if ((FigureType == FiguresTypes.WhitePawn) && (DestinityY - Position.Y <= PassibleMoveForward) && (DestinityY - Position.Y >= 0))
                return true;

            if ((FigureType == FiguresTypes.BlackPawn) && (Position.Y - DestinityY <= PassibleMoveForward) && (Position.Y - DestinityY >= 0))
                return true;

            return false;
        }

        private bool SidewaysMovementsCheckCorrectnes(IField field)
        {
            if (!(field.PositionX - Position.X == 1 || field.PositionX - Position.X == -1))//jesli nie zachodzi ruch na boki to zwraca true
                return true;

            if (FigureType == FiguresTypes.WhitePawn && (field.Figure != null) && (field.PositionY - Position.Y == 1))
                    return true;

            if (FigureType == FiguresTypes.BlackPawn && (field.Figure != null) && (Position.Y - field.PositionY == 1))
                    return true;

            return false;
        }
    }
}

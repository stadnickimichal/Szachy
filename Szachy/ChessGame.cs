using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using Chess;
using Szachy;
using Szachy.Figures;

namespace Szachy
{
    class ChessGame : IGame
    {
        public IBoard GameBoard { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public int RoundCounter { get; private set; }

        private FigureAbstract FigureInHand;
        private IPlayer CurrentPlayer;

        public ChessGame(IBoard board, IPlayer palyer1, IPlayer player2)
        {
            GameBoard = board;
            Player1 = palyer1;
            Player2 = player2;
        }

        public void Start()
        {
            SetupFigures();
            CurrentPlayer = Player1;
            BindEvents();
        }

        private void SetupFigures()
        {
            foreach(IFigure fig in Player1.Figures)
            {
                GameBoard.Net[fig.Position.X, fig.Position.Y].DrawImage(fig);
            }

            foreach (IFigure fig in Player2.Figures)
            {
                GameBoard.Net[fig.Position.X, fig.Position.Y].DrawImage(fig);
            }
        }

#region Events
        private void BindEvents()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    (GameBoard.Net[i, j] as Square).Click += Square_Click;
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            Square squer = (Square)sender;

            if (squer.Figure != null && squer.Figure.Owner != CurrentPlayer && FigureInHand == null)//jesli pole ma figure ale nie jest to figura obecnego gracza to nie robi nic
                return;

            if (FigureInHand == null && squer.Figure == null)//jesli pole nie ma figury ani nie ma figury w dloni to nie robi nic
            {
                return;
            }

            if (FigureInHand == null && squer.Figure != null)// jesli nie ma figury w dloni a pole posiada figure to daj bierze ja do reki
            {
                FigureInHand = squer.Figure as FigureAbstract;
                squer.Clear();
                return;
            }

            if(FigureInHand != null && squer.Figure ==null && FigureInHand.ValidateMove(squer))// jezeli ma figure w rece i wybrane pole jest puste i poprawne to klade tam figure
            {
                squer.DrawImage(FigureInHand);
                FigureInHand = null;
                RoundEnd();
                return;
            }

            if(FigureInHand != null && squer.Figure != null && FigureInHand.ValidateMove(squer))// jezeli ma figure w rece i wybrane pole ma figure i poprawne to ja bije
            {
                if (squer.Figure.Owner == CurrentPlayer)
                    return;

                CaptureFigure(squer);
                return;
            }
        }

        private void CaptureFigure(Square squer)
        {
            squer.Figure.Owner.Figures.Remove(squer.Figure);
            CurrentPlayer.FiguresCaptured.Add(squer.Figure);
            squer.Clear();
            squer.DrawImage(FigureInHand);
            FigureInHand = null;
            RoundEnd();
        }

        private void RoundEnd()
        {
            CurrentPlayer = NextPlayer();
            RoundCounter++;
        }

        private IPlayer NextPlayer()
        {
            if (CurrentPlayer == Player1)
                return Player2;
            else
                return Player1;
        }
    }
#endregion

}

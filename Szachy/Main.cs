using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using Szachy;
using Szachy.Figures;

namespace Chess
{
    class Main : Form
    {
        private Chessboard Board;
        private ChessPlayer Player1, Player2;
        private ChessGame Game;
        private System.ComponentModel.IContainer components = null;

        public Main()
        {
            InitializeComponent();
            Board.RefreshNet();
        }

        private void InitializeComponent()
        {
            Console.WriteLine("gra");
            // Board
            this.Board = new Chess.Chessboard();
            this.Board.Location = new System.Drawing.Point(20, 20);
            // Game
            Player1 = new ChessPlayer("Bialy", true);
            Player2 = new ChessPlayer("Czarny", false);
            Game = new ChessGame(Board, Player1, Player2);
            Game.Start();
            // Main
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.Board);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

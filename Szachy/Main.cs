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

namespace Chess
{
    class Main : Form
    {
        private Chessboard Board;
        private System.ComponentModel.IContainer components = null;

        public Main()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Board
            this.Board = new Chess.Chessboard();
            this.Board.Location = new System.Drawing.Point(20, 20);
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

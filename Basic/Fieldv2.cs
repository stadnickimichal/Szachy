using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    public partial class Fieldv2 : UserControl, IField
    {
        public int PositionX { get; protected set; }
        public int PositionY { get; protected set; }
        public virtual IFigure Figure { get; protected set; } //TO DO: sprawdzic czy potrzebne przy optymalizacji

        public Color? FieldColor { get; protected set; }
        public Bitmap FieldImage { get; protected set; }

        public Fieldv2(int X, int Y, Color color)
        {
            InitializeComponent(X, Y, color);
            FieldColor = null;
            FieldImage = null;
            Paint += Fieldv2_Paint;
        }

        public Fieldv2(int X, int Y)
        {
            InitializeComponent(X, Y);
            FieldColor = null;
            FieldImage = null;
            Paint += Fieldv2_Paint;
        }

        private void Fieldv2_Paint(object sender, PaintEventArgs e)
        {
            if(FieldImage != null)
            {
                Color backgroundColor = FieldImage.GetPixel(0, 0);
                FieldImage.MakeTransparent(backgroundColor);

                e.Graphics.DrawImage(FieldImage, new Point(0, 0));
            }
        }

        public virtual void DrawImage(IFigure fig)
        {
            FieldImage = new Bitmap(new Bitmap(fig.URLToFigureImage), new Size(60,60));
            Figure = fig;
            fig.Position = new Point(PositionX, PositionY);
            Refresh();
        }

        public void Clear()
        {
            BackColor = FieldColor.Value;
            Figure = null;
            FieldImage = null;
            Refresh();
        }
        
        private void InitializeComponent(int X, int Y)
        {
            Width = 60;
            Height = 60;
            Left = X * Width;
            Top = Y * Width;
            PositionX = X;
            PositionY = Y;
            FieldColor = BackColor;
        }

        private void InitializeComponent(int X, int Y, Color color)
        {
            InitializeComponent(X, Y);
            FieldColor = color;
            BackColor = FieldColor.Value;
        }
    }
}

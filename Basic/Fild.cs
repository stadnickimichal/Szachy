using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Basic
{
    public class Field
    {
        private const int Height = 60;
        private const int Width = 60;
        public int PositionX { get; protected set; }
        public int PositionY { get; protected set; }
        private Rectangle Squer;
        public virtual IFigure Figure { get; protected set; } //TO DO: sprawdzic czy potrzebne przy optymalizacji

        public Color? FieldColor { get; protected set; }
        public Bitmap FieldImage { get; protected set; }

        public Field(int X, int Y)
        {
            PositionX = X;
            PositionY = Y;
            int RealPositionX = PositionX * Width;
            int RealPositionY = PositionY * Height;
            Squer = new Rectangle(RealPositionX, RealPositionY, Width, Height);
            FieldColor = null;
            FieldImage = null;
        }

        public virtual void Draw(Graphics g, Color color)
        {
            Pen pen = Pens.Black;
            Brush br = new SolidBrush(color);

            g.DrawRectangle(pen, Squer);
            g.FillRectangle(br, Squer);
            FieldColor = color;
        }
        public virtual void Draw(Graphics g)//TO DO: sprawdzic czy potrzebe
        {
            if (FieldColor == null)
            {
                Console.WriteLine("No color set for field");
                return;
            }
            Brush br = new SolidBrush(FieldColor.Value);

            g.DrawRectangle(Pens.Black, Squer);
            g.FillRectangle(br, Squer);
        }
        public virtual void Clear(Graphics g)
        {
            Brush br = new SolidBrush(FieldColor.Value);
            g.FillRectangle(br, Squer);
            
            if (FieldImage != null)
                FieldImage = null;
        }
        public virtual void DrawImage(Graphics g, Bitmap image)
        {
            FieldImage = image;
            int imgUpperLeftCornerX = (Width - FieldImage.Width)/2;
            int imgUpperLeftCornerY = (Height - FieldImage.Height)/ 2;
            Rectangle srcRect = new Rectangle(imgUpperLeftCornerX, imgUpperLeftCornerY, FieldImage.Width, FieldImage.Height);
            g.DrawImage(FieldImage, Squer);
        }
        public virtual void DrawImage(Graphics g)//TO DO: sprawdzic czy potrzebe
        {
            int imgUpperLeftCornerX = (Width - FieldImage.Width) / 2;
            int imgUpperLeftCornerY = (Height - FieldImage.Height) / 2;
            Rectangle srcRect = new Rectangle(imgUpperLeftCornerX, imgUpperLeftCornerY, FieldImage.Width, FieldImage.Height);
            g.DrawImage(FieldImage, Squer);
        }
        public virtual void Refresh(Graphics g)
        {
            if(FieldImage != null)
                DrawImage(g);
            else if (FieldColor != null)
                Draw(g);
            else
                Clear(g);
        }
    }
}

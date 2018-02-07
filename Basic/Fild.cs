using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Basic
{
    public class Field : IField
    {
        private const int Height = 60;
        private const int Width = 60;
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        private Rectangle Squer;
        public virtual IFigure Figure { get; protected set; }

        public Color? FieldColor { get; set; }
        public Image FieldImage { get; set; }

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
        public virtual void Draw(Graphics g)
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
            Brush br = new SolidBrush(Color.White);
            g.FillRectangle(br, Squer);
            FieldColor = Color.White;

            if (FieldColor != null)
                FieldColor = null;

            if (FieldImage != null)
                FieldImage = null;
        }
        public virtual void DrawImage(Graphics g, Image image)
        {
            int imgUpperLeftCornerX = (Width - image.Width)/2;
            int imgUpperLeftCornerY = (Height - image.Height)/ 2;
            Rectangle srcRect = new Rectangle(imgUpperLeftCornerX, imgUpperLeftCornerY, image.Width, image.Height);
            g.DrawImage(image, Squer, srcRect, GraphicsUnit.Pixel);
        }
        public virtual void DrawImage(Graphics g)
        {
            int imgUpperLeftCornerX = (Width - FieldImage.Width) / 2;
            int imgUpperLeftCornerY = (Height - FieldImage.Height) / 2;
            Rectangle srcRect = new Rectangle(imgUpperLeftCornerX, imgUpperLeftCornerY, FieldImage.Width, FieldImage.Height);
            g.DrawImage(FieldImage, Squer, srcRect, GraphicsUnit.Pixel);
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

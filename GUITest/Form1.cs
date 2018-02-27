using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawTransparentImage(@"D:\C#_projekty\Szachy\Szachy\source\BlackPawn.png");
            Paint += Form1_Paint;
            Click += Form1_Click;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("adasd");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Bitmap img = new Bitmap(@"D:\C#_projekty\Szachy\Szachy\source\noun_102236_cc.png");
            Color backgroundColor = img.GetPixel(0, 0);
            img.MakeTransparent(backgroundColor);

            e.Graphics.DrawImage(img, new Point(40, 40));
        }

        private void DrawTransparentImage(string dir)
        {
            Bitmap img = new Bitmap(dir);
            Color backgroundColor = img.GetPixel(0, 0);
            img.MakeTransparent(backgroundColor);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(img, new Point(0, 0));
            }
        }
    }
}

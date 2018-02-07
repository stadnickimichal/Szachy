using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface IBoard
    {
        IField[,] Net { get; set; }

        Graphics g { get; set; }

        void DrawNet();

        void DrawOnNetElement(int X, int Y, Color color);

        void DrawImageOnNetElement(int X, int Y, Image img);

        void ClearNet();

        void RefreshNet();
    }
}

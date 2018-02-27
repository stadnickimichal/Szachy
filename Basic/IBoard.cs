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

        void ClearNet();

        void RefreshNet();
    }
}

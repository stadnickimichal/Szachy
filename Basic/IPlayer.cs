using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface IPlayer
    {
        string Name { get; set; }

        List<IFigure> Figures { get; set; }

        List<IFigure> FiguresCaptured { get; set; }
    }
}

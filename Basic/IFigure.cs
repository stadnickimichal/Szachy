using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface IFigure
    {
        //scierzka do obrazak z figura
        string URLToFigureImage { get; }
        //Nazwa figury
        string Name { get; }
        //sprawdzenie czy ruch figury jest prawidlowy
        bool ValidateMove(IField field);
        //pozycja figury
        Point Position { get; set; }
        //TODO prop z graczem i do ValidateMove sprawdzenie zgodnosci z graczem
    }
}

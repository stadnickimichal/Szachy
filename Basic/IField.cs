﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface IField
    {
        //Numer pola na prostej X
        int PositionX { get; }
        //Numer pola na prostej Y
        int PositionY { get; }
        //zwraca informacje czy na polu znajduje sie obecnie figura, jesli tak to jaka
        IFigure Figure { get; }
        //koloruje pole na bialo i restartuje img oraz kolor
        void DrawImage(IFigure figure);
        //wrysowywuje w pole obrazek (wysrodkowany) ze zmienne FieldImage
        void Clear();
        //odswierzenie, moze byc zaimplementowane poprzez funkcje z kontrolki
        void Refresh();
    }
}

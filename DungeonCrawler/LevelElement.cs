using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    internal abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; protected set; }
        public ConsoleColor Color { get; protected set; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();

        }

    }
}

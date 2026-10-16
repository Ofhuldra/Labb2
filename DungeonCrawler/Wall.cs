using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    internal class Wall : LevelElement
    {
        public Wall(int x, int y)
        {
            X = x;
            Y = y; 
            Symbol = '#';
            Color = ConsoleColor.Gray;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace DungeonCrawler
{
    internal class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();

        public List<LevelElement> Elements => elements;

        public int PlayerStartX { get; private set; }
        public int PlayerStartY { get; private set; }

        public void Load(string filename)
        {
            string[] Lines = File.ReadAllLines(filename);

            for (int y = 0; y < Lines.Length; y++)
            {
                for ( int x = 0; x < Lines[y].Length; x++)
                {
                    char c = Lines[y][x];

                    if (c == '#')
                    {
                        elements.Add(new Wall(x, y));
                    }
                    else if (c == 'r')
                    {
                        elements.Add(new Rat(x, y));
                    }
                    else if (c == 's')
                    {
                        elements.Add(new Snake(x, y));
                    }
                    else if (c == '@')
                    {
                        PlayerStartX = x;
                        PlayerStartY = y;
                    }
                }
            }
        }

        public LevelElement? GetElementAt(int x, int y)
        {
            foreach (LevelElement element in elements)
            {

                if (element.X == x && element.Y == y)
                {
                    return element;
                }
            }

            return null;
        }
    }

}   

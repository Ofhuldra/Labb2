using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DungeonCrawler
{
    internal class Player : LevelElement
    {
        public string Name { get; private set; }
        public int HP { get; set; }
        public Dice AttackDice { get; private set; }
        public Dice DefenceDice { get; private set; }
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = '@';
            Color = ConsoleColor.Yellow;
            Name = "Player";
            HP = 100;
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }
    }
}

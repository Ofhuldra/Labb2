using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    internal abstract class Enemy : LevelElement
    {
        public Dice AttackDice { get; protected set; }
        public Dice DefenceDice { get; protected set; }
        public string Name { get; protected set; }
        public int HP { get; set; }
        public abstract void Update(LevelData level, Player player);

    }

}

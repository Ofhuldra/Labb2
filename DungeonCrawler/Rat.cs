using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    internal class Rat : Enemy
    {
        private static Random random = new Random();

        public Rat(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = 'r';
            Color = ConsoleColor.Red;
            Name = "Rat";
            HP = 10;
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }

        public override void Update(LevelData level, Player player)
        {
            int direction = random.Next(0, 4);
            int dx = 0;
            int dy = 0;

            if (direction == 0)
            {
                dy = -1;
            }
            else if (direction == 1)
            {
                dy = +1;
            }
            else if (direction == 2)
            {
                dx = +1;
            }
            else if (direction == 3)
            {
                dx = -1;
            }

            int newX = X + dx;
            int newY = Y + dy;
            
            if (newX == player.X && newY == player.Y)
            {
                    player.HP -= Dice.Damage(AttackDice, player.DefenceDice);
                    if (player.HP > 0)
                    {
                        HP -= Dice.Damage(player.AttackDice, DefenceDice);
                    }
            }
            else if (level.GetElementAt(newX, newY) == null)
            {
                    X = newX;
                    Y = newY;
            }
        }
    }
}

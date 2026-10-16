using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DungeonCrawler
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = 's';
            Color = ConsoleColor.DarkGreen;
            Name = "Snake";
            HP = 25;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
    }
    
        public override void Update(LevelData level, Player player)
        {
            double distance = Math.Sqrt((X - player.X) * (X - player.X) + (Y - player.Y) * (Y - player.Y));

            if (distance > 2)
            {
                return;
            }

            int dx = 0;
            int dy = 0;

            if (player.X < X)
            {
                dx = 1;
            }
            else if (player.X > X)
            {
                dx = -1;
            }
            if (player.Y < Y)
            {
                dy = 1;
            }
            else if (player.Y > Y)
            {
                dy = -1;
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

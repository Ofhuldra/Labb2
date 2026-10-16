using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DungeonCrawler
{
    internal class Dice
    {
            private int numberOfDice;
            private int sidesPerDice;
            private int modifier;
            private static Random random = new Random();

            public Dice(int numberOfDice, int sidesPerDice, int modifier)
            {
                this.numberOfDice = numberOfDice;
                this.sidesPerDice = sidesPerDice;
                this.modifier = modifier;
            }
            public int Throw()
            {
                int sum = 0;

                for (int i = 0; i < numberOfDice; i++)
                {
                    sum += random.Next(1, sidesPerDice + 1);
                }

                sum += modifier;
                return sum; 
                }

            public static int Damage(Dice attack, Dice defence)
            {
                return Math.Max(0, attack.Throw() - defence.Throw());
            }


            public override string ToString()
            {
                return $"{numberOfDice}d{sidesPerDice}+{modifier}";
            }
    }
}

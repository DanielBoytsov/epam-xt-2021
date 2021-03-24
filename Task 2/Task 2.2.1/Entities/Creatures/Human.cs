using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1
{
    public class Human : Creature
    {
        public int Attack { get; set; }

        public Human(int x, int y, string name, string type, int moveSpeed, int healthPoints, int attack)
            : base(x, y, name, type, moveSpeed, healthPoints)
        {
            Attack = attack;
        }

        public Human(int x, int y, string name, string type, int moveSpeed, int healthPoints, int attack, IStrategy strategy)
            : base(x, y, name, type, moveSpeed, healthPoints, strategy)
        {
            Attack = attack;
        }
    }
}

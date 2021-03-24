using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1
{
    public class Enemy : Creature
    {
        public int Attack { get; set; }
        public int VisionArea { get; set; }
        public Enemy(int x, int y, string name, string type, int moveSpeed, int healthPoints, int attack, int visionArea)
            : base(x, y, name, type, moveSpeed, healthPoints)
        {
            Attack = attack;
            VisionArea = visionArea;
        }

        public Enemy(int x, int y, string name, string type, int moveSpeed, int healthPoints, int attack, int visionArea, IStrategy strategy)
            : base(x, y, name, type, moveSpeed, healthPoints, strategy)
        {
            Attack = attack;
            VisionArea = visionArea;
        }
    }
}

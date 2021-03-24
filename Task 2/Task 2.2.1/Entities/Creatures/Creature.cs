using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1
{
    public class Creature : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int HealthPoints { get; set; } 
        public int MoveSpeed { get; set; }
        public List<Buff> Buffs;
        public IStrategy Strategy { get; set; }
        public Creature(int x, int y, string name, string type, int moveSpeed, int healthPoints)
            : base(x, y)
        {
            Name = name;
            Type = type;
            MoveSpeed = moveSpeed;
            HealthPoints = healthPoints;
            Buffs = new List<Buff>();
        }

        public Creature(int x, int y, string name, string type, int moveSpeed, int healthPoints, IStrategy strategy)
            : this(x, y, name, type, moveSpeed, healthPoints)
        {
            Strategy = strategy;
        }

        //public abstract void Damage();
        //public abstract void ShowHealthPoints();
        //public abstract void ShowMoveSpeed();
        //public abstract void ShowDamageReduction();

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1.Buffs
{
    public class Blueberry : IConduct
    {
        public void CharacterStepOn(Creature creature)
        {
            creature.HealthPoints += 50;
        }
    }
}

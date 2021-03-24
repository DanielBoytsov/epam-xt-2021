using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1.Buffs
{
    public class Raspberry : IConduct
    {
        public void CharacterStepOn(Creature creature)
        {
            if (creature is Enemy enemy)
            {
                CharacterStepOn(enemy);
            }
            else
            {
                creature.MoveSpeed++;
            }
        }

        public void CharacterStepOn(Enemy enemy)
        {
            enemy.Attack *= 2;
        }
    }
}

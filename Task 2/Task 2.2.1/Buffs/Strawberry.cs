using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1.Buffs
{
    public class Strawberry : IBuff
    {
        public void CharacterStepOn(Creature creature)
        {
            Buff buff = creature.Buffs.FirstOrDefault(x => x.Conduct is Strawberry);
            if (buff != null)
            {
                buff.StepsCount = 7;
            }
            else
            {
                creature.Buffs.Add(new Buff(7, State.AcrossObstacles.ToString(), new Strawberry()));
            }
        }

        public void NextStep(Buff buff)
        {
            buff.StepsCount--;
        }
    }
}

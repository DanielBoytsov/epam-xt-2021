using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1
{
    public class Buff
    {
        public int StepsCount { get; set; }
        public string State { get; set; }

        public IBuff Conduct { get; set; }

        public Buff(int stepsCount)
        {
            StepsCount = stepsCount;
        }
        public Buff(int stepsCount, IBuff conduct)
        {
            StepsCount = stepsCount;
            Conduct = conduct;
        }
        public Buff(int stepsCount, string state)
        {
            StepsCount = stepsCount;
            State = state;
        }
        public Buff(int stepsCount, string state, IBuff conduct)
        {
            StepsCount = stepsCount;
            State = state;
            Conduct = conduct;
        }
    }
}

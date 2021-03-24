using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._1.Interfaces
{
    public interface IBuff : IConduct
    {
        void NextStep(Buff buff);
    }
}

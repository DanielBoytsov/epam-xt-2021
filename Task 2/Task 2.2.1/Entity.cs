using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Task_2._2._1
{
    public abstract class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Entity(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Task_2._1._2.Enums;

namespace Task_2._1._2
{
    
    

    public abstract class Figure
    {
        protected double X { get; set; } 
        protected double Y { get; set; }
        protected Figure(double x, double y)
        {
            X = x;
            Y = y;
        }

        internal abstract string GetInfo();
    }
}

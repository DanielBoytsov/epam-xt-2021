using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Circle : Figure
    {
        //protected double X { get; set; } 
        //protected double Y { get; set; }
        protected double Radius { get; }

        public double GetSquare => Math.Pow(Radius, 2) * Math.PI;
        protected double GetCircleLength => 2 * Radius * Math.PI;

        //public Circle() 
        //{
        //    Radius = 1;
        //}
        public Circle(double x, double y, double radius) : base(x, y)
        {
            //X = x;
            //Y = y;
            if (radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new ArgumentException("Radius must be positive");
            }
        }

        internal override string GetInfo()
        {
            return $"Circle, Coordinates X = {X}, Y = {Y}; Radius = {Radius}; Square = {GetSquare}; Circle Length = {GetCircleLength}.";
        }
    }
}

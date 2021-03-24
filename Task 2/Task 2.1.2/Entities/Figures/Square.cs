using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Square : Figure
    {
        protected double SideLength { get; set; } = 1;
        protected double GetSquare => Math.Pow(SideLength, 2);
        protected double GetPerimeter => SideLength * 4;

        public Square(double x, double y, double sideLength) : base(x, y)
        {
            X = x;
            Y = y;
            if (sideLength > 0)
            {
                SideLength = sideLength;
            }
            else
            {
                throw new ArgumentException("SideLength must be positive and more than 0");
            }
        }

        internal override string GetInfo()
        {
            return $"Square, Coordinates X = {X}, Y = {Y}; SideLength = {SideLength}; Square = {GetSquare}; Perimeter = {GetPerimeter}.";
        }
    }
}

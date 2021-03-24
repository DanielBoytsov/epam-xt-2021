using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Rectangle : Figure
    {
        protected double WidthLength { get; set; } = 1;
        protected double HeightLength { get; set; } = 1;
        protected double GetSquare => WidthLength * HeightLength;
        protected double GetPerimeter => (WidthLength + HeightLength) * 2;

        public Rectangle(double x, double y, double widthLength, double heightLength) : base(x, y)
        {
            if (widthLength > 0)
            {
                WidthLength = widthLength;
            }
            else
            {
                throw new ArgumentException("WidthLength must be positive and more than 0");
            }
            if (heightLength > 0)
            {
                HeightLength = heightLength;
            }
            else
            {
                throw new ArgumentException("HeightLength must be positive and more than 0");
            }
        }

        internal override string GetInfo()
        {
            return $"Rectangle, Coordinates X = {X}, Y = {Y}; WidthLength = {WidthLength}; HeightLength = {HeightLength}; Square = {GetSquare}; Perimeter = {GetPerimeter}.";
        }
    }
}

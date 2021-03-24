using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Triangle : Figure
    {
        protected double AngleValue { get; set; } = 1;
        protected double FirstSideLength { get; set; } = 1;
        protected double SecondSideLength { get; set; } = 1;

        protected double GetSquare => 0.5 * FirstSideLength * SecondSideLength * Math.Sin(AngleValue);

        protected double GetPerimeter => Math.Sqrt(Math.Pow(FirstSideLength, 2) + Math.Pow(SecondSideLength, 2) -
                                                   2 * (FirstSideLength + SecondSideLength) * Math.Cos(AngleValue)) +
                                         FirstSideLength + SecondSideLength;

        public Triangle(double x, double y, double angleValue, double firstSideLength, double secondSideLength) : base(x, y)
        {
            if (angleValue > 0 && angleValue < 180)
            {
                AngleValue = angleValue;
            }
            else
            {
                throw new ArgumentException("AngleValue must be positive and more than 0");
            }
            if (firstSideLength > 0)
            {
                FirstSideLength = firstSideLength;
            }
            else
            {
                throw new ArgumentException("FirstSideLength must be positive and more than 0");
            }
            if (secondSideLength > 0)
            {
                SecondSideLength = secondSideLength;
            }
            else
            {
                throw new ArgumentException("SecondSideLength must be positive and more than 0");
            }
        }

        internal override string GetInfo()
        {
            return $"Triangle, Coordinates X = {X}, Y = {Y}; FirstSideLength = {FirstSideLength}; SecondSideLength = {SecondSideLength}; " +
                              $"Square = {GetSquare}; Perimeter = {GetPerimeter}.";
        }
    }
}

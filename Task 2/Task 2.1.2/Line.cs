using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Line : Figure
    {
        protected double LineLength { get; set; }

        public Line(double x, double y, double lineLength) : base(x, y)
        {
            LineLength = 1;
            if (lineLength > 0)
            {
                LineLength = lineLength;
            }
            else
            {
                throw new ArgumentException("LineLength must be positive and more than 0");
            }
        }

        internal override string GetInfo()
        {
            return $"Line, Coordinates X = {X}, Y = {Y}; LineLength = {LineLength}.";
        }
    }
}

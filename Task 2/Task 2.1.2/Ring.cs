using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Ring : Figure
    {
        protected double InnerRadius { get; set; } = 1;
        protected double OuterRadius { get; set; } = 1;
        protected double GetSquare => Math.PI * (Math.Pow(OuterRadius, 2) - Math.Pow(InnerRadius, 2));
        protected double GetInnerAndOuterLength => 2 * OuterRadius * Math.PI + 2 * InnerRadius * Math.PI;

        public Ring(double x, double y, double innerRadius, double outerRadius) : base(x, y)
        {
            if ((innerRadius > 0) && (innerRadius < outerRadius))
            {
                InnerRadius = innerRadius;
            }
            else
            {
                throw new ArgumentException("The inner radius must be positive and less than the outer radius");
            }

            if ((outerRadius > 0) && (outerRadius > innerRadius))
            {
                OuterRadius = outerRadius;
            }
            else
            {
                throw new ArgumentException("The outer radius must be positive and larger than the inner radius");
            }
        }

        internal override string GetInfo()
        {
            return $"Ring, Coordinates X = {X}, Y = {Y}; InnerRadius = {InnerRadius}; OuterRadius = {OuterRadius}; Square = {GetSquare}; " +
                              $"Summ of inner and outer length = {GetInnerAndOuterLength}.";
        }
    }
}

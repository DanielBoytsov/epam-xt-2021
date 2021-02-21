using System;

namespace Task_1._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            do
            {
                Console.WriteLine("Put the length of the rectangle here");
                if ((!double.TryParse(Console.ReadLine(), out a))|(a <= 0))
                {
                    Console.WriteLine("Put the correct value!");
                }
            } while (a <= 0);
            do
            {
                Console.WriteLine("Put the width of the rectangle here");
                if ((!double.TryParse(Console.ReadLine(), out b))|(b <= 0))
                {
                    Console.WriteLine("Put the correct value!");
                }
            } while (b <= 0);
            double s = a * b;
            Console.WriteLine($"Square of your rectangle = {s}");
        }
    }
}

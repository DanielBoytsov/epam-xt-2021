using System;

namespace Task_1._1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1000;
            Console.WriteLine($"Sum of all numbers less than 1000 and multiples of 3 and 5 = {Summ(a)}");
        }
        static int Summ(int a)
        {
            int summ = 0;
            do
            {
                a--;
                if ((a % 3 == 0) || (a % 5 == 0))
                {
                    summ += a;
                }

            } while (a > 0);
            return summ;
        }
    }
}

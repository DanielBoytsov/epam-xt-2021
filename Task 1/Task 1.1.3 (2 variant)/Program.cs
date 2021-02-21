using System;
using System.Text;

namespace Task_1._1._3__2_variant_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Put here the number of lines");
            int a = Convert.ToInt32(Console.ReadLine());
            Pyramid(a);
        }

        static void Pyramid(int a)
        {
            StringBuilder str = new StringBuilder("*");
            for (int i = 0; i < a; i++)
            {
                for (int j = a; j > i + 1; j--)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(str);
                str.Append("**");
            }
        }
    }
}

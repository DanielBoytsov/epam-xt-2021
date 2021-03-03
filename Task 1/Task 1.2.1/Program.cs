using System;
using System.Data;

namespace Task_1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input your text here");
            string text = Console.ReadLine();
            Console.WriteLine($"Average words length = {AverageLength(text):f1}"); // Округляю до десятых.
        }

        public static double AverageLength(string text)
        {
            double a = 0;
            double n = 0;
            string[] split = text.Split(new Char[] { ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in split)
            {
                a++;
                n += item.Length;
            }

            double q = n / a;
            return q;
        }
    }
}

using System;

namespace Task_1._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string b = "*";
            Console.WriteLine("Put here number of lines");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                
                Console.WriteLine(b);
                b += "*";
            }
         
        }
    }
}

using System;
using System.Text;

namespace Task_1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Put here the number of triangles");
            int a = Convert.ToInt32(Console.ReadLine());
            Tree(a);
        }
        
        static void Tree(int a)
        {
            StringBuilder str = new StringBuilder("*");
            for (int k = 0; k < a; k++)
            {
                for (int i = 0; i <= k; i++)
                {
                    for (int j = a; j > i + 1; j--)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(str);
                    str.Append("**");
                }
                str.Remove(0,str.Length-1);
            }
        }
    }
}

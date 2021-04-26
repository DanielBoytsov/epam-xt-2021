using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Put here the string, which you want to check.");
            string test = Console.ReadLine();

            Console.WriteLine(test.LanguageCheck());
        }
    }
    
}

using System;
using System.Text;

namespace Task_1._2._2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input the 1st string here");
            string first = Console.ReadLine();
            Console.WriteLine("Input the second string here");
            string second = Console.ReadLine();
            Console.WriteLine(Big(first,second));
            //Console.WriteLine(Small(first,second));
        }

        public static string Small(string first, string second)
        {
            string result = string.Empty;
            foreach (var item in first)
            {
                result += item;
                if(second.Contains(item))
                {
                    result += item;
                }
            }

            return result;
        }

        public static StringBuilder Big(string first, string second)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in first)
            {
                if(second.Contains(item))
                {
                    result.Append(item);
                }
                result.Append(item);
            }

            return result;
        }
    }
}

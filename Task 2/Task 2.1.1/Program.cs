using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CustomExtensions;

namespace Task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "GoodJobS";
            StringExtended text = new StringExtended(a);
            StringExtended test = new StringExtended("GoodJobS");
            Console.WriteLine(text.GetHashCode());
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(text.Equals(a));
            Console.WriteLine(text.Equals(test));
            Console.WriteLine(test == a);
            Console.WriteLine(test != a);
            Console.WriteLine(test.Concatenate(a));
            var v = text + a;
            Console.WriteLine(v);
            Console.WriteLine(text.Contains('w'));
            Console.WriteLine(text.IndexOf('o'));
            Console.WriteLine(text.IndexOfAll('o'));
            List<int> ab = text.IndexOfAll('o');
            for (int i = 0; i < ab.Count; i++)
            {
                Console.WriteLine(ab[i]);
            }
        }
    }
}

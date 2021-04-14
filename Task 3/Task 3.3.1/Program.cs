using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[] { 1,2,3,4,5,6,7,8,9,0,1, };

            Func<int,int> func = new(GetSquare);

            //Console.WriteLine(mass.MostCommonElement());

            mass.ActionsWithArray(func);

            func += GetMultiply;

            foreach (var item in mass)
            {
                Console.WriteLine(item);
            }
        }

        static int GetSquare(int value) =>  value * value;

        static int GetMultiply(int value) => value * 5;
    }

    internal static class AdditionalArray
    {
        public static T Sum<T>(this IEnumerable<T> mass) => Sum(mass);

        public static T Average<T>(this IEnumerable<T> mass) => Average(mass);

        public static T MostCommonElement<T>(this IEnumerable<T> mass) => mass.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
        public static void ActionsWithArray(this int[] mass, Func<int,int> func)
        {
            if (func is not null)
                for (int i = 0; i < mass.Length; i++)
                    mass[i] = func.Invoke(mass[i]);
        }
    }
}

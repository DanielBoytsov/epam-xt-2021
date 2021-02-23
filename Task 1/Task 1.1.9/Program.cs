using System;

namespace Task_1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = GetRandomArr(10);
            Console.WriteLine($"Summ of all positive elements = {PositiveSumm(arr)}");
        }
        public static int[] GetRandomArr(int a)
        {
            int[] arr = new int[a];
            Console.WriteLine("Array :");
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
                Console.WriteLine($"{i} = {arr[i]}");
            }
            return arr;
        }
        public static int PositiveSumm(int[] arr)
        {
            int summ = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                summ += (arr[i] > 0) ? arr[i] : 0; 
            }
            return summ;
        }
    }
}

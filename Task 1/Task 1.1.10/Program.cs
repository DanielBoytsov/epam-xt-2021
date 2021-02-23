using System;

namespace Task_1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = GetRandomArr(4, 4);
            Console.WriteLine($"Sum of even elements = {EvenSumm(arr)}");
        }
        public static int[,] GetRandomArr(int a, int b)
        {
            int[,] arr = new int[a, b];
            Console.WriteLine("Array :");
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);
                    Console.WriteLine($"{i} {j} = {arr[i,j]}");
                }
            }
            return arr;
        }
        public static int EvenSumm(int[,] arr)
        {
            int summ = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    summ += ((i + j) % 2 == 0) ? arr[i, j] : 0;
                }
            }
            return summ;
        }
    }
}

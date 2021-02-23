using System;

namespace Task_1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] arr = GetRandomArr(2, 2, 2);
            NoPositive(arr);
            ArrOutput(arr);
        }
        public static int[,,] GetRandomArr(int a, int b, int c)
        {
            int[,,] arr = new int[a, b, c];
            Console.WriteLine("Stock array :");
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        arr[i, j, z] = rnd.Next(-100, 100);
                        Console.WriteLine(arr[i, j, z]);
                    }
                }
            }
            return arr;
        }
        public static int[,,] NoPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        arr[i, j, z] = (arr[i, j, z] > 0) ? 0 : arr[i,j,z];                        
                    }
                }
            }
            return arr;
        }
        public static void ArrOutput(int[,,] arr)
        {
            Console.WriteLine("Sad array :");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        Console.WriteLine(arr[i,j,z]);
                    }
                }
            }
        }
    }
}

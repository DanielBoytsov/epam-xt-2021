using System;

namespace Task_1._1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Types a = 0;
            for (; ; )
            {
                Console.WriteLine($"Font types: {a}" +
                                   "\nPut: " +
                                            "\n1: bold" +
                                            "\n2: italic" +
                                            "\n3: underline");
                int b = int.Parse(Console.ReadLine());
                if (b == 3)
                {
                    b = 4;
                }
                if (!a.HasFlag((Types)b))
                {
                    a |= (Types)b;
                }
                else
                {
                    a ^= (Types)b;
                }
            }
        }
        [Flags]

        enum Types : int
        {
            None = 0,
            bold = 1,
            italic = 2,
            underline = 4,
        }
    }
}

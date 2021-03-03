using System;
using System.Linq;


namespace Task_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input your text here");
            string text = Console.ReadLine();
            Console.WriteLine($"{CheckLowercase(text)} words start with a lowercase");
        }

        public static int CheckLowercase(string text)
        {
            int a = 0;
            string[] split = text.Split(new char[] { ',', '.', '!', '?', ' ', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in split)
            {
                if (char.IsLower(item[0]))
                {
                    a++;
                }
            }

            return a;
        }
    }
}

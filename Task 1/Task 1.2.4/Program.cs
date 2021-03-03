using System;
using System.Globalization;
using System.Text;
namespace Task_1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input your text here");
            string text = Console.ReadLine();
            Console.WriteLine(CapitalLetter(text));
        }

        public static string CapitalLetter(string text)
        {
            bool flag = true;
            StringBuilder name = new StringBuilder(text);
            for (int i = 0; i < text.Length; i++)
            {
                if (CheckMark(name[i]))
                {
                    flag = true;
                }
                if (flag && char.IsLetter(text[i]))
                {
                    name.Replace(text[i], char.ToUpper(text[i]), i, 1);
                    flag = false;
                }
            }

            return name.ToString();
        }
            
        /// <summary>
        /// Сhecking a string element for marks
        /// </summary>
        /// <param name="a"></param>
        /// <returns>bool</returns>
        public static bool CheckMark(char a)
        {
            if ((a == '.') | (a == '!') | (a == '?'))
            {
                return true;
            }

            return false;
        }
    }
}

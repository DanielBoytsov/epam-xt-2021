using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Daniel";

            Console.WriteLine(test.LanguageCheck());
        }
    }
    internal static class AdditionalString
    {
        public static string LanguageCheck(this string text)
        {
            if (text is not null && text != String.Empty)
            {
                string[] splitText = text.Split(new char[] { ',', '.', '!', '?', ' ', ':', ';', '[', ']', '"', '{', '}', '-', '\n', '\r', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (splitText.Length == 1)
                {

                    if (Regex.IsMatch(splitText[0], @"([0-9]){0,}"))
                    {
                        return "Numbers";
                    }

                    if (Regex.IsMatch(splitText[0], @"([А-ЯЁа-яё]){0,}"))
                    {
                        return "Russian";
                    }

                    if (Regex.IsMatch(splitText[0], @"([A-z]){0,}"))
                    {
                        return "English";
                    }
                    if (Regex.IsMatch(splitText[0], @"([А - ЯЁа - яё][A - Za - z]\d){0,}"))
                    {
                        return "Mixed";
                    }
                }

                else
                {

                    {
                        return "Mixed";
                    }
                }
            }
            throw new NullReferenceException(message: "Your reference is null, or you put an empty string");
        }
    }
}

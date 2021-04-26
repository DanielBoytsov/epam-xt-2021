using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3._3._2
{
    internal static class AdditionalString
    {
        public static string LanguageCheck(this string text)
        {
            if (text is not null && text != String.Empty)
            {
                string[] splitText = text.Split(new char[] { ',', '.', '!', '?', ' ', ':', ';',
                    '[', ']', '"', '{', '}', '-', '\n', '\r', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (splitText.Length == 1)
                {

                    if (Regex.IsMatch(splitText[0], @"^\d+$"))
                    {
                        return "Numbers";
                    }

                    if (Regex.IsMatch(splitText[0], @"^[А-ЯЁа-яё]+$"))
                    {
                        return "Russian";
                    }

                    if (Regex.IsMatch(splitText[0], @"^[A-z]+$"))
                    {
                        return "English";
                    }
                    if (Regex.IsMatch(splitText[0], @"(\d|[A-z]|[А-Яа-я])+"))
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

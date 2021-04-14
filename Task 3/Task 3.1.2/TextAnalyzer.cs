using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._1._2
{
    public static class TextAnalyzer
    {
        //public string[] SplitText { get; set; }
        //public string[] WordsCount { get; set; }
        public static string[] SplittingText(string text)
        {
            string[] splitText = text.Split(new char[] { ',', '.', '!', '?', ' ', ':', ';', '[',']','"','{','}','-', '\n','\r','(',')' },
                StringSplitOptions.RemoveEmptyEntries);
            
            return splitText;
        }

        public static Dictionary<string, int> WordsCount(string[] splitText)
        {

            var words = new Dictionary<string, int>();

            foreach (var item in splitText)
            {
                words.TryGetValue(item, out int count);
                words[item] = count + 1;
            }
            var s = words.Count();
            var a = splitText.Length;
            Console.WriteLine(s);
            Console.WriteLine(a);
            return words;
        }
        public static void GetStatistics(string[] splitText, Dictionary<string, int> words)
        {
            if ((((double)words.Count) / ((double)splitText.Length)) > 0.5)
            {
                Console.WriteLine("Your text is suitable for publication, you are great =)" + Environment.NewLine + 
                    $"There are {splitText.Length} words in your text in total, {words.Count} of them are unique");
            }
            else
            {
                Console.WriteLine("You need to do a little more work on the text before publishing it. Do not despair =)" + Environment.NewLine +
                    $"There are {splitText.Length} words in your text in total, {words.Count} of them are unique" + Environment.NewLine +
                    $"Try to replace the following words in your text: ");
            }
        }
    }
}

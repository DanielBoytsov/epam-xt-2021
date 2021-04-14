using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Task_3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Enter a link to your file here");
            var text = (File.ReadAllText(Console.ReadLine()));
            var splitText = TextAnalyzer.SplittingText(text);
            var result = TextAnalyzer.WordsCount(splitText);

            foreach (var item in result.OrderByDescending(item => item.Value))
            {
                Console.WriteLine($"Word:{item.Key} - {item.Value} meetings");
            }

            TextAnalyzer.GetStatistics(splitText, result);
        }

    }
}

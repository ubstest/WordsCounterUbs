using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounterUbs
{
    class Program
    {
        static void Main()
        {
            string inputDefault = "This is a statement, and so is this.";

            Console.WriteLine("Write sentence and press <Enter>");
            Console.WriteLine($"Default sentence is: '{inputDefault}'");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                input = inputDefault;

            var stats = GetTextStatistics(input);

            Console.WriteLine();
            Console.WriteLine("Output:");
            foreach (var s in stats)
                Console.WriteLine($"{s.Key.ToLower()} - {s.Value}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static Dictionary<string, int> GetTextStatistics(string input)
        {
            //return Regex.Split(input, @"[^A-Za-z0-9_'-]+")
            return Regex.Split(input, @"\W+")
                .Where(x => !string.IsNullOrEmpty(x))
                .GroupBy(x => x, StringComparer.CurrentCultureIgnoreCase)
                .Select(x => new { word = x.Key, count = x.Count() })
                .ToDictionary(x => x.word, x => x.count);
        }
    }
}

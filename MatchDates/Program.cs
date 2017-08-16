using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\b(?<day>\d{2})(?<separator>[\.\/\-])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b");

            string text = Console.ReadLine();

            MatchCollection mathCollection = pattern.Matches(text);

            foreach (Match m in mathCollection)
            {
                var day = m.Groups["day"].Value;
                var month = m.Groups["month"].Value;
                var year = m.Groups["year"].Value;

                Console.WriteLine("Day: {0}, Month: {1}, Year: {2}",day,month,year);
            }
            Console.WriteLine();
        }
    }
}

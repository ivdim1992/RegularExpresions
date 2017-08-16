using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\b(0x)?[0-9A-F]+\b");

            string text = Console.ReadLine();

            MatchCollection matches = pattern.Matches(text);

            foreach (Match m in matches)
            {
                Console.Write(m + " ");
            }
            Console.WriteLine();
        }
    }
}

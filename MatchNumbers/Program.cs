using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))");

            string text = Console.ReadLine();

            MatchCollection mathCollection = pattern.Matches(text);

            foreach (Match m in mathCollection)
            {
                Console.Write(m + " ");
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex("[A-Z][a-z]+ [A-Z][a-z]+\\b");

            string names = Console.ReadLine();

            MatchCollection matches =  pattern.Matches(names);

            foreach (Match m in matches)
            {
                Console.Write(m.Groups[0] + " ");
            }
            Console.WriteLine();
        }
    }
}

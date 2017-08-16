using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MatchPhonNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\+359([ -])2\1\d{3}\1\d{4}\b");
            string number = Console.ReadLine();

            MatchCollection matcheCollection = pattern.Matches(number);

            List<Match> matches = matcheCollection
                .Cast<Match>()
                .ToList();

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}

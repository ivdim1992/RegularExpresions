using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FishStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex fishPattern = new Regex(@">*<\(+['\-x]>");

            string input = Console.ReadLine();

          MatchCollection fishes =  fishPattern.Matches(input);

            int fishIndex = 1;
            foreach (Match m in fishes)
            {
                string fish = m.Value;

                int tailSize = 0;
                int bodySize = 0;
                string status = "";

                
                foreach (var part in fish)
                {
                    if (part == '>')
                    {
                        tailSize++;
                    }
                    else if (part == '(')
                    {
                        bodySize++;
                    }
                    else if (part == '\'')
                    {
                        status = "Awake";
                    }
                    else if (part == '-')
                    {
                        status = "Asleep";
                    }
                    else if (part == 'x')
                    {
                        status = "Dead";
                    }
                }
                tailSize--;
                string tailType = GetTailType(tailSize);
                string bodyType = GetBodyType(bodySize);
                Console.WriteLine("Fish {0}: {1}",fishIndex,fish);
                
                
                Console.Write("  Tail type: {0}",tailType);
                if (tailType != "None")
                {
                    Console.WriteLine(" ({0} cm)",tailSize * 2);
                }
                else
                {
                    Console.WriteLine();
                }
                

                
                Console.WriteLine("  Body type: {0} ({1} cm)",bodyType,bodySize * 2);
                Console.WriteLine("  Status: {0}",status);

                fishIndex++;
            }
            if (fishIndex == 1)
            {
                Console.WriteLine("No fish found.");
            }
        }

        static string GetTailType(int tailSize)
        {
            if (tailSize > 5)
            {
                return "Long";
            }
            else if (tailSize > 1)
            {
                return "Medium";
            }
            else if (tailSize == 1)
            {
                return "Short";
            }
            else
            {
                return "None";
            }
        }


        static string GetBodyType(int bodySize)
        {
            if (bodySize > 10)
            {
                return "Long";
            }
            else if (bodySize > 5)
            {
                return "Medium";
            }
            else
            {
                return "Short";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetCom
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> privateMessage = new List<string>();
            List<string> broadcast = new List<string>();

            string input = Console.ReadLine();

            while (input != "Hornet is Green")
            {
                string[] tokens = input
                    .Split(new string[] { " <-> " }
                            , StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length != 2)
                {
                    tokens = input
                    .Split(new string[] { " <-> " }
                            , StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                var leftQuery = tokens[0];
                var rightQuery = tokens[1];

                if (leftQuery.All(char.IsDigit) && rightQuery.All(char.IsLetterOrDigit))
                {
                    string reversed = new string (leftQuery.ToCharArray().Reverse().ToArray());
                    privateMessage.Add($"{reversed} -> {rightQuery}");
                }
                else if (leftQuery.All(c => !char.IsDigit(c)) && rightQuery.All(char.IsLetterOrDigit))
                {
                    string frequency = ReversedCapital(rightQuery);
                    broadcast.Add($"{frequency} -> {leftQuery}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            Console.WriteLine(broadcast.Count == 0 ? "None" : string.Join(Environment.NewLine,broadcast));
            Console.WriteLine("Messages:");
            Console.WriteLine(privateMessage.Count == 0 ? "None" : string.Join(Environment.NewLine,privateMessage));
        }

        private static string ReversedCapital(string rightQuery)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rightQuery.Length; i++)
            {
                if (char.IsUpper(rightQuery[i]))
                {
                    result.Append(char.ToLower(rightQuery[i]));
                }
                else if (char.IsLower(rightQuery[i]))
                {
                    result.Append(char.ToUpper(rightQuery[i]));
                }
                else
                {
                    result.Append(rightQuery[i]);
                }
            }
            return result.ToString();
        }
    }
}

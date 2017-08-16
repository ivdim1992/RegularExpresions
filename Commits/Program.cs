using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Commits
{
    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }

        public Commit(string hash, string message, int additions, int deletions)
        {
            this.Hash = hash;
            this.Message = message;
            this.Additions = additions;
            this.Deletions = deletions;
        }

        public override string ToString()
        {
            string result = string.Format("    commit {0}: {1} ({2} additions, {3} deletions)",
                this.Hash,
                this.Message,
                this.Additions,
                this.Deletions);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Regex urlPattern = new Regex(@"^https:\/\/github\.com\/(?<user>[A-Za-z0-9-]+)\/(?<repo>[A-Za-z-_]+)\/commit\/(?<hash>[a-fA-F0-9]{40}),(?<message>[^\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)$");

            var data =new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();

            string input = Console.ReadLine();

            while (input != "git push")
            {
                if (urlPattern.IsMatch(input))
                {
                    Match m = urlPattern.Match(input);

                    string user = m.Groups["user"].Value;
                    string repo = m.Groups["repo"].Value;
                    string hash = m.Groups["hash"].Value;
                    string message = m.Groups["message"].Value;
                    int additions = int.Parse(m.Groups["additions"].Value);
                    int delitions = int.Parse(m.Groups["deletions"].Value);

                    Commit commit = new Commit(hash,message,additions,delitions);

                    if (!data.ContainsKey(user))
                    {
                        data.Add(user, new SortedDictionary<string,List<Commit>>());
                    }
                    if (!data[user].ContainsKey(repo))
                    {
                        data[user].Add(repo, new List<Commit>());
                    }
                    data[user][repo].Add(commit);


                }

                input = Console.ReadLine();
            }

            foreach (var userData in data)
            {
                string user = userData.Key;
                var reposData = userData.Value;

                Console.WriteLine("{0}:",user);
                foreach (var repoData in reposData)
                {
                    string repo = repoData.Key;
                    List<Commit> commits = repoData.Value;

                    Console.WriteLine("  {0}:",repo);


                    var totalAdditions = commits.Sum(c => c.Additions);
                    var totalDeletions = commits.Sum(d => d.Deletions);
                    foreach (Commit commit in commits)
                    {
                        Console.WriteLine(commit);
                    }
                    Console.WriteLine("     Total: {0} additions, {1} deletions",totalAdditions,totalDeletions);
                }
            }
        }
    }
}

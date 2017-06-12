namespace _09E.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class UserLogs
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var users = new SortedDictionary<string, Dictionary<string, int>>();
            var regex = new Regex(@"^IP=([^\s]+) message=[^\s]+ user=(\w+)$");

            while (inputLine != "end")
            {
                var match = regex.Match(inputLine);

                if (match.Success)
                {
                    var userName = match.Groups[2].Value;
                    var ipAdress = match.Groups[1].Value;

                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, new Dictionary<string, int>());
                    }

                    if (!users[userName].ContainsKey(ipAdress))
                    {
                        users[userName].Add(ipAdress, 1);
                    }
                    else
                    {
                        users[userName][ipAdress]++;
                    }
                }

                inputLine = Console.ReadLine();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");

                var counter = user.Value.Count;

                foreach (var ip in user.Value)
                {
                    if (counter > 1)
                    {
                        Console.Write($"{ip.Key} => {ip.Value}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{ip.Key} => {ip.Value}.");
                    }

                    counter--;
                }
            }
        }
    }
}
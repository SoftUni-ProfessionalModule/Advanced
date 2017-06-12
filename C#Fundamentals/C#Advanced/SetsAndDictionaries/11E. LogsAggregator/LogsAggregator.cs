namespace _11E.LogsAggregator
{
    using System;
    using System.Collections.Generic;

    public class Data
    {
        public SortedSet<string> IP { get; set; }

        public int Duration { get; set; }
    }
    public class LogsAggregator
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var users = new SortedDictionary<string, Data>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var currentLineParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = currentLineParams[1];
                var currentIP = currentLineParams[0];
                var currentDuration = int.Parse(currentLineParams[2]);

                if (!users.ContainsKey(name))
                {
                    users.Add(name, new Data { IP = new SortedSet<string> { currentIP }, Duration = currentDuration });
                }
                else
                {
                    users[name].IP.Add(currentIP);
                    users[name].Duration += currentDuration;
                }

            }

            foreach (var user in users)
            {
                var name = user.Key;

                Console.WriteLine($"{user.Key}: {user.Value.Duration} [{string.Join(", ", user.Value.IP)}]");
            }
        }
    }
}
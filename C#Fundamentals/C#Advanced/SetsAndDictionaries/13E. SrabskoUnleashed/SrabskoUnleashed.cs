namespace _13E.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SrabskoUnleashed
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var regexPattern = @"^([A-Za-z]+\s?[A-Za-z]*\s?[A-Za-z]*) @([A-Za-z]+\s?[A-Za-z]*\s?[A-Za-z]*) (\d+) (\d+)$";
            var lineValidation = new Regex(regexPattern);
            var venueAndSinger = new Dictionary<string, Dictionary<string, int>>();

            while (inputLine != "End")
            {
                var match = lineValidation.Match(inputLine);

                if (match.Success)
                {
                    var currentSingerName = match.Groups[1].Value;
                    var currentVenue = match.Groups[2].Value;
                    var ticketPrice = int.Parse(match.Groups[3].Value);
                    var ticketsCount = int.Parse(match.Groups[4].Value);

                    if (!venueAndSinger.ContainsKey(currentVenue))
                    {
                        venueAndSinger.Add(currentVenue, new Dictionary<string, int>());
                    }
                    if (!venueAndSinger[currentVenue].ContainsKey(currentSingerName))
                    {
                        venueAndSinger[currentVenue].Add(currentSingerName, 0);
                    }

                    venueAndSinger[currentVenue][currentSingerName] += ticketPrice * ticketsCount;
                }


                inputLine = Console.ReadLine();
            }

            foreach (var venue in venueAndSinger)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
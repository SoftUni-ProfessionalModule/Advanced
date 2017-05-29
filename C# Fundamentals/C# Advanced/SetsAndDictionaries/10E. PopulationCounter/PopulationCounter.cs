namespace _10E.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var countryAndTown = new Dictionary<string, Dictionary<string, long>>();

            while (inputLine != "report")
            {
                var inputParams = inputLine.Split('|');
                var currentTown = inputParams[0];
                var currentCountry = inputParams[1];
                var currentPopulation = long.Parse(inputParams[2]);

                if (!countryAndTown.ContainsKey(currentCountry))
                {
                    countryAndTown.Add(currentCountry, new Dictionary<string, long>());
                }

                if (!countryAndTown[currentCountry].ContainsKey(currentTown))
                {
                    countryAndTown[currentCountry].Add(currentTown, currentPopulation);
                }

                inputLine = Console.ReadLine();
            }

            foreach (var country in countryAndTown.OrderByDescending(x => x.Value.Values.Sum()))
            {
                long totalPopulation = country.Value.Values.Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                foreach (var town in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }
        }
    }
}
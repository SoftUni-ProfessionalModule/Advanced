namespace _08L.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class City
    {
        public List<long> Population { get; set; }

        public long PopulationSum { get; set; }
    }
    public class MapDistricts
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var minPopulationNumber = long.Parse(Console.ReadLine());

            var cityAndPopulationDict = new Dictionary<string, City>();

            foreach (var input in inputLine)
            {
                var citiesDetails = input.Split(':');

                var cityName = citiesDetails[0];
                var currentDistrictPopulation = int.Parse(citiesDetails[1]);

                if (!cityAndPopulationDict.ContainsKey(cityName))
                {
                    cityAndPopulationDict.Add(cityName, new City());
                    cityAndPopulationDict[cityName].Population = new List<long>();
                }

                cityAndPopulationDict[cityName].Population.Add(currentDistrictPopulation);
                cityAndPopulationDict[cityName].PopulationSum += currentDistrictPopulation;
            }

            cityAndPopulationDict = cityAndPopulationDict
                .Where(c => c.Value.PopulationSum > minPopulationNumber)
                .OrderByDescending(c => c.Value.PopulationSum)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var city in cityAndPopulationDict)
            {
                Console.Write($"{city.Key}: ");
                foreach (var district in city.Value.Population.OrderByDescending(p => p).Take(5))
                {
                    Console.Write($"{district} ");
                }

                Console.WriteLine();
            }
        }
    }
}
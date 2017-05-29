namespace _12E.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            var items = new SortedDictionary<string, int>();
            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            var junkItems = new SortedDictionary<string, int>();
            var isWinnerFound = false;

            while (true)
            {
                var inputParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputParams.Length - 1; i += 2)
                {
                    var quantity = int.Parse(inputParams[i]);
                    var material = inputParams[i + 1].ToLower();

                    if (material == "shards")
                    {
                        items["shards"] += quantity;

                        if (items["shards"] >= 250)
                        {
                            items["shards"] -= 250;

                            Console.WriteLine("Shadowmourne obtained!");
                            isWinnerFound = true;
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        items["fragments"] += quantity;

                        if (items["fragments"] >= 250)
                        {
                            items["fragments"] -= 250;

                            Console.WriteLine("Valanyr obtained!");
                            isWinnerFound = true;
                            break;
                        }
                    }
                    else if (material == "motes")
                    {
                        items["motes"] += quantity;

                        if (items["motes"] >= 250)
                        {
                            items["motes"] -= 250;

                            Console.WriteLine("Dragonwrath obtained!");
                            isWinnerFound = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems.Add(material, 0);
                        }

                        junkItems[material] += quantity;
                    }

                }

                if (isWinnerFound)
                {
                    foreach (var item in items.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    foreach (var junkItem in junkItems)
                    {
                        Console.WriteLine($"{junkItem.Key}: {junkItem.Value}");
                    }

                    return;
                }
            }
        }
    }
}
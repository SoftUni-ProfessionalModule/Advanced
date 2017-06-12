namespace _06E.MinersTask
{
    using System;
    using System.Collections.Generic;

    public class MinersTask
    {
        public static void Main()
        {
            var resources = new Dictionary<string, long>();

            var currentResource = Console.ReadLine();

            while (currentResource != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(currentResource))
                {
                    resources.Add(currentResource, quantity);
                }
                else
                {
                    resources[currentResource] += quantity;
                }

                currentResource = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
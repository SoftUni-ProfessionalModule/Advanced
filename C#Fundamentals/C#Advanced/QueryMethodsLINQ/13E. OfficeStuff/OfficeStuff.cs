namespace _13E.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var companiesAndProducts = new SortedDictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var lineParams = Console.ReadLine()
                    .Split(new[] { '-', ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                var company = lineParams[0];
                var quantity = long.Parse(lineParams[1]);
                var product = lineParams[2];

                if (!companiesAndProducts.ContainsKey(company))
                {
                    companiesAndProducts.Add(company, new Dictionary<string, long>());
                }
                if (!companiesAndProducts[company].ContainsKey(product))
                {
                    companiesAndProducts[company].Add(product, 0);
                }

                companiesAndProducts[company][product] += quantity;
            }

            foreach (var company in companiesAndProducts)
            {
                Console.Write($"{company.Key}: ");

                Console.WriteLine(string.Join(", ", company.Value.Select(x => $"{x.Key} - {x.Value}")));
            }
        }
    }
}
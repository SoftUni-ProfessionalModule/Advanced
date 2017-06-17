namespace _10E.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        public string Name { get; set; }

        public int Group { get; set; }
    }
    public class GroupByGroup
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var grouping = new List<Person>();

            while (inputLine != "END")
            {
                var personNamesArr = inputLine.Split().Take(2).ToArray();
                var group = inputLine.Split().Skip(2).Select(int.Parse).ToArray();
                var personName = personNamesArr[0] + " " + personNamesArr[1];
                grouping.Add(new Person { Name = personName, Group = group[0] });

                inputLine = Console.ReadLine();
            }

            var results = grouping.GroupBy(p => p.Group, p => p.Name, (key, g) => new { group = key, name = g.ToList() }).ToList();

            foreach (var item in results.OrderBy(x => x.group))
            {
                Console.WriteLine($"{item.group} - {string.Join(", ", item.name)}");
            }
        }
    }
}
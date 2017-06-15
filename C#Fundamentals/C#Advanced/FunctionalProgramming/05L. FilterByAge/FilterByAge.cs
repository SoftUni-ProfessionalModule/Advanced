namespace _05L.FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class FilterByAge
    {
        public static void Main()
        {
            var numberOfPairs = int.Parse(Console.ReadLine());
            var personsAndAge = new Dictionary<string, int>();

            for (int i = 0; i < numberOfPairs; i++)
            {
                var inputLine = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var currentName = inputLine[0];
                var currentAge = int.Parse(inputLine[1]);

                if (personsAndAge.ContainsKey(currentName))
                {
                    personsAndAge.Add(currentName, 0);
                }

                personsAndAge[currentName] = currentAge;
            }

            var condition = Console.ReadLine();

            var age = int.Parse(Console.ReadLine());

            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(personsAndAge, tester, printer);
        }

        public static void PrintFilteredStudent(Dictionary<string, int> personsAndAge, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in personsAndAge)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            }
        }

        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }
        }
    }
}
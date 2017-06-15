namespace _12E.Inferno
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inferno
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            gems.Insert(0, 0);
            gems.Insert(gems.Count, 0);
            var commandsForFilters = Console.ReadLine();

            var indexesOfMarkedGems = new HashSet<int>();
            var commandsList = new List<string>();

            while (commandsForFilters != "Forge")
            {
                var commandParams = commandsForFilters.Split(';');

                AddOrRemoveCommand(commandParams, commandsList);

                commandsForFilters = Console.ReadLine();
            }

            foreach (var command in commandsList)
            {
                var commandParams = command.Split(';');

                GetDirection(commandParams, indexesOfMarkedGems, gems);
            }

            foreach (var index in indexesOfMarkedGems)
            {
                gems[index] = 0;
            }

            Console.WriteLine(string.Join(" ", gems.Where(x => x != 0)));
        }

        public static void GetDirection(string[] commandParams, HashSet<int> indexesOfMarkedGems, List<int> gems)
        {
            var directions = commandParams[0];
            var filter = int.Parse(commandParams[1]);

            Func<int, int, bool> isEqual = (x, y) => x == y;

            switch (directions)
            {
                case "Sum Left":
                    SumLeft(filter, gems, indexesOfMarkedGems, isEqual);
                    break;
                case "Sum Right":
                    SumRight(filter, gems, indexesOfMarkedGems, isEqual);
                    break;
                case "Sum Left Right":
                    SumLeftRight(filter, gems, indexesOfMarkedGems, isEqual);
                    break;
            }
        }

        public static void SumLeftRight(int filter, List<int> gems, HashSet<int> indexesOfMarkedGems, Func<int, int, bool> isEqual)
        {
            for (int i = 1; i < gems.Count - 1; i++)
            {
                var currentSum = gems[i - 1] + gems[i];
                currentSum += gems[i + 1];
                if (isEqual(currentSum, filter))
                {
                    indexesOfMarkedGems.Add(i);
                }
            }
        }

        public static void SumRight(int filter, List<int> gems, HashSet<int> indexesOfMarkedGems, Func<int, int, bool> isEqual)
        {
            for (int i = 2; i < gems.Count; i++)
            {
                var currentSum = gems[i - 1] + gems[i];
                if (isEqual(currentSum, filter))
                {
                    indexesOfMarkedGems.Add(i);
                }
            }
        }

        public static void SumLeft(int filter, List<int> gems, HashSet<int> indexesOfMarkedGems, Func<int, int, bool> isEqual)
        {
            for (int i = 1; i < gems.Count - 1; i++)
            {
                var currentSum = gems[i - 1] + gems[i];
                if (isEqual(currentSum, filter))
                {
                    indexesOfMarkedGems.Add(i);
                }
            }
        }

        public static void AddOrRemoveCommand(string[] commandParams, List<string> commandsList)
        {
            var addOrRemoveCommand = commandParams[0];
            var currentCommand = commandParams[1];
            var filter = commandParams[2];

            switch (addOrRemoveCommand)
            {
                case "Exclude":
                    commandsList.Add($"{currentCommand};{filter}");
                    break;

                case "Reverse":
                    commandsList.Remove($"{currentCommand};{filter}");
                    break;
            }
        }
    }
}
namespace _10E.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = Console.ReadLine();

            var originalListOfNames = new List<string>();
            originalListOfNames.AddRange(names);

            while (command != "Party!")
            {
                var commandTokens = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var actionCommand = commandTokens[0];
                var commandType = commandTokens[1];
                var stringOrInt = commandTokens[2];

                Func<string, bool> tester = CheckCommand(commandType, stringOrInt);

                for (int i = names.Count - 1; i >= 0; i--)
                {
                    var name = names[i];

                    if (tester(name))
                    {
                        ApplyActionCommand(names, name, actionCommand);
                    }
                }

                command = Console.ReadLine();
            }

            var result = new List<string>();

            for (int i = 0; i < originalListOfNames.Count; i++)
            {
                var currentName = originalListOfNames[i];
                result.AddRange(names.Where(x => x == currentName));
            }

            Func<List<string>, bool> printType = x => x.Count != 0;

            if (printType(result))
            {
                Console.WriteLine(string.Join(", ", result) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static void ApplyActionCommand(List<string> names, string name, string actionCommand)
        {
            switch (actionCommand)
            {
                case "Double":
                    names.Add(name);
                    break;
                case "Remove":
                    names.Remove(name);
                    break;
            }
        }

        public static Func<string, bool> CheckCommand(string commandType, string stringOrInt)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return x => x.StartsWith(stringOrInt);
                case "EndsWith":
                    return x => x.EndsWith(stringOrInt);
                case "Length":
                    var length = int.Parse(stringOrInt);
                    return x => x.Length == length;

                default: return null;
            }
        }
    }
}
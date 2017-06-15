namespace _11E.PartyReservationModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationModule
    {
        public static void Main()
        {
            var invitedPersons = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var commandsForFilters = Console.ReadLine();
            var filtersList = new List<string>();

            while (commandsForFilters != "Print")
            {
                var filtersParams = commandsForFilters.Split(';');

                AddOrRemoveFilter(filtersParams, filtersList);

                commandsForFilters = Console.ReadLine();
            }

            foreach (var filter in filtersList)
            {
                var filterParams = filter.Split(';');
                var commandType = filterParams[0];
                var stringOrInt = filterParams[1];

                Func<string, bool> tester = ApplyCommand(commandType, stringOrInt);

                for (int i = invitedPersons.Count - 1; i >= 0; i--)
                {
                    var name = invitedPersons[i];

                    if (tester(name))
                    {
                        invitedPersons.Remove(name);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", invitedPersons));
        }

        private static Func<string, bool> ApplyCommand(string commandType, string stringOrInt)
        {

            switch (commandType)
            {
                case "Starts with":
                    return x => x.StartsWith(stringOrInt);
                case "Ends with":
                    return x => x.EndsWith(stringOrInt);
                case "Length":
                    var length = int.Parse(stringOrInt);
                    return x => x.Length == length;
                case "Contains":
                    return x => x.Contains(stringOrInt);
                default: return null;
            }
        }

        public static void AddOrRemoveFilter(string[] filtersParams, List<string> filtersList)
        {
            var addOrRemoveFilter = filtersParams[0];
            var currentFilter = filtersParams[1];
            var stringOrInt = filtersParams[2];

            switch (addOrRemoveFilter)
            {
                case "Add filter":
                    filtersList.Add($"{currentFilter};{stringOrInt}");
                    break;

                case "Remove filter":
                    filtersList.Remove($"{currentFilter};{stringOrInt}");
                    break;
            }
        }
    }
}
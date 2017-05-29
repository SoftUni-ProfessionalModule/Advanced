namespace _02L.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class SoftUniParty
    {
        public static void Main()
        {
            var incommingGuests = Console.ReadLine();

            var guests = new SortedSet<string>();

            while (incommingGuests != "PARTY")
            {
                guests.Add(incommingGuests);

                incommingGuests = Console.ReadLine();
            }

            var nonCameGuests = Console.ReadLine();

            while (nonCameGuests != "END")
            {
                if (guests.Count > 0 && guests.Contains(nonCameGuests))
                {
                    guests.Remove(nonCameGuests);
                }

                nonCameGuests = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var carNumbers = new SortedSet<string>();

            while (input != "END")
            {
                var tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var direction = tokens[0];
                var currentCarNumber = tokens[1];

                if (direction == "IN")
                {
                    carNumbers.Add(currentCarNumber);
                }
                else
                {
                    if (carNumbers.Count > 0)
                    {
                        carNumbers.Remove(currentCarNumber);
                    }
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Any())
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
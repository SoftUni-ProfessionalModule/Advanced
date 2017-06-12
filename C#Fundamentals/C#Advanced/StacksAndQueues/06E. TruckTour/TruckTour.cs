namespace _06E.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PetrolStation
    {
        public int Fuel;

        public int Distance;

        public int IndexOfPump;

        public PetrolStation(int fuel, int distance, int index)
        {
            this.Fuel = fuel;
            this.Distance = distance;
            this.IndexOfPump = index;
        }

    }
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stationsQueue = new Queue<PetrolStation>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                stationsQueue.Enqueue(new PetrolStation(tokens[0], tokens[1], i));
            }

            PetrolStation startStation = null;
            bool passAllStations = false;

            while (true)
            {
                var currentStation = stationsQueue.Dequeue();
                stationsQueue.Enqueue(currentStation);

                startStation = currentStation;
                var fuelLeft = currentStation.Fuel;

                while (fuelLeft >= currentStation.Distance)
                {
                    fuelLeft -= currentStation.Distance;
                    currentStation = stationsQueue.Dequeue();
                    stationsQueue.Enqueue(currentStation);

                    if (currentStation == startStation)
                    {
                        passAllStations = true;
                        break;
                    }

                    fuelLeft += currentStation.Fuel;
                }

                if (passAllStations)
                {
                    Console.WriteLine(startStation.IndexOfPump);
                    break;
                }
            }
        }
    }
}
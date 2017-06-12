namespace _11E.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            var numberOfPlants = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var daysPlantsDie = new int[numberOfPlants];
            var previousPlant = new Stack<int>();
            previousPlant.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                int lastDayDeath = 0;

                while (previousPlant.Count > 0 && plants[previousPlant.Peek()] >= plants[i])
                {
                    lastDayDeath = Math.Max(lastDayDeath, daysPlantsDie[previousPlant.Pop()]);
                }

                if (previousPlant.Count > 0)
                {
                    daysPlantsDie[i] = lastDayDeath + 1;
                }

                previousPlant.Push(i);
            }

            Console.WriteLine(daysPlantsDie.Max());
        }
    }
}
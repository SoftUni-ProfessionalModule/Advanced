namespace _14E.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Stats
    {
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
    }

    public class DragonArmy
    {
        const double defaultDamage = 45;
        const double defaultHealth = 250;
        const double defaultArmor = 10;

        public static void Main()
        {
            var numberOfDragons = int.Parse(Console.ReadLine());

            var dragons = new Dictionary<string, SortedDictionary<string, Stats>>();

            for (int i = 0; i < numberOfDragons; i++)
            {
                var dragonParams = Console.ReadLine().Split();

                var dragonType = dragonParams[0];
                var dragonName = dragonParams[1];
                var damage = int.Parse(dragonParams[2] == "null" ? "45" : dragonParams[2]);
                var health = int.Parse(dragonParams[3] == "null" ? "250" : dragonParams[3]);
                var armor = int.Parse(dragonParams[4] == "null" ? "10" : dragonParams[4]);

                CollectDragons(dragons, dragonType, dragonName, damage, health, armor);
            }

            PrintDragons(dragons);
        }

        static void PrintDragons(Dictionary<string, SortedDictionary<string, Stats>> dragons)
        {
            foreach (var type in dragons)
            {
                var avarageDamage = type.Value.Values.Average(x => x.Damage);
                var avarageHealth = type.Value.Values.Average(x => x.Health);
                var avarageArmor = type.Value.Values.Average(x => x.Armor);

                Console.WriteLine($"{type.Key}::({avarageDamage:f2}/{avarageHealth:f2}/{avarageArmor:f2})");

                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }

            }
        }

        static void CollectDragons(Dictionary<string, SortedDictionary<string, Stats>> dragons, string dragonType, string dragonName, double damage, double health, double armor)
        {
            if (!dragons.ContainsKey(dragonType))
            {
                dragons.Add(dragonType, new SortedDictionary<string, Stats>());
            }
            if (!dragons[dragonType].ContainsKey(dragonName))
            {
                dragons[dragonType].Add(dragonName, new Stats());
            }

            dragons[dragonType][dragonName].Damage = damage;
            dragons[dragonType][dragonName].Health = health;
            dragons[dragonType][dragonName].Armor = armor;
        }
    }
}
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
                var damageAsString = dragonParams[2];
                var healthAsString = dragonParams[3];
                var armorAsString = dragonParams[4];

                var damage = ParseStatsToDouble(damageAsString, defaultDamage);
                var health = ParseStatsToDouble(healthAsString, defaultHealth);
                var armor = ParseStatsToDouble(armorAsString, defaultArmor);

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

        static double ParseStatsToDouble(string currentStat, double defaultDamage)
        {
            double parsedValue = 0;

            if (double.TryParse(currentStat, out parsedValue))
            {
                return parsedValue;
            }
            else
            {
                return defaultDamage;
            }
        }
    }
}
namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonTrainer
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var trainersDict = new Dictionary<string, Trainer>();

            while (inputLine != "Tournament")
            {
                var inputParams = inputLine.Split(new[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
                var trainerName = inputParams[0];
                var pokemonName = inputParams[1];
                var element = inputParams[2];
                var health = double.Parse(inputParams[3]);

                if (!trainersDict.ContainsKey(trainerName))
                {
                    trainersDict.Add(trainerName, new Trainer(trainerName, new List<Pokemon>()));
                }

                trainersDict[trainerName].Pokemons.Add(new Pokemon(pokemonName, element, health));

                inputLine = Console.ReadLine();
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainersDict)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
                        {
                            trainer.Value.Pokemons[i].Health -= 10;

                            if (trainer.Value.Pokemons[i].Health <= 0)
                            {
                                trainer.Value.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                        
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainersDict.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
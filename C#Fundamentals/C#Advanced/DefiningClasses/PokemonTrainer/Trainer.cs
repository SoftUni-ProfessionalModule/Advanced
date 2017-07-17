namespace PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }
    }
}
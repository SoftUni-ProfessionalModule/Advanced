namespace Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Parent> parents = new List<Parent>();
        private List<Children> childrens = new List<Children>();
        private List<Pokemon> pokemons = new List<Pokemon>();

        public Person(string name)
        {
            this.name = name;
        }
        public string Name
        {
            set { this.name = value; }
        }

        public Company Company
        {
            set { this.company = value; }
        }

        public Car Car
        {
            set { this.car = value; }
        }

        public List<Parent> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        public List<Children> Childrens
        {
            get { return this.childrens; }
            set { this.childrens = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.name);
            result.AppendLine("Company:");

            if (this.company != null)
            {
                result.AppendLine($"{company.Name} {company.Department} {company.Salary:f2}");
            }

            result.AppendLine("Car:");

            if (this.car != null)
            {
                result.AppendLine($"{car.Model} {car.Speed}");
            }

            result.AppendLine("Pokemon:");

            if (this.pokemons != null)
            {
                foreach (var pokemon in this.pokemons)
                {
                    result.AppendLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            result.AppendLine("Parents:");

            if (this.parents != null)
            {
                foreach (var parrent in this.parents)
                {
                    result.AppendLine($"{parrent.Name} {parrent.BirthDay}");
                }
            }

            result.AppendLine("Children:");

            if (this.childrens != null)
            {
                foreach (var children in this.childrens)
                {
                    result.AppendLine($"{children.Name} {children.BirthDay}");
                }
            }

            return result.ToString();
        }
    }
}
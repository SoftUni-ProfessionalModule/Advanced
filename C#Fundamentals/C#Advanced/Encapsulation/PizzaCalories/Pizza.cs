namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int numberOfToppings;

        private const int MinToppingsCount = 0;
        private const int MaxToppingsCount = 10;

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.toppings = new List<Topping>();
        }

        public Dough Dough
        {
            set { this.dough = value; }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get { return this.numberOfToppings; }
            set
            {
                if (value < MinToppingsCount || value > MaxToppingsCount)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinToppingsCount}..{MaxToppingsCount}].");
                }

                this.numberOfToppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}
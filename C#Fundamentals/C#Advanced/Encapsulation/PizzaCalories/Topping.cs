namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private string type;
        private double weight;

        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value.ToLower() != "meat" 
                    && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" 
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return 2 * this.Weight * this.GetType();
        }

        private new double GetType()
        {
            if (this.Type.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
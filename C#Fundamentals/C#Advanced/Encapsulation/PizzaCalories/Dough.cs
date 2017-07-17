using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string backingTechnique;
        private double weight;

        private const int MinWeight = 1;
        private const int MaxWeight = 200;


        public Dough(string flourType, string backingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "wholegrain" && value.ToLower() != "white")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BackingTechnique
        {
            get { return this.backingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.backingTechnique = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return 2 * this.Weight * this.GetTechMod() * this.GetTypeMod();
        }

        private double GetTypeMod()
        {
            if (this.flourType.ToLower() == "white")
            {
                return 1.5;
            }

            return 1;
        }

        private double GetTechMod()
        {
            if (backingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (backingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }

            return 1;
        }
    }
}
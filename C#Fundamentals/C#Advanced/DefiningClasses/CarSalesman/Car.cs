namespace CarSalesman
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private List<Engine> engines;
        private string weight;
        private string color;

        public Car(string model, List<Engine> engine)
        {
            this.model = model;
            this.engines = new List<Engine>();
            this.weight = "n/a";
            this.color = "n/a";
        }

        public string Model
        {
            get { return this.model; }
        }
        public string Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public List<Engine> Engine
        {
            get { return this.engines; }
        }
    }
}
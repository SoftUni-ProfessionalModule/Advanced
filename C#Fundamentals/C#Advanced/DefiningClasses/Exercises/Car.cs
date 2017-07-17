namespace Exercises
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        public List<Tire> Tires
        {
            get { return this.tires; }
        }

        public Engine Engine
        {
            get { return this.engine; }
        }

        public string Model
        {
            get { return this.model; }
        }
    }
}
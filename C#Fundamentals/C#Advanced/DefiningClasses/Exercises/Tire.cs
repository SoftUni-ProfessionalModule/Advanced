namespace Exercises
{
    public class Tire
    {
        private int tireAge;
        private double tirePressure;

        public Tire(double tirePressure, int tireAge)
        {
            this.tirePressure = tirePressure;
            this.tireAge = tireAge;
        }

        public double TirePressure
        {
            get { return this.tirePressure; }
        }
    }
}
namespace Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Exercises
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            var listWithFrigile = new List<Car>();
            var listWithFlamable = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carTokens = Console.ReadLine().Split();

                var model = carTokens[0];
                var speed = int.Parse(carTokens[1]);
                var power = int.Parse(carTokens[2]);
                var weight = int.Parse(carTokens[3]);
                var type = carTokens[4];

                var currentEngine = new Engine(speed, power);
                var currentCargo = new Cargo(weight, type);

                var tires = new List<Tire>();
                for (int tire = 5; tire < carTokens.Length; tire += 2)
                {
                    var currentTire = new Tire(double.Parse(carTokens[tire]), int.Parse(carTokens[tire + 1]));

                    tires.Add(currentTire);
                }

                var currentCar = new Car(model, currentEngine, currentCargo, tires);

                cars.Add(currentCar);
            }

            var cargoType =
                Console.ReadLine() == "fragile" ? FillFragileList(cars, listWithFrigile) : FillFlamableList(cars, listWithFlamable);

            PrintResult(cargoType);
        }

        public static List<Car> FillFragileList(List<Car> cars, List<Car> fragileList)
        {
            foreach (var car in cars)
            {
                if (car.Tires.Any(c => c.TirePressure < 1))
                {
                    fragileList.Add(car);
                }
            }

           return fragileList;
        }

        public static List<Car> FillFlamableList(List<Car> cars, List<Car> flamableList)
        {
            foreach (var car in cars)
            {
                if (car.Engine.Power > 250)
                {
                    flamableList.Add(car);
                }
            }            

            return flamableList;
        }

        public static void PrintResult(List<Car> resultedList)
        {
            resultedList.ForEach(car => Console.WriteLine(car.Model));
        }
    }
}
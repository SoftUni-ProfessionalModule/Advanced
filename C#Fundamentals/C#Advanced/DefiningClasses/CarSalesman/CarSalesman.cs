namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarSalesman
    {
        public static void Main()
        {
            var enginesList = new List<Engine>();
            var carsList = new List<Car>();

            var numberOfEngines = int.Parse(Console.ReadLine());

            GetEngines(enginesList, numberOfEngines);

            var numberOfCars = int.Parse(Console.ReadLine());

            GetCars(enginesList, carsList, numberOfCars);

            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Model}:");

                foreach (var engine in car.Engine)
                {
                    Console.WriteLine($"  {engine.Model}:\n    Power: {engine.Power}\n    Displacement: {engine.Displacement}\n    Efficiency: {engine.Efficiency}");
                }

                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        public static void GetCars(List<Engine> enginesList, List<Car> carsList, int numberOfCars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                var carDetails = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var currentCarModel = carDetails[0];
                var engines = enginesList.Where(e => e.Model == carDetails[1]).ToList();
                var currentCar = new Car(currentCarModel, new List<Engine>());

                foreach (var engine in engines)
                {
                    currentCar.Engine.Add(engine);
                }

                if (carDetails.Length > 2)
                {
                    if (int.TryParse(carDetails[2], out int weight))
                    {
                        currentCar.Weight = carDetails[2];
                    }
                    else
                    {
                        currentCar.Color = carDetails[2];
                    }
                }
                if (carDetails.Length > 3)
                {
                    currentCar.Color = carDetails[3];
                }

                carsList.Add(currentCar);
            }
        }

        public static void GetEngines(List<Engine> enginesList, int numberOfEngines)
        {
            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineDetails = Console.ReadLine().Split(new[] { ' ', '\t'},StringSplitOptions.RemoveEmptyEntries);

                var currentEngineModel = engineDetails[0];
                var enginePower = engineDetails[1];

                var currentEngine = new Engine(currentEngineModel, enginePower);

                if (engineDetails.Length > 2)
                {
                    if (int.TryParse(engineDetails[2], out int currentDisplacement))
                    {
                        currentEngine.Displacement = engineDetails[2];
                    }
                    else
                    {
                        currentEngine.Efficiency = engineDetails[2];
                    }
                }
                if (engineDetails.Length > 3)
                {
                    currentEngine.Efficiency = engineDetails[3];
                }

                enginesList.Add(currentEngine);
            }
        }
    }
}
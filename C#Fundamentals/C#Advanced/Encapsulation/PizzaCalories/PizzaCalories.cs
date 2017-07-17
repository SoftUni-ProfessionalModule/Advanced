using System;

namespace PizzaCalories
{
    public class PizzaCalories
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var inputTokens = inputLine.Split();
                try
                {
                    switch (inputTokens[0])
                    {
                        case "Dough":
                            var dough = new Dough(inputTokens[1], inputTokens[2], double.Parse(inputTokens[3]));
                            Console.WriteLine($"{dough.GetCalories():f2}");
                            break;
                        case "Topping":
                            var topping = new Topping(inputTokens[1], double.Parse(inputTokens[2]));
                            Console.WriteLine($"{topping.GetCalories():f2}");
                            break;
                        case "Pizza":
                            MakePizza(inputTokens);
                            break;

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void MakePizza(string[] inputTokens)
        {
            var numberOfTopings = int.Parse(inputTokens[2]);
            var pizza = new Pizza(inputTokens[1], numberOfTopings);
            var doughTokens = Console.ReadLine().Split();
            var dough = new Dough(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));
            pizza.Dough = dough;

            for (int i = 0; i < numberOfTopings; i++)
            {
                var toppingTokens = Console.ReadLine().Split();
                var topping = new Topping(toppingTokens[1], double.Parse(toppingTokens[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
        }
    }
}
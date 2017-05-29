namespace _02L.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var values = input.Split().ToArray();

            var myStack = new Stack<string>(values.Reverse());

            while (myStack.Count > 1)
            {
                int firstNumber = int.Parse(myStack.Pop());
                string currentOperator = myStack.Pop();
                int secondNumber = int.Parse(myStack.Pop());

                switch (currentOperator)
                {
                    case "+": myStack.Push((firstNumber + secondNumber).ToString());
                            break;
                    case "-": myStack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(myStack.Pop());
        }
    }
}
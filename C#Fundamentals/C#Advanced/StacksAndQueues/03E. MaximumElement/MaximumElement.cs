namespace _03E.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MaximumElement
    {
        public static void Main()
        {
            var lineNumbers = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();
            var maxElementStack = new Stack<int>();

            for (int i = 0; i < lineNumbers; i++)
            {
                var currentQuery = Console.ReadLine().Split().ToArray();

                switch (currentQuery[0])
                {
                    case "1":
                        var currentDigit = int.Parse(currentQuery[1]);
                        myStack.Push(currentDigit);

                        if (maxElementStack.Count == 0 || currentDigit >= maxElementStack.Peek())
                        {
                            maxElementStack.Push(currentDigit);
                        }
                        break;
                    case "2":
                        var removedElement = myStack.Pop();

                        var currentMaxNumber = maxElementStack.Peek();

                        if (removedElement == currentMaxNumber)
                        {
                            if (maxElementStack.Count > 0)
                            {
                                maxElementStack.Pop();
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine(maxElementStack.Peek());
                        break;
                }
            }
        }
    }
}
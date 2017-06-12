namespace _02E.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = inputLine[1];
            var x = inputLine[2];

            var myStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < s; i++)
            {
                myStack.Pop();
            }

            if (myStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myStack.Any())
                {
                    Console.WriteLine(myStack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
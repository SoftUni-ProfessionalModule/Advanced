namespace _01L.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();

            var myStack = new Stack<char>();

            foreach (var symbol in inputString)
            {
                myStack.Push(symbol);
            }

            while (myStack.Count != 0)
            {
                Console.Write(myStack.Pop());
            }

            Console.WriteLine();
        }
    }
}
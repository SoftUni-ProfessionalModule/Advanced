namespace _09E.StackFibonacci
{
    using System;
    using System.Collections.Generic;
    public class StackFibonacci
    {
        public static void Main()
        {
            int fibNumber = int.Parse(Console.ReadLine());

            var fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int i = 0; i < fibNumber - 1; i++)
            {
                long first = fibonacciStack.Pop();
                long second = fibonacciStack.Pop();
                fibonacciStack.Push(first);
                fibonacciStack.Push(first + second);
            }

            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}
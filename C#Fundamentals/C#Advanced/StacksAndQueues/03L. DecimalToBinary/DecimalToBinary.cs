namespace _03L.DecimalToBinary
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinary
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input != 0)
                {
                    myStack.Push(input % 2);
                    input /= 2;
                }
            }

            Console.WriteLine(string.Join("", myStack));
        }
    }
}
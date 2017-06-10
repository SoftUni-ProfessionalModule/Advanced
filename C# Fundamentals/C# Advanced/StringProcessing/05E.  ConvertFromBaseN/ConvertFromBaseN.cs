namespace _05E.ConvertFromBaseN
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class ConvertFromBaseN
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var baseN = int.Parse(inputLine[0]);
            BigInteger number = BigInteger.Parse(inputLine[1]);

            var result = new Stack<BigInteger>();
            BigInteger x = 0;
            while (number != 0)
            {
                result.Push(number % baseN);

                number = number / baseN;
            }

            foreach (var digit in result)
            {
                Console.Write(digit);
            }

            Console.WriteLine();
        }
    }
}
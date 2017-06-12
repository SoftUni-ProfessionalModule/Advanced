namespace _04E.Convert_from_base_10
{
    using System;
    using System.Numerics;
    public class ConvertFromBase10
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var baseN = BigInteger.Parse(inputLine[0]);
            var number = inputLine[1];
            int power = 0;
            BigInteger result = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                BigInteger currentDigit = BigInteger.Parse(number[i].ToString());
                BigInteger x = BigInteger.Pow(baseN, power);

                result += currentDigit * x;
                power++;
            }

            Console.WriteLine(result);
        }
    }
}
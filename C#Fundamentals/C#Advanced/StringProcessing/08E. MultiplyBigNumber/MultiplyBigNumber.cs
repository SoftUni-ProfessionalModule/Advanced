namespace _08E.MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = int.Parse(Console.ReadLine());

            var firstNumberStack = new Stack<int>();
            var resultStack = new Stack<string>();

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < firstNumber.Length; i++)
            {
                firstNumberStack.Push(int.Parse(firstNumber[i].ToString()));
            }

            var minLength = firstNumberStack.Count;
            var firstDigit = 0;

            for (int i = 0; i < minLength; i++)
            {
                var sum = (firstNumberStack.Pop()) * secondNumber;

                var secondDigit = sum % 10;
                var reamainder = (secondDigit + firstDigit) / 10;
                resultStack.Push(((secondDigit + firstDigit) % 10).ToString());

                firstDigit = (sum / 10) + reamainder;
            }

            if (firstDigit > 0)
            {
                resultStack.Push(firstDigit.ToString());
            }

            var sb = new StringBuilder();

            foreach (var digit in resultStack)
            {
                sb.Append(digit);
            }

            var result = sb.ToString();

            Console.WriteLine(result.TrimStart(new char[] { '0' }));
        }
    }
}
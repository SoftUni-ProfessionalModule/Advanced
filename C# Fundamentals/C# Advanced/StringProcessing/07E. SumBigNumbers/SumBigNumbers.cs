namespace _07E.SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SumBigNumbers
    {
        public static void Main()
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            var firstNumberStack = new Stack<int>();
            var secondNumberStack = new Stack<int>();
            var resultStack = new Stack<string>();

            for (int i = 0; i < firstNumber.Length; i++)
            {
                firstNumberStack.Push(int.Parse(firstNumber[i].ToString()));
            }

            for (int i = 0; i < secondNumber.Length; i++)
            {
                secondNumberStack.Push(int.Parse(secondNumber[i].ToString()));
            }

            var minLength = Math.Min(firstNumberStack.Count, secondNumberStack.Count);
            int firstDigit = 0;
            var largerStack = firstNumberStack.Count > secondNumberStack.Count ? firstNumberStack : secondNumberStack;

            for (int i = 0; i < minLength; i++)
            {
                var sum = (firstNumberStack.Pop() + firstDigit) + secondNumberStack.Pop();
                firstDigit = sum / 10;
                var residue = sum % 10;
                resultStack.Push(residue.ToString());
            }

            var stackLength = largerStack.Count;

            for (int i = 0; i < stackLength; i++)
            {
                var sum = largerStack.Pop() + firstDigit;
                firstDigit = sum / 10;
                var residue = sum % 10;
                resultStack.Push(residue.ToString());
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
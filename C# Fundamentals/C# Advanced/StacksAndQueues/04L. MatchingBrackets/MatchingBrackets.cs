namespace _04L.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var myStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    myStack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = myStack.Pop();

                    string result = input.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
namespace _07E.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var paranthesisLine = Console.ReadLine();

            var openParanthesis = new Stack<char>();
            var openingCases = new char[] { '{', '(', '[' };

            for (int i = 0; i < paranthesisLine.Length; i++)
            {
                if (openingCases.Contains(paranthesisLine[i]))
                {
                    openParanthesis.Push(paranthesisLine[i]);
                }
                else
                {
                    if (openParanthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (paranthesisLine[i])
                    {
                        case '}':
                            if (openParanthesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (openParanthesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (openParanthesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
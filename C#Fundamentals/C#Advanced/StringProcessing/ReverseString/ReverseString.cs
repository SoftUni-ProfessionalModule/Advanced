namespace ReverseString
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();

            var result = new StringBuilder();

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                result.Append(inputString[i]);
            }

            Console.WriteLine(string.Join("", result.ToString()));

        }
    }
}
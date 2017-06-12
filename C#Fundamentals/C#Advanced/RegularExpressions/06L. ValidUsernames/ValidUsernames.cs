namespace _06L.ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            var userName = Console.ReadLine();
            var regex = new Regex(@"^[\w-]{3,16}$");

            while (userName != "END")
            {
                var matches = regex.Matches(userName);

                if (matches.Count > 0)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                userName = Console.ReadLine();
            }
        }
    }
}
namespace _07E.FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class FixEmails
    {
        public static void Main()
        {
            var name = Console.ReadLine();

            var userAndMail = new Dictionary<string, string>();

            while (name != "stop")
            {
                var email = Console.ReadLine();
                var endUS = email.EndsWith("us", true, CultureInfo.InvariantCulture);
                var endUK = email.EndsWith("uk", true, CultureInfo.InvariantCulture);

                if (!endUS && !endUK)
                {
                    if (!userAndMail.ContainsKey(name))
                    {
                        userAndMail.Add(name, email);
                    }
                }

                name = Console.ReadLine();
            }

            foreach (var kvp in userAndMail)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
namespace _07L.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main()
        {
            var time = Console.ReadLine();
            var regex = new Regex(@"\b(0?[0-9]|1[0-2])(:[0-5]?[0-9]){2}\s?(A|P)M\b");

            while (time != "END")
            {
                var matches = regex.Matches(time);

                if (matches.Count > 0)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                time = Console.ReadLine();
            }
        }
    }
}
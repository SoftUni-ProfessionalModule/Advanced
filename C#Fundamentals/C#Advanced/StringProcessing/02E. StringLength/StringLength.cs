namespace _02E.StringLength
{
    using System;
    using System.Text.RegularExpressions;

    public class StringLength
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var regex = new Regex(@"^.{0,21}");
            var asterix = "";
            var match = regex.Match(inputString);

            if (match.Success)
            {
                inputString = match.Value;
            }
            if (inputString.Length < 20)
            {
                asterix = new string('*', 20 - inputString.Length);
            }

            Console.WriteLine(inputString + asterix);
        }
    }
}
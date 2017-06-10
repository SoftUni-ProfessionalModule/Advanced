namespace _10E.UnicodeCharacters
{
    using System;
    using System.Text;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var unicodes = new StringBuilder();

            for (int i = 0; i < inputString.Length; i++)
            {
                unicodes.Append("\\u");
                unicodes.Append(String.Format("{0:x4}", (int)inputString[i]));
            }

            Console.WriteLine(unicodes.ToString());
        }
    }
}
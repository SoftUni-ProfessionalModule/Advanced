namespace _03L.ParseTags
{
    using System;

    public class ParseTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";
            var startIndex = text.IndexOf(openTag);

            while (startIndex != -1)
            {
                var endIndex = text.IndexOf(closeTag);

                if (endIndex == -1)
                {
                    break;
                }

                var upCase = text.Substring(startIndex, endIndex - startIndex + closeTag.Length);
                var replaceUpcase = upCase.Replace(openTag, "").Replace(closeTag, "").ToUpper();

                text = text.Replace(upCase, replaceUpcase);


                startIndex = text.IndexOf("<upcase>");
            }

            Console.WriteLine(text);
        }
    }
}
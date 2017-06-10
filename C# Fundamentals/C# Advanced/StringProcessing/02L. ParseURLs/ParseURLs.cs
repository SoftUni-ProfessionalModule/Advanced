namespace _02L.ParseURLs
{
    using System;

    public class ParseURLs
    {
        public static void Main()
        {
            var inputURL = Console.ReadLine();

            var index = inputURL.IndexOf("://");
            var matchCounter = 0;

            while (index != -1)
            {
                matchCounter++;

                index = inputURL.IndexOf("://", index + 1);
            }

            if (matchCounter != 1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var urlParts = inputURL.Split(new[] { "://" }, StringSplitOptions.None);
            var firstIndexOfSlash = urlParts[1].IndexOf('/');

            if (firstIndexOfSlash == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var protocol = urlParts[0];
            var server = urlParts[1].Substring(0, firstIndexOfSlash);
            var resourses = urlParts[1].Substring(firstIndexOfSlash + 1);

            Console.WriteLine($"Protocol = {protocol}\nServer = {server}\nResources = {resourses}");
        }
    }
}
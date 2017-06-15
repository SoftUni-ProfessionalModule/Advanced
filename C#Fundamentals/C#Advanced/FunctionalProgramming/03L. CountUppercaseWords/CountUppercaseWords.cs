namespace _03L.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Func<string, bool> isUpper = w => w[0] == w.ToUpper()[0];
            var text = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            text.Where(isUpper).ToList().ForEach(w => Console.WriteLine(w));
        }
    }
}
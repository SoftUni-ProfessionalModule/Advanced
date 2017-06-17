namespace _02L.UpperStrings
{
    using System;
    using System.Linq;

    public class UpperStrings
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split().Select(w => w.ToUpper());
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
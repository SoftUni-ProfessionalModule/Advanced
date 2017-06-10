namespace _03E.FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var a = long.Parse(numbers[0]);
            var b = double.Parse(numbers[1]);
            var c = double.Parse(numbers[2]);

            var aToHEX = a.ToString("X");
            var aToBinary = Convert.ToString(a, 2).PadLeft(10, '0');

            if (aToBinary.Length > 10)
            {
                aToBinary = aToBinary.Remove(10);
            }

            Console.WriteLine(String.Format("|{0,-10}|{1}|{2,10:f2}|{3,-10:f3}|", aToHEX, aToBinary, b, c));
        }
    }
}
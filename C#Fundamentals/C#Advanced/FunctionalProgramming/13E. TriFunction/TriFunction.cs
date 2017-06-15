namespace _13E.TriFunction
{
    using System;

    public class TriFunction
    {
        public static void Main()
        {
            var neededCharactersSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<int, int, bool> isMatchSum = (b, c) => b >= c;
            Action<string> print = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                if (isMatchSum(CheckEachNameSum(name), neededCharactersSum))
                {
                    print(name);
                    return;
                }
            }
        }

        public static int CheckEachNameSum(string name)
        {
            var currentNameLattersSum = 0;

            foreach (var letter in name)
            {
                currentNameLattersSum += letter;
            }

            return currentNameLattersSum;
        }
    }
}
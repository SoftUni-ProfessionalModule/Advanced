namespace _02E.DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize][];
            var primarySum = 0;
            var secondarySum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                primarySum += matrix[i][i];
                secondarySum += matrix[i][matrix[i].Length - 1 - i];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
namespace _01L.SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0]][];
            var sum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
               .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                sum += matrix[row].Sum();
            }

            Console.WriteLine($"{matrix.Length}\n{matrix[0].Length}\n{sum}");
        }
    }
}
namespace _02L.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0]][];
            var maxRowIndex = 0;
            var maxColIndex = 0;
            var maxSum = int.MinValue;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length -1; col++)
                {
                    var currentSum = 
                        matrix[row][col] 
                        + matrix[row][col + 1] 
                        + matrix[row + 1][col] 
                        + matrix[row + 1][col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRowIndex][maxColIndex]} {matrix[maxRowIndex][maxColIndex + 1]}\n{matrix[maxRowIndex + 1][maxColIndex]} {matrix[maxRowIndex + 1][maxColIndex + 1]}\n{maxSum}");
        }
    }
}
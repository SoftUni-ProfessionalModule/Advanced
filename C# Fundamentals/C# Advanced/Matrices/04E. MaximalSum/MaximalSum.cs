namespace _04E.MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    public class MaximalSum
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
            var resultedMatrix = new StringBuilder();

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    var currentSum =
                        matrix[row][col]
                        + matrix[row][col + 1]
                        + matrix[row][col + 2]
                        + matrix[row + 1][col]
                        + matrix[row + 1][col + 1]
                        + matrix[row + 1][col + 2]
                        + matrix[row + 2][col]
                        + matrix[row + 2][col + 1]
                        + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRowIndex = row;
                        maxColIndex = col;
                        resultedMatrix.Clear();
                        resultedMatrix.AppendLine(matrix[row][col] + " " + matrix[row][col + 1] + " " + matrix[row][col + 2]);
                        resultedMatrix.AppendLine(matrix[row + 1][col] + " " + matrix[row + 1][col + 1] + " " + matrix[row + 1][col + 2]);
                        resultedMatrix.Append(matrix[row + 2][col] + " " + matrix[row + 2][col + 1] + " " + matrix[row + 2][col + 2]);
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}\n{resultedMatrix.ToString()}");
        }
    }
}
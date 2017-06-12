namespace _09E.Crossfire
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new string[rows][];
            int number = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[matrixSize[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = number.ToString();
                    number++;
                }
            }

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var destroyParams = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                var desRowIndex = destroyParams[0];
                var desColIndex = destroyParams[1];
                long radius = destroyParams[2];

                if (desRowIndex < 0 || desColIndex < 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                var startRowIndex = desRowIndex - radius < 0 ? 0 : desRowIndex - radius;
                long damageHight = 2 * radius + 1;

                for (int row = (int)startRowIndex; row < matrix.Length; row++)
                {
                    var currentRowLength = matrix[row].Length;

                    if (damageHight == 0)
                    {
                        break;
                    }
                    if (desColIndex >= currentRowLength)
                    {
                        continue;
                    }

                    matrix[row][desColIndex] = string.Empty;
                    damageHight--;
                }

                var startColIndex = desColIndex - radius < 0 ? 0 : desColIndex - radius;
                var damageLength = 2 * radius + 1;

                for (int col = (int)startColIndex; col < matrix[desRowIndex].Length; col++)
                {
                    var currentRowLength = matrix[col].Length;

                    if (damageLength == 0)
                    {
                        break;
                    }

                    if (desRowIndex >= currentRowLength)
                    {
                        continue;
                    }

                    matrix[desRowIndex][col] = string.Empty;
                    damageLength--;
                }

                var rowCounter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row].All(x => x == string.Empty))
                    {
                        continue;
                    }

                    rowCounter++;
                }

                var spareMatrix = new string[rowCounter][];
                rowCounter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row].All(x => x == string.Empty))
                    {
                        continue;
                    }

                    spareMatrix[rowCounter] = new string[matrix[row].Length];
                    spareMatrix[rowCounter] = matrix[row].Where(x => x != string.Empty).ToArray();
                    rowCounter++;
                }

                matrix = spareMatrix;

                command = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
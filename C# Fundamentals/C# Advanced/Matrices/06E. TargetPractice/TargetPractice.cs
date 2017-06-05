namespace _06E.TargetPractice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine();

            var line = 0;
            var symbolIndex = 0;
            var matrix = new char[matrixSize[0], matrixSize[1]];
            var rowLength = matrixSize[0];

            FillMatrix(snake, ref line, ref symbolIndex, matrix);

            var shootParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var shootRowIndex = shootParams[0];
            var shootColIndex = shootParams[1];
            var circleRadius = shootParams[2];

            GetShoot(matrix, shootRowIndex, shootColIndex, circleRadius);

            StartFalling(matrix);

            PrintResultedMatrix(matrix);
        }

        private static void PrintResultedMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void StartFalling(char[,] matrix)
        {
            bool fallen = false;
            do
            {
                fallen = false;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                            fallen = true;
                        }
                    }
                }
            } while (fallen);
        }

        private static void GetShoot(char[,] matrix, int shootRowIndex, int shootColIndex, int circleRadius)
        {
            matrix[shootRowIndex, shootColIndex] = ' ';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row - shootRowIndex) * (row - shootRowIndex) + (col - shootColIndex) * (col - shootColIndex) <= circleRadius * circleRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix(string snake, ref int line, ref int symbolIndex, char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (line % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[symbolIndex];
                        symbolIndex++;

                        if (symbolIndex == snake.Length)
                        {
                            symbolIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[symbolIndex];
                        symbolIndex++;

                        if (symbolIndex == snake.Length)
                        {
                            symbolIndex = 0;
                        }
                    }
                }

                line++;
            }
        }
    }
}
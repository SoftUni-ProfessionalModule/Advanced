namespace _03E.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new string[matrixSize[0]][];
            var equalSymbolsCounter = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var firstSymbol = matrix[row][col];
                    var secondSymbol = matrix[row][col + 1];
                    var thirdSymbol = matrix[row + 1][col];
                    var fourthSymbol = matrix[row + 1][col + 1];
                    var isSymbolsEqual = firstSymbol == secondSymbol && firstSymbol == thirdSymbol && firstSymbol == fourthSymbol;

                    if (isSymbolsEqual)
                    {
                        equalSymbolsCounter++;
                    }
                }
            }

            Console.WriteLine(equalSymbolsCounter);
        }
    }
}
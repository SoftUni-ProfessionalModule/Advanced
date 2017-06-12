namespace _07E.LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            var numberOfRows = int.Parse(Console.ReadLine());

            var firstMatrix = new string[numberOfRows][];
            var secondMatrix = new string[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                firstMatrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                secondMatrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var isFit = true;
            var firstRow = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int row = 1; row < numberOfRows; row++)
            {
                var nextRow = firstMatrix[row].Length + secondMatrix[row].Length;
                if (firstRow != nextRow)
                {
                    isFit = false;
                    break;
                }
            }

            if (isFit)
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.Write($"[{string.Join(", ", firstMatrix[row])}");
                    Array.Reverse(secondMatrix[row]);
                    Console.WriteLine($", {string.Join(", ", secondMatrix[row])}]");

                }

            }
            else
            {
                var firstMatrixNumberOfCells = firstMatrix.Select(x => x.GetLength(0)).Sum();
                var secondMatrixNumberOfCells = secondMatrix.Select(x => x.GetLength(0)).Sum();
                Console.WriteLine($"The total number of cells is: {firstMatrixNumberOfCells + secondMatrixNumberOfCells}");
            }
        }
    }
}
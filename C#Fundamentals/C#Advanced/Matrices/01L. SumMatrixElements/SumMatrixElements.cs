namespace _01L.SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {

            var matrix = new int[5, 5, 5];
            var x = Math.Pow(5, 5);
            try
            {
                matrix[1, 4, 0] += 5;
            }
            catch (IndexOutOfRangeException)
            {

            }

            for (int demention1 = 0; demention1 < matrix.GetLength(0); demention1++)
            {
                for (int demention2 = 0; demention2 < matrix.GetLength(1); demention2++)
                {
                    for (int demention3 = 0; demention3 < matrix.GetLength(2); demention3++)
                    {
                        Console.Write(matrix[demention1, demention2, demention3] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            //var matrixSize = Console.ReadLine()
            //    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //var matrix = new int[matrixSize[0]][];
            //var sum = 0;

            //for (int row = 0; row < matrix.Length; row++)
            //{
            //    matrix[row] = Console.ReadLine()
            //   .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //   .Select(int.Parse)
            //   .ToArray();
            //}

            //for (int row = 0; row < matrix.Length; row++)
            //{
            //    sum += matrix[row].Sum();
            //}

            //Console.WriteLine($"{matrix.Length}\n{matrix[0].Length}\n{sum}");
        }
    }
}
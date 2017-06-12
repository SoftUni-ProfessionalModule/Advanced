namespace _04L.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            var hight = int.Parse(Console.ReadLine());

            var matrix = new long[hight][];

            for (int row = 1; row <= matrix.Length; row++)
            {
                matrix[row - 1] = new long[row];
                matrix[row - 1][0] = 1;
                matrix[row - 1][matrix[row - 1].Length - 1] = 1;

                for (int i = 1; i < matrix[row - 1].Length - 1; i++)
                {
                    matrix[row - 1][i] = matrix[row - 2][i - 1] + matrix[row - 2][i];
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row)); 
            }
        }
    }
}
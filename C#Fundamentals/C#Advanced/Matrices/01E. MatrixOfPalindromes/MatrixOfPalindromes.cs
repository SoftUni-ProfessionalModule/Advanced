namespace _01E.MatrixOfPalindromes
{
    using System;
    using System.Linq;
    using System.Text;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var matrix = new string[matrixSize[0]][];
            var palindromes = new StringBuilder();

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[matrixSize[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    palindromes.Append(alphabet[row]);
                    palindromes.Append(alphabet[row + col]);
                    palindromes.Append(alphabet[row]);

                    matrix[row][col] = palindromes.ToString();

                    palindromes.Clear();
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
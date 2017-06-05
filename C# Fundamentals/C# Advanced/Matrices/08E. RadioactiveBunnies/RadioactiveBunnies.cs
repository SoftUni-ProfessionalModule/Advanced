namespace _08E.RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] matrix = new char[matrixSize[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                .ToCharArray();
            }

            string path = Console.ReadLine();
            int playerRow = GetPlayerRow(matrix);
            int playerCol = GetPlayerCol(matrix);
            bool isOut = false;
            bool isDead = false;

            for (int i = 0; i < path.Length; i++)
            {
                char currentDirection = path[i];

                switch (currentDirection)
                {
                    case 'U':
                        if (playerRow - 1 < 0)
                        {
                            isOut = true;
                        }
                        else if (matrix[playerRow - 1][playerCol] == 'B')
                        {
                            isDead = true;
                            matrix[playerRow][playerCol] = '.';
                            playerRow--;
                        }
                        else
                        {
                            matrix[playerRow - 1][playerCol] = 'P';
                            matrix[playerRow][playerCol] = '.';
                            playerRow--;
                            SpreadBunnies(matrix);
                        }
                        break;
                    case 'D':
                        if (playerRow + 1 >= matrix.Length)
                        {
                            isOut = true;
                        }
                        else if (matrix[playerRow + 1][playerCol] == 'B')
                        {
                            isDead = true;
                            matrix[playerRow][playerCol] = '.';
                            playerRow++;
                        }
                        else
                        {
                            matrix[playerRow + 1][playerCol] = 'P';
                            matrix[playerRow][playerCol] = '.';
                            playerRow++;
                            SpreadBunnies(matrix);
                        }
                        break;
                    case 'L':
                        if (playerCol - 1 < 0)
                        {
                            isOut = true;
                        }
                        else if (matrix[playerRow][playerCol - 1] == 'B')
                        {
                            isDead = true;
                            matrix[playerRow][playerCol] = '.';
                            playerCol--;
                        }
                        else
                        {
                            matrix[playerRow][playerCol - 1] = 'P';
                            matrix[playerRow][playerCol] = '.';
                            playerCol--;
                            SpreadBunnies(matrix);
                        }
                        break;
                    case 'R':
                        if (playerCol + 1 >= matrix[playerRow].Length)
                        {
                            isOut = true;
                        }
                        else if (matrix[playerRow][playerCol + 1] == 'B')
                        {
                            isDead = true;
                            matrix[playerRow][playerCol] = '.';
                            playerCol++;
                        }
                        else
                        {
                            matrix[playerRow][playerCol + 1] = 'P';
                            matrix[playerRow][playerCol] = '.';
                            playerCol++;
                            SpreadBunnies(matrix);
                        }
                        break;
                }

                if (isOut)
                {
                    matrix[playerRow][playerCol] = '.';
                    SpreadBunnies(matrix);
                    PrintArea(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                if (isDead)
                {
                    SpreadBunnies(matrix);
                    PrintArea(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void PrintArea(char[][] area)
        {
            foreach (var row in area)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void SpreadBunnies(char[][] area)
        {
            List<int> bunnyRows = GetBunnyRows(area);
            List<int> bunnyCols = GetBunnyCols(area);

            for (int i = 0; i < bunnyRows.Count; i++)
            {
                int row = bunnyRows[i];
                int col = bunnyCols[i];

                if (row > 0)
                {
                    area[row - 1][col] = 'B';
                }

                if (row < area.Length - 1)
                {
                    area[row + 1][col] = 'B';
                }

                if (col > 0)
                {
                    area[row][col - 1] = 'B';
                }

                if (col < area[row].Length - 1)
                {
                    area[row][col + 1] = 'B';
                }
            }
        }

        private static List<int> GetBunnyCols(char[][] area)
        {
            List<int> cols = new List<int>();

            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'B')
                    {
                        cols.Add(col);
                    }
                }
            }

            return cols;
        }

        private static List<int> GetBunnyRows(char[][] area)
        {
            List<int> rows = new List<int>();

            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'B')
                    {
                        rows.Add(row);
                    }
                }
            }

            return rows;
        }

        private static int GetPlayerCol(char[][] area)
        {
            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'P')
                    {
                        return col;
                    }
                }
            }

            return 0;
        }

        private static int GetPlayerRow(char[][] area)
        {
            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'P')
                    {
                        return row;
                    }
                }
            }

            return 0;
        }
    }
}
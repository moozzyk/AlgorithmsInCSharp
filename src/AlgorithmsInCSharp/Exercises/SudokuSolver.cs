namespace AlgorithmsInCSharp.Exercises
{
    public static class SudokuSolver
    {
        public static void Solve(byte[][] initialSetting)
        {
            var board = new byte[9, 9];

            foreach (var data in initialSetting)
            {
                board[data[0], data[1]] = data[2];
            }

            Utils.PrintSudoku(board);

            Solve(board, 0);
        }

        private static void Solve(byte[,] board, int position)
        {
            if (position == 81)
            {
                System.Console.WriteLine();
                Utils.PrintSudoku(board);

                return;
            }

            var row = position / 9;
            var col = position % 9;

            if (board[row, col] == 0)
            {
                for (byte i = 1; i <= 9; i++)
                {
                    if (CanAdd(board, i, row, col))
                    {
                        board[row, col] = i;
                        Solve(board, position + 1);
                    }
                }

                board[row, col] = 0;
            }
            else
            {
                Solve(board, position + 1);
            }
        }

        private static bool CanAdd(byte[,] board, int value, int row, int col)
        {
            for (var i = 0; i < 9; i++)
            {
                if (board[row, i] == value || board[i, col] == value)
                {
                    return false;
                }
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (board[(3 * (row / 3)) + i, (3 * (col / 3)) + j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class YoungTableau
    {
        public int Rows { get; }
        public int Columns { get; }
        public int[,] Values { get; }

        public bool IsEmpty { get { return Values[0, 0] == int.MaxValue; }}

        public YoungTableau(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Values = new int[columns, rows];
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Values[column, row] = int.MaxValue;
                }
            }
        }

        public void Insert(int value)
        {
            if (value == int.MaxValue)
            {
                throw new ArgumentException("The value to insert can't be int.MaxValue.", "value");
            }

            if (Values[Columns - 1, Rows -1] != int.MaxValue)
            {
                throw new InvalidOperationException("The youn tableau is full.");
            }

            int column = Columns - 1, row = Rows - 1;
            for (;;)
            {
                var largestValue = int.MinValue;
                int largestColumn = column, largestRow = row;

                if (column > 0)
                {
                    largestValue = Values[column - 1, row];
                    largestColumn = column -1;
                }

                if (row > 0 && Values[column, row - 1] > largestValue)
                {
                    largestValue = Values[column, row - 1];
                    largestColumn = column;
                    largestRow = row - 1;
                }

                if (largestValue <= value)
                {
                    break;
                }

                var tmp = Values[largestColumn, largestRow];
                Values[largestColumn, largestRow] = value;
                Values[column, row] = tmp;
                column = largestColumn;
                row = largestRow;
            }
        }

        public int ExtractMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The tableau is empty.");
            }

            var minValue = Values[0, 0];
            Values[0 ,0] = int.MaxValue;
            Restore(0, 0);
            return minValue;
        }

        private void Restore(int column, int row)
        {
            int smallestColumn = column, smallestRow = row;
            int smallestValue = int.MaxValue;

            if (column + 1 < Columns && Values[column + 1, row] < smallestValue)
            {
                smallestColumn = column + 1;
                smallestValue = Values[column + 1, row];
            }

            if (row + 1 < Rows && Values[column, row + 1] < smallestValue)
            {
                smallestColumn = column;
                smallestRow = row + 1;
                smallestValue = Values[column, row + 1];
            }

            if (smallestValue < int.MaxValue)
            {
                Values[column, row] = Values[smallestColumn, smallestRow];
                Values[smallestColumn, smallestRow] = int.MaxValue;
                Restore(smallestColumn, smallestRow);
            }
        }
        public bool Contains(int value)
        {
            int column = 0, row = Rows - 1;

            while (true)
            {
                if (row > 0 && Values[column, row] > value)
                {
                    row--;
                }
                else if (column < Columns - 1 && Values[column, row] < value)
                {
                    column++;
                }
                else
                {
                    return Values[column, row] == value;
                }
            }
        }
    }
}
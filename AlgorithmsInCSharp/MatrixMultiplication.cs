using System;

namespace Algorithms
{
    class MatrixMultiplication
    {
        public static void ON3(int [,]A, int[,]B)
        {
            if (A.GetLength(1) != B.GetLength(0))
            {
                throw new ArgumentException("Incompatible matrices.");
            }

            var result = new int[A.GetLength(0), B.GetLength(1)];

            for (var rowA = 0; rowA < A.GetLength(0); rowA++)
            {
                for (var colB = 0; colB < B.GetLength(1); colB++)
                {
                    for (var colA = 0; colA < A.GetLength(1); colA++)
                    {
                        result[rowA, colB] += A[rowA, colA]*B[colA, colB];
                    }
                }
            }
            PrintMatrixMultiplication(A, B, result);
        }

        public static void RecursiveON3(int[,] A, int[,] B)
        {
            var rows = A.GetLength(0);
            if ((rows & (rows - 1)) != 0 || A.GetLength(1) != rows || B.GetLength(0) != rows || B.GetLength(1) != rows)
            {
                throw new ArgumentException("Only square matrices whose whose number of rows and number of columns is a power of 2 are supported");
            }

            var result = RecursiveON3(A, 0, 0, B, 0, 0, A.GetLength(0));
            PrintMatrixMultiplication(A, B, result);
        }

        private static int[,] RecursiveON3(int[,] A, int rowA, int colA, int[,] B, int rowB, int colB, int size)
        {
            if (size == 1)
            {
                return new int[1, 1] {{A[rowA, colA]*B[rowB, colB]}};
            }

            var result = new int[size, size];

            Sum(
                RecursiveON3(A, rowA, colA, B, rowB, colB, size/2),
                RecursiveON3(A, rowA, colA + size/2, B, rowB + size/2, colB, size/2),
                result, 0, 0);

            Sum(
                RecursiveON3(A, rowA, colA, B, rowB, colB + size / 2, size / 2),
                RecursiveON3(A, rowA, colA + size / 2, B, rowB + size / 2, colB + size / 2, size / 2),
                result, 0, size/2);

            Sum(
                RecursiveON3(A, rowA + size/2, colA, B, rowB, colB, size/2),
                RecursiveON3(A, rowA + size/2, colA + size/2, B, rowB + size/2, colB, size/2),
                result, size/2, 0);

            Sum(
                RecursiveON3(A, rowA + size/2, colA, B, rowB, colB + size/2, size/2),
                RecursiveON3(A, rowA + size/2, colA + size/2, B, rowB + size/2, colB + size/2, size/2),
                result, size/2, size/2);

            return result;
        }

        private static void Sum(int[,] A, int[,] B, int[,] result, int row, int col)
        {
            for (var i = 0; i < A.GetLength(0); i++)
            {
                for (var j = 0; j < A.GetLength(1); j++)
                {
                    result[row + i, col + j] += A[i, j] + B[i, j];
                }
            }
        }

        public static void Recursive(int[,] A, int[,] B)
        {
            var rows = A.GetLength(0);
            if ((rows & (rows - 1)) != 0 || A.GetLength(1) != rows || B.GetLength(0) != rows || B.GetLength(1) != rows)
            {
                throw new ArgumentException("Only square matrices whose whose number of rows and number of columns is a power of 2 are supported");
            }

            var result = new int[A.GetLength(0), A.GetLength(0)];
            Recursive(A, 0, 0, B, 0, 0, A.GetLength(0), result);
            PrintMatrixMultiplication(A, B, result);
        }

        private static void Recursive(int[,] A, int rowA, int colA, int[,] B, int rowB, int colB, int size, int[,] result)
        {
            if (size == 1)
            {
                result[rowA, colB] += A[rowA, colA] * B[rowB, colB];
            }
            else
            {
                Recursive(A, rowA, colA, B, rowB, colB, size / 2, result);
                Recursive(A, rowA, colA + size / 2, B, rowB + size / 2, colB, size / 2, result);

                Recursive(A, rowA, colA, B, rowB, colB + size / 2, size / 2, result);
                Recursive(A, rowA, colA + size / 2, B, rowB + size / 2, colB + size / 2, size / 2, result);

                Recursive(A, rowA + size / 2, colA, B, rowB, colB, size / 2, result);
                Recursive(A, rowA + size / 2, colA + size / 2, B, rowB + size / 2, colB, size / 2, result);

                Recursive(A, rowA + size / 2, colA, B, rowB, colB + size / 2, size / 2, result);
                Recursive(A, rowA + size / 2, colA + size / 2, B, rowB + size / 2, colB + size / 2, size / 2, result);
            }
        }

        private static void PrintMatrixMultiplication(int[,] A, int[,] B, int[,] result)
        {
            var maxRow = Math.Max(A.GetLength(0), B.GetLength(1));

            for (var row = 0; row < maxRow; row++)
            {
                //for (var col = 0; col < A.GetLength(1); col++)
                //{
                //    Console.Write("{0, 4} ", row < A.GetLength(0) ? A[row, col].ToString() : "");
                //}

                //Console.Write(" {0} ", row == maxRow / 2 ? "*" : " ");

                //for (var col = 0; col < B.GetLength(1); col++)
                //{
                //    Console.Write("{0, 4} ", row < B.GetLength(0) ? B[row, col].ToString() : "");
                //}

                Console.Write(" {0} ", row == maxRow / 2 ? "=" : " ");

                for (var col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write("{0, 4} ", result[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

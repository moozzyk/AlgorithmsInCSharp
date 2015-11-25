using System;

namespace AlgorithmsInCSharp.Algorithms.MatrixMultiplication
{
    public class MatrixMultiplication_Recursive_ON3
    {
        public static int[,] Multiply(int[,] A, int[,] B)
        {
            var rows = A.GetLength(0);
            if ((rows & (rows - 1)) != 0 || A.GetLength(1) != rows || B.GetLength(0) != rows || B.GetLength(1) != rows)
            {
                throw new ArgumentException("Only square matrices whose whose number of rows and number of columns is a power of 2 are supported");
            }

            return RecursiveON3(A, 0, 0, B, 0, 0, A.GetLength(0));
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
    }
}
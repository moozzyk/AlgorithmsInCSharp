using System;

namespace AlgorithmsInCSharp.Algorithms.MatrixMultiplication
{
    public class MatrixMultiplication_RecursiveInPlace_ON3
    {
        public static int[,] Multiply(int[,] A, int[,] B)
        {
            var rows = A.GetLength(0);
            if ((rows & (rows - 1)) != 0 || A.GetLength(1) != rows || B.GetLength(0) != rows || B.GetLength(1) != rows)
            {
                throw new ArgumentException("Only square matrices whose whose number of rows and number of columns is a power of 2 are supported");
            }

            var result = new int[A.GetLength(0), A.GetLength(0)];
            Multiply(A, 0, 0, B, 0, 0, A.GetLength(0), result);
            return result;
        }

        private static void Multiply(int[,] A, int rowA, int colA, int[,] B, int rowB, int colB, int size, int[,] result)
        {
            if (size == 1)
            {
                result[rowA, colB] += A[rowA, colA] * B[rowB, colB];
            }
            else
            {
                Multiply(A, rowA, colA, B, rowB, colB, size / 2, result);
                Multiply(A, rowA, colA + size / 2, B, rowB + size / 2, colB, size / 2, result);

                Multiply(A, rowA, colA, B, rowB, colB + size / 2, size / 2, result);
                Multiply(A, rowA, colA + size / 2, B, rowB + size / 2, colB + size / 2, size / 2, result);

                Multiply(A, rowA + size / 2, colA, B, rowB, colB, size / 2, result);
                Multiply(A, rowA + size / 2, colA + size / 2, B, rowB + size / 2, colB, size / 2, result);

                Multiply(A, rowA + size / 2, colA, B, rowB, colB + size / 2, size / 2, result);
                Multiply(A, rowA + size / 2, colA + size / 2, B, rowB + size / 2, colB + size / 2, size / 2, result);
            }
        }
    }
}
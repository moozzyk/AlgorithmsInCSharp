using System;

namespace AlgorithmsInCSharp.Algorithms.MatrixMultiplication
{
    public static class MatrixMultiplication_Iterative_ON3
    {
        public static int[,] Multiply(int [,]A, int[,]B)
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

            return result;
        }
    }
}
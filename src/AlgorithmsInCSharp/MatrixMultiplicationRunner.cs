using System;
using AlgorithmsInCSharp.Algorithms.MatrixMultiplication;

namespace AlgorithmsInCSharp
{
    internal static class MatrixMultiplicationRunner
    {
        public static void Run()
        {
            var A = new[,]
            {
                {1, 3, 4, 9},
                {7, 5, 6, 1},
                {2, 6, 0, 4},
                {7, 2, 2, 3},
            };

            var B = new[,]
            {
                {6, 8, 7, -2},
                {4, 2, 0, 2},
                {-1, 4, 4, 4},
                {2, 6, 3, -4}
            };

            RunMatrixMultiplication("Matrix Multiplication - iterative O(N^3)",
                MatrixMultiplication_Iterative_ON3.Multiply, A, B);

            RunMatrixMultiplication("Matrix Multiplication - recursive O(N^3)",
                MatrixMultiplication_Recursive_ON3.Multiply, A, B);

            RunMatrixMultiplication("Matrix Multiplication - recursive in-place O(N^3)",
                MatrixMultiplication_RecursiveInPlace_ON3.Multiply, A, B);
        }

        private static void RunMatrixMultiplication(string name, Func<int[,], int[,], int[,]> multiplyMatrices, int[,] A, int[,] B)
        {
            Utils.PrintAlgorithmRun(name, ()=>
            {
                var C = multiplyMatrices(A, B);
                Utils.PrintMatrixMultiplication(A, B, C);
            });
        }
    }
}
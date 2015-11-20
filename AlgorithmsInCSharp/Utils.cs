using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class Utils
    {
        public static void PrintHeader(string text)
        {
            Console.WriteLine($"* {text}");
        }

        public static void PrintSeparator()
        {
            Console.WriteLine(new string('=', 60) + "\n");
        }

        public static void PrintAlgorithmRun(string name, Action run)
        {
            PrintHeader(name);
            run();
            PrintSeparator();
        }

        public static string FormatArray<T>(IEnumerable<T> array)
        {
            return $"[ {string.Join(", ", array.Select(i => i.ToString()))} ]";
        }

        public static void PrintMatrixMultiplication(int[,] A, int[,] B, int[,] result)
        {
            var maxRow = Math.Max(A.GetLength(0), B.GetLength(1));

            for (var row = 0; row < maxRow; row++)
            {
                for (var col = 0; col < A.GetLength(1); col++)
                {
                    Console.Write("{0, 4} ", row < A.GetLength(0) ? A[row, col].ToString() : "");
                }

                Console.Write(" {0} ", row == maxRow / 2 ? "*" : " ");

                for (var col = 0; col < B.GetLength(1); col++)
                {
                    Console.Write("{0, 4} ", row < B.GetLength(0) ? B[row, col].ToString() : "");
                }

                Console.Write(" {0} ", row == maxRow / 2 ? "=" : " ");

                for (var col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write("{0, 4} ", result[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void PrintYoungTableau(YoungTableau tableau)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < tableau.Rows; row++)
            {
                sb.Length = 0;
                for (var col = 0; col < tableau.Columns; col++)
                {
                    sb.Append(string.Format("{0, 5}, ",
                        tableau.Values[col, row] == int.MaxValue ? "  -  " : tableau.Values[col, row].ToString()));
                }
                sb.Length = sb.Length - 2;
                Console.WriteLine(sb.ToString());
            }
        }

        public static void PrintList<T>(AlgorithmsInCSharp.DataStructures.LinkedList<T>.Node node)
        {
            Console.Write("Head -> ");

            while (node != null)
            {
                Console.Write("{0} -> ", node.Value);
                node = node.Next;
            }

            Console.WriteLine("null");
        }
    }
}

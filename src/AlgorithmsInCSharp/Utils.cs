using System;
using System.Linq;
using System.Text;
using AlgorithmsInCSharp.Algorithms;
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

        public static string FormatArray<T>(System.Collections.Generic.IEnumerable<T> array)
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
            Console.Write("  List: Head -> ");

            while (node != null)
            {
                Console.Write("{0} -> ", node.Value);
                node = node.Next;
            }

            Console.WriteLine("null");
        }

        public static void PrintList<T>(AlgorithmsInCSharp.DataStructures.DoublyLinkedList<T>.Node node)
        {
            Console.Write("  List: Head <-> ");

            while (node != null)
            {
                Console.Write("{0} <-> ", node.Value);
                node = node.Next;
            }

            Console.WriteLine("Tail");
        }

        public static void PrintListReverse<T>(AlgorithmsInCSharp.DataStructures.DoublyLinkedList<T>.Node node)
        {
            Console.Write("  List: Tail <-> ");
            while (node != null)
            {
                Console.Write("{0} <-> ", node.Value);
                node = node.Previous;
            }

            Console.WriteLine("Head");
        }

        public static void PrintStack<T>(Stack<T> stack)
        {
            if (stack.IsEmpty)
            {
                Console.WriteLine("  (empty)");
            }
            else
            {
                PrintStackHelper(stack);
            }
            Console.WriteLine();
        }

        private static void PrintStackHelper<T>(Stack<T> stack)
        {
            if (!stack.IsEmpty)
            {
                var item = stack.Pop();
                Console.WriteLine($"  {item}");
                PrintStackHelper(stack);
                stack.Push(item);
            }
        }

        public static void PrintBinaryTree<T>(BinaryTreeNode<T> root)
        {
            var height = Trees.Height(root);

            var nodeCount = (1 << height) - 1;
            var bfsNodes = new Queue<BinaryTreeNode<T>>(1 << height);
            var allNodes = new BinaryTreeNode<T>[nodeCount];

            bfsNodes.Enqueue(root);
            for (var i = 0; i < nodeCount; i++)
            {
                var node = bfsNodes.Dequeue();
                allNodes[i] = node;
                if (node != null)
                {
                    bfsNodes.Enqueue(node.Left);
                    bfsNodes.Enqueue(node.Right);
                }
                else
                {
                    bfsNodes.Enqueue(null);
                    bfsNodes.Enqueue(null);
                }
            }

            PrintHeap(allNodes.Select(n => n == null ? " " : n.Value.ToString()).ToArray());
        }

        public static void PrintHeap<T>(T[] heap)
        {
            const int margin = 8;
            const int viewWidth = 128;
            const int fieldWidth = 4;

            var padding = viewWidth / 2;
            Console.Write(new string(' ', margin + padding / 2 - fieldWidth));

            for (int i = 0, level = 0; i < heap.Length; i++)
            {
                var centeredValue = new string(' ', (fieldWidth - heap[i].ToString().Length) / 2) + heap[i];
                Console.Write($"{centeredValue, fieldWidth}{new string(' ', padding - fieldWidth)}");
                if (((i + 2) & (i + 1)) == 0)
                {
                    padding /= 2;
                    Console.WriteLine();
                    Console.Write(new string(' ', margin + padding / 2 - fieldWidth));
                    level++;
                }
            }
            Console.WriteLine();
        }
    }
}
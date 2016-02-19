using System;
using System.Linq;
using AlgorithmsInCSharp.DataStructures;
using AlgorithmsInCSharp.Exercises;

namespace AlgorithmsInCSharp
{
    internal static class ExercisesRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("SortStack", RunSortStack);
            Utils.PrintAlgorithmRun("DoublyLinkedListToBinaryTree", RunDoublyLinkedListToBinaryTreeConversion);
            Utils.PrintAlgorithmRun("BinaryTreeToDoublyLinkedList", RunBinaryTreeToListConversion);
            Utils.PrintAlgorithmRun("TowersOfHanoi", RunTowersOfHanoi);
            Utils.PrintAlgorithmRun("SudokuSolver", RunSudokuSolver);
            Utils.PrintAlgorithmRun("EnumerateBalancedParenthesis", RunEnumerateParenthesis);
            Utils.PrintAlgorithmRun("EnumeratePowerSet", RunEnumeratePowerSet);
            Utils.PrintAlgorithmRun("GrayCode", RunGrayCode);
        }

        private static void RunSortStack()
        {
            var input = new[] { 9, 12, 7, 4, 17, 8, 7, 3 };

            var stack = new Stack<int>(20);
            for (var i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            Console.WriteLine($"Input: {Utils.FormatArray(input)}");
            SortStack.Sort(stack);

            var output = new int[input.Length];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = stack.Pop();
            }

            Console.WriteLine($"Output: {Utils.FormatArray(output)}");
        }

        private static void RunDoublyLinkedListToBinaryTreeConversion()
        {
            var values = new[] { 2, 3, 4, 6, 7, 9, 13, 15, 17, 19, 20, 22 };

            var doublyLinkedList = new DoublyLinkedList<int>();

            foreach (var key in values.Reverse())
            {
                doublyLinkedList.Insert(key);
            }

            Utils.PrintList(doublyLinkedList.Head);

            var root = ListBinaryTreeConversion.ConvertListToBinaryTree(doublyLinkedList.Head);

            Console.WriteLine("\nOutput tree:");
            PrintListAsBinaryTree(root, values.Length);
        }

        private static void PrintListAsBinaryTree<T>(DoublyLinkedList<T>.Node root, int numElements)
        {
            var height = (int)Math.Ceiling(Math.Log(numElements, 2));

            var nodeCount = (1 << height) - 1;
            var bfsNodes = new Queue<DoublyLinkedList<T>.Node>(1 << height);
            var allNodes = new DoublyLinkedList<T>.Node[nodeCount];

            bfsNodes.Enqueue(root);
            for (var i = 0; i < nodeCount; i++)
            {
                var node = bfsNodes.Dequeue();
                allNodes[i] = node;
                if (node != null)
                {
                    bfsNodes.Enqueue(node.Previous);
                    bfsNodes.Enqueue(node.Next);
                }
                else
                {
                    bfsNodes.Enqueue(null);
                    bfsNodes.Enqueue(null);
                }
            }

            Utils.PrintHeap(allNodes.Select(n => n == null ? " " : n.Value.ToString()).ToArray());
        }

        private static void RunBinaryTreeToListConversion()
        {
            var values = new[] { 15, 6, 20, 3, 7, 17, 19, 22, 2, 4, 13, 9 };

            Console.WriteLine($"Building binary tree from: {Utils.FormatArray(values)} =>\n");

            var tree = new BinarySearchTree<int>();
            foreach (var v in values)
            {
                tree.Add(v);
            }

            Utils.PrintBinaryTree(tree.Root);

            var node = ListBinaryTreeConversion.ConvertBinaryTreeToDoublyLinkedList(tree.Root);

            Console.Write("Output: ");
            while (node != null)
            {
                Console.Write($"{node.Value} ");
                node = node.Right;
            }

            Console.WriteLine();
        }

        private static void RunTowersOfHanoi()
        {
            var from = new Stack<int>(7);
            var to = new Stack <int>(7);

            for (var i = 7; i > 0; --i)
            {
                from.Push(i);
            }

            Console.WriteLine("From:");
            Utils.PrintStack(from);
            Console.WriteLine("To:");
            Utils.PrintStack(to);

            Console.WriteLine("\nRunning Towers of Hanoi\n");
            TowersOfHanoi.Move(from, to);

            Console.WriteLine("From:");
            Utils.PrintStack(from);
            Console.WriteLine("To:");
            Utils.PrintStack(to);
        }

        private static void RunSudokuSolver()
        {
            var sudoku = new byte[][]
                {
                    new byte[] { 0, 1, 2 },
                    new byte[] { 0, 3, 6 },
                    new byte[] { 0, 5, 8 },
                    new byte[] { 1, 0, 5 },
                    new byte[] { 1, 1, 8 },
                    new byte[] { 1, 5, 9 },
                    new byte[] { 1, 6, 7 },
                    new byte[] { 2, 4, 4 },
                    new byte[] { 3, 0, 3 },
                    new byte[] { 3, 1, 7 },
                    new byte[] { 3, 6, 5 },
                    new byte[] { 4, 0, 6 },
                    new byte[] { 4, 8, 4 },
                    new byte[] { 5, 2, 8 },
                    new byte[] { 5, 7, 1 },
                    new byte[] { 5, 8, 3 },
                    new byte[] { 6, 4, 2 },
                    new byte[] { 7, 2, 9 },
                    new byte[] { 7, 3, 8 },
                    new byte[] { 7, 7, 3 },
                    new byte[] { 7, 8, 6 },
                    new byte[] { 8, 3, 3 },
                    new byte[] { 8, 5, 6 },
                    new byte[] { 8, 7, 9 },
                };

            SudokuSolver.Solve(sudoku);
        }

        private static void RunEnumerateParenthesis()
        {
            Console.WriteLine();

            var result = MatchingParenthesis.Enumerate(5);

            for (var r = result.Head; r != null; r = r.Next)
            {
                Console.Write($"{r.Value}");
                if (r.Next != null)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        private static void RunEnumeratePowerSet()
        {
            var set = new[] { 10, 20, 30, 40 };
            Console.WriteLine($"\nSet: { string.Join(", ", set) }");

            var result = PowerSet.EnumeratePowerSet(set);

            Console.Write("PowerSet: ");
            for (var r = result.Head; r != null; r = r.Next)
            {
                Console.Write($"[{string.Join(", ", r.Value)}]");
                if (r.Next != null)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        private static void RunGrayCode()
        {
            var value = 24u;
            var result = GrayCodeConverter.ToGray(value);
            Console.WriteLine($"{value} => {result} {Convert.ToString(result, 2)} (Gray)");
        }
    }
}
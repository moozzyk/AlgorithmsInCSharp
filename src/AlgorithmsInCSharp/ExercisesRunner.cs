using System;
using AlgorithmsInCSharp.Algorithms.Misc;
using AlgorithmsInCSharp.DataStructures;
using AlgorithmsInCSharp.Exercises;

namespace AlgorithmsInCSharp
{
    internal static class ExercisesRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("SortStack", RunSortStack);
            Utils.PrintAlgorithmRun("RecursiveInOrderTraversal", RunIterativeInOrderTraversal);
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

        private static void RunIterativeInOrderTraversal()
        {
            var values = new[] { 15, 6, 20, 3, 7, 17, 19, 22, 2, 4, 13, 9 };

            Console.WriteLine($"Building binary tree from: {Utils.FormatArray(values)} =>\n");

            var tree = new BinarySearchTree<int>();
            foreach (var v in values)
            {
                tree.Add(v);
            }

            Utils.PrintBinaryTree(tree.Root);
            string visited = string.Empty;
            Console.Write("In-Order traversal values: ");
            IterativeInOrderTraversal.Visit(tree.Root, v => Console.Write($"{v.ToString()} "));
            Console.WriteLine();
        }
    }
}
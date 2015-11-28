using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class BinarySearchTreeRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Binary Search Tree", RunBST);
        }
        private static void RunBST()
        {
            var values = new[] {15, 6, 18, 3, 7, 17, 20, 2, 4, 13, 9 };

            Console.WriteLine($"Building binary tree from: {Utils.FormatArray(values)} =>\n");

            var tree = new BinarySearchTree<int>();
            foreach (var v in values)
            {
                tree.Add(v);
            }

            Utils.PrintBinaryTree(tree.Root);

            var searchValues = new[] { 9, 3, 100};
            Console.WriteLine($"Searching values {Utils.FormatArray(searchValues)}");
            foreach(var v in searchValues)
            {
                Console.WriteLine("The tree {0} value {1}",
                    tree.Search(v) == null ? "does not contain" : "contains", v);
            }
        }
    }
}

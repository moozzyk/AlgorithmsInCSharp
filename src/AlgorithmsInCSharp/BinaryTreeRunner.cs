using System;
using AlgorithmsInCSharp.Algorithms;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class BinaryTreeRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Binary Tree", RunBinaryTree);
        }

        private static void RunBinaryTree()
        {
            var values = new[] { 15, 6, 20, 3, 7, 17, 19, 22, 2, 4, 13, 9 };

            Console.WriteLine($"Building binary tree from: {Utils.FormatArray(values)} =>\n");

            var tree = new BinarySearchTree<int>();
            foreach (var v in values)
            {
                tree.Add(v);
            }

            Utils.PrintBinaryTree(tree.Root);

            Traversal(tree.Root);
        }

        private static void Traversal<T>(BinaryTreeNode<T> root)
        {
            var values = string.Empty;
            Trees.RecursivePreOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Recursive Pre-Order traversal: {values}");

            values = string.Empty;
            Trees.IterativePreOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Iterative Pre-Order traversal: {values}");

            values = string.Empty;
            Trees.RecursiveInOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Recursive In-Order traversal: {values}");

            values = string.Empty;
            Trees.IterativeInOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Iterative In-Order traversal: {values}");

            values = string.Empty;
            Trees.RecursivePostOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Recursive Post-Order traversal: {values}");

            values = string.Empty;
            Trees.IterativePostOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Iterative Post-Order traversal: {values}");

            values = string.Empty;
            Trees.BreadthFirstSearch(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Breadth-first traversal: {values}");
        }
    }
}

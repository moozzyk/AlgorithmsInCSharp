using System;
using AlgorithmsInCSharp.Algorithms;
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
            var values = new[] { 15, 6, 20, 3, 7, 17, 19, 22, 2, 4, 13, 9 };

            Console.WriteLine($"Building binary tree from: {Utils.FormatArray(values)} =>\n");

            var tree = new BinarySearchTree<int>();
            foreach (var v in values)
            {
                tree.Add(v);
            }

            Utils.PrintBinaryTree(tree.Root);

            Console.WriteLine($"Minimum : {tree.Minimum().Value}");
            Console.WriteLine($"Maximum : {tree.Maximum().Value}");

            var searchValues = new[] { 9, 3, 100, 20, 2 };
            Console.WriteLine($"Searching values {Utils.FormatArray(searchValues)}");
            foreach(var v in searchValues)
            {
                var node = tree.Search(v);
                Console.Write("The tree {0} value {1}. ",
                    node == null ? "does not contain" : "contains", v);

                if (node != null)
                {
                    var successor = BinarySearchTree<int>.Successor(node);
                    Console.Write("Successor {0}. ", successor != null ? successor.Value.ToString() : "N/A");
                    var predecessor = BinarySearchTree<int>.Predecessor(node);
                    Console.Write("Predecessor {0}.", predecessor != null ? predecessor.Value.ToString() : "N/A");
                }

                Console.WriteLine();
            }

            Traversal(tree.Root);

            var deleteValues = new [] { 15 };
            foreach (var v in deleteValues)
            {
                var node = tree.Search(v);
                Console.WriteLine($"Deleting value: {v}");
                tree.Delete(node);
                Utils.PrintBinaryTree(tree.Root);
                Console.WriteLine();
            }
        }

        private static void Traversal<T>(BinaryTreeNode<T> root)
        {
            var values = string.Empty;
            Trees.PreOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Pre-Order traversal: {values}");

            values = string.Empty;
            Trees.InOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"In-Order traversal: {values}");

            values = string.Empty;
            Trees.PostOrderTraversal(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Post-Order traversal: {values}");

            values = string.Empty;
            Trees.BreadthFirstSearch(root, v => { values += v.ToString() + " "; });
            Console.WriteLine($"Breadth-first traversal: {values}");
        }
    }
}

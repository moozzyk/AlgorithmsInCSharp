using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Algorithms
{
    public static class Trees
    {
        public static int Height<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public static void PreOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                nodeAction(node.Value);
                PreOrderTraversal(node.Left, nodeAction);
                PreOrderTraversal(node.Right, nodeAction);
            }
        }

        public static void InOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, nodeAction);
                nodeAction(node.Value);
                InOrderTraversal(node.Right, nodeAction);
            }
        }

        public static void PostOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left, nodeAction);
                PostOrderTraversal(node.Right, nodeAction);
                nodeAction(node.Value);
            }
        }

        public static void BreadthFirstSearch<T>(BinaryTreeNode<T> root, Action<T> nodeAction)
        {
            var queue = new Queue<BinaryTreeNode<T>>(100);
            queue.Enqueue(root);

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    nodeAction(node.Value);
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
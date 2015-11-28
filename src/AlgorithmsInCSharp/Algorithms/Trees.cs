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
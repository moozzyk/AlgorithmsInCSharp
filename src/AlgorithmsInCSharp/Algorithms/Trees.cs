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

        public static void RecursivePreOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                nodeAction(node.Value);
                RecursivePreOrderTraversal(node.Left, nodeAction);
                RecursivePreOrderTraversal(node.Right, nodeAction);
            }
        }

        public static void RecursiveInOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                RecursiveInOrderTraversal(node.Left, nodeAction);
                nodeAction(node.Value);
                RecursiveInOrderTraversal(node.Right, nodeAction);
            }
        }

        public static void RecursivePostOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> nodeAction)
        {
            if (node != null)
            {
                RecursivePostOrderTraversal(node.Left, nodeAction);
                RecursivePostOrderTraversal(node.Right, nodeAction);
                nodeAction(node.Value);
            }
        }

        public static void IterativeInOrderTraversal<T>(BinaryTreeNode<T> root, Action<T> action)
        {
            var nodes = new Stack<BinaryTreeNode<T>>(20);
            var currentNode = root;

            while (!nodes.IsEmpty || currentNode != null)
            {
                if (currentNode != null)
                {
                    nodes.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = nodes.Pop();
                    action(currentNode.Value);
                    currentNode = currentNode.Right;
                }
            }
        }

        public static void IterativePreOrderTraversal<T>(BinaryTreeNode<T> root, Action<T> action)
        {
            var nodes = new Stack<BinaryTreeNode<T>>(20);
            nodes.Push(root);

            while (!nodes.IsEmpty)
            {
                var currentNode = nodes.Pop();
                if (currentNode != null)
                {
                    action(currentNode.Value);
                    nodes.Push(currentNode.Right);
                    nodes.Push(currentNode.Left);
                }
            }
        }

        public static void IterativePostOrderTraversal<T>(BinaryTreeNode<T> root, Action<T> action)
        {
            var nodes = new Stack<BinaryTreeNode<T>>(20);

            var currentNode = root;
            while (!nodes.IsEmpty || currentNode != null)
            {
                if (currentNode != null)
                {
                    nodes.Push(currentNode);
                    currentNode = currentNode.Left ?? currentNode.Right;
                }
                else
                {
                    var tmp = nodes.Pop();
                    action(tmp.Value);

                    if (!nodes.IsEmpty)
                    {
                        var parent = nodes.Peek();

                        if (tmp == parent.Left)
                        {
                            currentNode = parent.Right;
                        }
                    }
                }
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
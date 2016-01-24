using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Exercises
{
    public static class IterativeInOrderTraversal
    {
        public static void Visit<T>(BinaryTreeNode<T> root, Action<T> action)
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
    }
}
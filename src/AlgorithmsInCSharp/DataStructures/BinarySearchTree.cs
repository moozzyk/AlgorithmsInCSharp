using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class BinarySearchTree<T>
        where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            BinaryTreeNode<T> parent = null;
            var currentNode = Root;
            while (currentNode != null)
            {
                parent = currentNode;

                currentNode =
                    currentNode.Value.CompareTo(value) > 0
                        ? currentNode.Left
                        : currentNode.Right;
            }

            var newNode = new BinaryTreeNode<T> { Value = value };
            if (parent == null)
            {
                Root = newNode;
            }
            else
            {
                if (parent.Value.CompareTo(value) > 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }
        }

        public BinaryTreeNode<T> Delete(BinaryTreeNode<T> value)
        {
            throw new System.NotImplementedException();
        }

        public BinaryTreeNode<T> Search(T value)
        {
            var node = Root;

            while (node != null && node.Value.CompareTo(value) != 0)
            {
                if (node.Value.CompareTo(value) > 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return node;
        }
    }
}
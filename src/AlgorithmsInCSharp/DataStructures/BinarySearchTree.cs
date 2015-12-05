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
                newNode.Parent = parent;

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

        public void Delete(BinaryTreeNode<T> node)
        {
            if (node.Left == null)
            {
                Transplant(node, node.Right);
                return;
            }

            if (node.Right == null)
            {
                Transplant(node, node.Left);
                return;
            }

            var nodeToMove = BinarySearchTree<T>.Minimum(node.Right);

            if (nodeToMove.Parent != node)
            {
                Transplant(nodeToMove, nodeToMove.Right);
                nodeToMove.Right = node.Right;
                nodeToMove.Right.Parent = nodeToMove;
            }

            Transplant(node, nodeToMove);
            nodeToMove.Left = node.Left;
            nodeToMove.Left.Parent = node.Parent;
        }

        private void Transplant(BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
        {
            if (node1.Parent == null)
            {
                Root = node2;
                return;
            }

            if (node1.Parent.Left == node1)
            {
                node1.Parent.Left = node2;
                return;
            }

            node1.Parent.Right = node2;

            if (node2 != null)
            {
                node2.Parent = node1.Parent;
            }
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

        public BinaryTreeNode<T> Minimum()
        {
            return Minimum(Root);
        }

        private static BinaryTreeNode<T> Minimum(BinaryTreeNode<T> node)
        {
            while (node != null && node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public BinaryTreeNode<T> Maximum()
        {
            return Maximum(Root);
        }

        public static BinaryTreeNode<T> Maximum(BinaryTreeNode<T> node)
        {
            while (node != null && node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        public static BinaryTreeNode<T> Successor(BinaryTreeNode<T> node)
        {
            if (node.Right != null)
            {
                return Minimum(node.Right);
            }

            var child = node;
            var parent = node.Parent;
            while (parent != null && parent.Right == child)
            {
                child = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        public static BinaryTreeNode<T> Predecessor(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
            {
                return Maximum(node.Left);
            }

            var child = node;
            var parent = node.Parent;
            while (parent != null && parent.Left == child)
            {
                child = parent;
                parent = parent.Parent;
            }

            return parent;
        }

    }
}
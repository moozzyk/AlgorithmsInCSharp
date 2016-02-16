using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Exercises
{
    public static class ListBinaryTreeConversion
    {
        // Convert a doubly linked list to a height balanced binary tree. You cannot use dynamic
        // memory allocation - reuse the nodes of the list for the tree.
        public static DoublyLinkedList<T>.Node ConvertListToBinaryTree<T>(DoublyLinkedList<T>.Node head)
        {
            var size = 0;
            for (var node = head; node != null; node = node.Next)
            {
                size++;
            }

            return ConvertListToBinaryTree(ref head, 0, size);
        }

        private static DoublyLinkedList<T>.Node ConvertListToBinaryTree<T>(ref DoublyLinkedList<T>.Node node, int left, int right)
        {
            if (left >= right)
            {
                return null;
            }

            var mid = (left + right) / 2;

            var n = ConvertListToBinaryTree(ref node, left, mid);
            var curr = node;
            node = node.Next;
            curr.Previous = n;
            curr.Next = ConvertListToBinaryTree(ref node, mid + 1, right);

            return curr;
        }

        // Convert a binary tree to a double linked list. You cannot use dynamic
        // memory allocation - reuse the nodes of the tree for the list.
        public static BinaryTreeNode<T> ConvertBinaryTreeToDoublyLinkedList<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left != null)
            {
                node.Left = Tail(ConvertBinaryTreeToDoublyLinkedList(node.Left));
                node.Left.Right = node;
            }

            if (node.Right != null)
            {
                node.Right = Head(ConvertBinaryTreeToDoublyLinkedList(node.Right));
                node.Right.Left = node;
            }

            return Head(node);
        }

        private static BinaryTreeNode<T> Tail<T>(BinaryTreeNode<T> node)
        {
            while (node != null && node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        private static BinaryTreeNode<T> Head<T>(BinaryTreeNode<T> node)
        {
            while (node != null && node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}

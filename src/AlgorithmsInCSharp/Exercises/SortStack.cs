using AlgorithmsInCSharp.DataStructures;

/*
Design an algorithm to sort a stack in descending order, i.e., the top of the stack
holds the largest value. The only operations allowed are push, pop, top (which returns
the top of the stack without removing it), and checking if the stack is empty. You
cannot explicitly allocate memory outside of a few words.
*/
namespace AlgorithmsInCSharp.Exercises
{
    public static class SortStack
    {
        public static void Sort(Stack<int> stack)
        {
            if (!stack.IsEmpty)
            {
                var top = stack.Pop();
                Sort(stack);
                InsertSorted(stack, top);
            }
        }

        private static void InsertSorted(Stack<int> stack, int item)
        {
            if (stack.IsEmpty)
            {
                stack.Push(item);
                return;
            }

            if (stack.Peek() > item)
            {
                var tmp = stack.Pop();
                InsertSorted(stack, item);
                stack.Push(tmp);
            }
            else
            {
                stack.Push(item);
            }
        }
    }
}
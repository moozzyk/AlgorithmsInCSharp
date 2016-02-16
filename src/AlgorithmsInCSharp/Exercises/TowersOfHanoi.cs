using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Exercises
{
    public static class TowersOfHanoi
    {
        public static void Move<T>(Stack<T> from, Stack<T> to)
        {
            var height = Height(from);
            var helper = new Stack<T>(height);
            var stacks = new Stack<T>[3] { from, to, helper };
            Move(height, stacks, 0, 1, 2);
        }

        private static void Move<T>(int depth, Stack<T>[] stacks, int from, int to, int helper)
        {
            if (depth > 0)
            {
                Move(depth - 1, stacks, from, helper, to);
                stacks[to].Push(stacks[from].Pop());
                Move(depth - 1, stacks, helper, to, from);
            }
        }

        private static int Height<T>(Stack<T> s)
        {
            if (s.IsEmpty)
            {
                return 0;
            }

            var item = s.Pop();
            var height = 1 + Height(s);
            s.Push(item);
            return height;
        }
    }
}
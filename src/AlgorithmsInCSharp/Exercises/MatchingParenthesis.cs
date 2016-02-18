using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Exercises
{
    public static class MatchingParenthesis
    {
        public static LinkedList<string> Enumerate(int count)
        {
            var result = new LinkedList<string>();
            Enumerate(count, 0, string.Empty, result);
            return result;
        }

        private static void Enumerate(int count, int openParensCount, string str, LinkedList<string> result)
        {
            if (count == 0)
            {
                result.Insert(str + new string(')', openParensCount));
                return;
            }

            if (openParensCount == 0)
            {
                Enumerate(count - 1, openParensCount + 1, str + '(', result);
            }
            else
            {
                Enumerate(count, openParensCount - 1, str + ')', result);
                Enumerate(count - 1, openParensCount + 1, str + '(', result);
            }
        }
    }
}
using AlgorithmsInCSharp.DataStructures;

/*
Implement a method that takes as input a set S of n distinct elements and
prints the power set of S.
*/

namespace AlgorithmsInCSharp.Exercises
{
    public static class PowerSet
    {
        public static LinkedList<int[]> EnumeratePowerSet(int[] set)
        {
            var result = new LinkedList<int[]>();
            result.Insert(new int[0]);
            EnumeratePowerSet(set, 0, new int[0], result);
            return result;
        }

        private static void EnumeratePowerSet(int[] set, int m, int[] subset, LinkedList<int[]> result)
        {
            if (subset.Length > 0)
            {
                result.Insert(subset);
            }

            for (var i = m; i < set.Length; i++)
            {
                var r = new int[subset.Length + 1];
                System.Array.Copy(subset, r, subset.Length);
                r[r.Length - 1] = set[i];
                EnumeratePowerSet(set, i + 1, r, result);
            }
        }
    }
}
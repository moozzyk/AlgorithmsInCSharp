using System;
using System.Linq;
using AlgorithmsInCSharp.Algorithms.MaximumSubarray;

namespace AlgorithmsInCSharp
{
    internal static class MaximumSubarrayRunner
    {
        public static void Run()
        {
            var inputArray = new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4 , 7 };
            RunMaximumSubarray("Maximum subarray O(N^3)", MaximumSubarray_ON3.MaximumSubarray, inputArray);
            RunMaximumSubarray("Maximum subarray O(N^2)", MaximumSubarray_ON2_1.MaximumSubarray, inputArray);
            RunMaximumSubarray("Maximum subarray O(N^2) (array preprocessing)", MaximumSubarray_ON2_2.MaximumSubarray, inputArray);
            RunMaximumSubarray("Maximum subarray O(NlogN)", MaximumSubarray_ONLogN.MaximumSubarray, inputArray);
            RunMaximumSubarray("Maximum subarray O(N)", MaximumSubarray_ON.MaximumSubarray, inputArray);
        }

        private delegate void MaxSubarrayAction(int[] inputArray, out int left, out int right);

        private static void RunMaximumSubarray(string name, MaxSubarrayAction maximumSubarray, int[] inputArray)
        {
            Utils.PrintAlgorithmRun(name, () =>
            {
                int left, right;
                maximumSubarray(inputArray, out left, out right);
                var sum = inputArray.Skip(left).Take(right - left + 1).Sum();
                var maxSubarray = Utils.FormatArray(inputArray.Skip(left).Take(right - left + 1));
                Console.WriteLine($"Sum: {sum}, left: {left}, right: {right}, values: {maxSubarray}");
            });
        }
    }
}

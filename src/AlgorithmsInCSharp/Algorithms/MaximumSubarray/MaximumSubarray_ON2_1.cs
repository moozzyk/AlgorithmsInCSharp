namespace AlgorithmsInCSharp.Algorithms.MaximumSubarray
{
    public class MaximumSubarray_ON2_1
    {
        public static void MaximumSubarray(int[] inputArray, out int maxLeft, out int maxRight)
        {
            maxLeft = maxRight = 0;
            var maxSum = int.MinValue;

            for (var left = 0; left < inputArray.Length; left++)
            {
                int sum = 0;
                for (var right = left; right < inputArray.Length; right++)
                {
                    sum += inputArray[right];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxLeft = left;
                        maxRight = right;
                    }
                }
            }
        }
    }
}
namespace AlgorithmsInCSharp.Algorithms.MaximumSubarray
{
    public class MaximumSubarray_ON3
    {
        public static void MaximumSubarray(int[] inputArray, out int maxLeft, out int maxRight)
        {
            maxLeft = maxRight = 0;
            var maxSum = int.MinValue;

            for (var left = 0; left < inputArray.Length; left++)
            {
                for (var right = left; right < inputArray.Length; right++)
                {
                    int sum = 0;
                    for (var i = left; i <= right; i++)
                    {
                        sum += inputArray[i];
                    }

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
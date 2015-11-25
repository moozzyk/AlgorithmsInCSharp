namespace AlgorithmsInCSharp.Algorithms.MaximumSubarray
{
    public class MaximumSubarray_ON
    {
        public static void MaximumSubarray(int[] inputArray, out int maxLeft, out int maxRight)
        {
            maxLeft = maxRight = 0;
            int maxSum = int.MinValue;

            int sum = 0, left = 0, right = 0;
            for (var i = 0; i < inputArray.Length; i++)
            {
                sum += inputArray[i];

                if (sum >= maxSum)
                {
                    maxSum = sum;
                    maxLeft = left;
                    maxRight = right;
                }

                if (sum < 0)
                {
                    sum = 0;
                    left = right = i + 1;
                }
                else
                {
                    right++;
                }
            }
        }
    }
}
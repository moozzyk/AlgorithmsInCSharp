namespace AlgorithmsInCSharp.Algorithms.MaximumSubarray
{
    public class MaximumSubarray_ON2_2
    {
        public static void MaximumSubarray(int[] inputArray, out int maxLeft, out int maxRight)
        {
            maxLeft = maxRight = 0;

            if (inputArray.Length == 0)
            {
                return;
            }

            var sums = new int[inputArray.Length];
            sums[0] = inputArray[0];
            for (var i = 1; i < inputArray.Length; i++)
            {
                sums[i] = sums[i - 1] + inputArray[i];
            }

            var maxSum = inputArray[0];

            for (var left = 0; left < sums.Length; left++)
            {
                for (var right = left; right < sums.Length; right++)
                {
                    var sum = sums[right] - (left > 0 ? sums[left - 1] : 0);
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
namespace AlgorithmsInCSharp.Algorithms.MaximumSubarray
{
    public class MaximumSubarray_ONLogN
    {
        public static void MaximumSubarray(int[] inputArray, out int maxLeft, out int maxRight)
        {
            int maxSum;
            MaximumSubarray(inputArray, 0, inputArray.Length - 1, out maxLeft, out maxRight, out maxSum);
        }

        private static void MaximumSubarray(int[] inputArray, int left, int right, out int maxLeft, out int maxRight, out int maxSum)
        {
            if (left == right)
            {
                maxLeft = maxRight = left;
                maxSum = inputArray[left];
                return;
            }

            var midPos = left + ((right -left) / 2);

            int mmaxLeft = midPos;
            int mmaxRight = midPos;
            int sum = 0, mleftMaxSum = int.MinValue, mrightMaxSum = int.MinValue;
            for (var i = midPos; i >= left; i--)
            {
                sum += inputArray[i];
                if(sum > mleftMaxSum)
                {
                    mleftMaxSum = sum;
                    mmaxLeft = i;
                }
            }

            sum = 0;
            for (var i = midPos + 1; i <= right; i++)
            {
                sum += inputArray[i];
                if (sum > mrightMaxSum)
                {
                    mrightMaxSum = sum;
                    mmaxRight = i;
                }
            }

            var mmaxSum = mleftMaxSum + mrightMaxSum;

            int lmaxSum, lmaxLeft, lmaxRight;
            MaximumSubarray(inputArray, left, midPos, out lmaxLeft, out lmaxRight, out lmaxSum);

            int rmaxSum, rmaxLeft, rmaxRight;
            MaximumSubarray(inputArray, midPos + 1, right, out rmaxLeft, out rmaxRight, out rmaxSum);

            if (mmaxSum > lmaxSum && mmaxSum > rmaxSum)
            {
                maxSum = mmaxSum;
                maxLeft = mmaxLeft;
                maxRight = mmaxRight;
            }
            else if (lmaxSum > rmaxSum)
            {
                maxSum = lmaxSum;
                maxLeft = lmaxLeft;
                maxRight = lmaxRight;
            }
            else
            {
                maxSum = rmaxSum;
                maxLeft = rmaxLeft;
                maxRight = rmaxRight;
            }
        }
    }
}
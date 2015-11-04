using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    class MaximumSubarray
    {
        public static void ON3(int[] inputArray)
        {
            int maxLeft, maxRight, maxSum;
            maxLeft = maxRight = 0;
            maxSum = int.MinValue;

            for (var left = 0; left < inputArray.Length; left++)
            {
                for (var right = left; right < inputArray.Length; right++)
                {
                    int sum = 0;
                    for (int i = left; i <= right; i++)
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

            Console.Write("Sum: {0}, left: {1}, right: {2}, values: ", maxSum, maxLeft, maxRight);
            Utils.PrintArray(inputArray.Skip(maxLeft).Take(maxRight - maxLeft + 1));
            Console.WriteLine();
        }

        public static void ON2_1(int[] inputArray)
        {
            int maxLeft, maxRight, maxSum;
            maxLeft = maxRight = 0;
            maxSum = int.MinValue;

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

            Console.Write("Sum: {0}, left: {1}, right: {2}, values: ", maxSum, maxLeft, maxRight);
            Utils.PrintArray(inputArray.Skip(maxLeft).Take(maxRight - maxLeft + 1));
            Console.WriteLine();
        }

        public static void ON2_2(int[] inputArray)
        {
            Debug.Assert(inputArray != null && inputArray.Length > 0);

            var sums = new int[inputArray.Length];

            sums[0] = inputArray[0];
            for (var i = 1; i < inputArray.Length; i++)
            {
                sums[i] = sums[i - 1] + inputArray[i];
            }

            int maxLeft, maxRight, maxSum;
            maxLeft = maxRight = 0;
            maxSum = inputArray[0];

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

            Console.Write("Sum: {0}, left: {1}, right: {2}, values: ", maxSum, maxLeft, maxRight);
            Utils.PrintArray(inputArray.Skip(maxLeft).Take(maxRight - maxLeft + 1));
            Console.WriteLine();
        }

        public static void ONlogN(int[] inputArray)
        {
            int maxLeft, maxRight, maxSum;
            ONlogN(inputArray, 0, inputArray.Length - 1, out maxLeft, out maxRight, out maxSum);

            Console.Write("Sum: {0}, left: {1}, right: {2}, values: ", maxSum, maxLeft, maxRight);
            Utils.PrintArray(inputArray.Skip(maxLeft).Take(maxRight - maxLeft + 1));
            Console.WriteLine();
        }

        private static void ONlogN(int[] inputArray, int left, int right, out int maxLeft, out int maxRight, out int maxSum)
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
            ONlogN(inputArray, left, midPos, out lmaxLeft, out lmaxRight, out lmaxSum);

            int rmaxSum, rmaxLeft, rmaxRight;
            ONlogN(inputArray, midPos + 1, right, out rmaxLeft, out rmaxRight, out rmaxSum);

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

        public static void ON(int[] inputArray)
        {
            int maxLeft, maxRight, maxSum;
            maxLeft = maxRight = 0;
            maxSum = int.MinValue;

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

            Console.Write("Sum: {0}, left: {1}, right: {2}, values: ", maxSum, maxLeft, maxRight);
            Utils.PrintArray(inputArray.Skip(maxLeft).Take(maxRight - maxLeft + 1));
            Console.WriteLine();

        }
    }
}

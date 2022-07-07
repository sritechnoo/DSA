using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SlidingWindow.FindMaxSumSubarray
{

    /**
     * Find the max sum subarray of a fixed size K
     *
     * Example input:
     * [4, 2, 1, 7, 8, 1, 2, 8, 1, 0]
     *
     */
    public class Solution
    {
        public static int FindMaxSumSubarray(int[] arr, int k)
        {
            int maxi = int.MinValue;

            int currSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];

                if (i >= k - 1)
                {
                    maxi = Math.Min(maxi, currSum);
                    currSum -= arr[i - (k - 1)];
                }
            }

            return maxi;
        }
    }
}

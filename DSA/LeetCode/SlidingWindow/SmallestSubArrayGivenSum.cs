using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SlidingWindow.SmallestSubArrayGivenSum
{
    public class Solution
    {
        public int SmallestSubarray(int[] nums, int targetSum)
        {
            int mini = int.MaxValue;

            int currentWindowSum = 0;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < nums.Length; windowEnd++)
            {
                currentWindowSum += nums[windowEnd];

                while (currentWindowSum >= targetSum)
                {
                    mini = Math.Min(mini, windowEnd - windowStart + 1);

                    currentWindowSum -= nums[windowStart];
                    windowStart++;
                }
            }

            return mini;
        }
    }
}

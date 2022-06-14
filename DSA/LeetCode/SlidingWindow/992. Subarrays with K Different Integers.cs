using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.SlidingWindow._992SubarrayswithKDifferentIntegers
{
    /*
     * Given an integer array nums and an integer k, return the number of good subarrays of nums.

        A good array is an array where the number of different integers in that array is exactly k.

            For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.

        A subarray is a contiguous part of an array.

        Example 1:

        Input: nums = [1,2,1,2,3], k = 2
        Output: 7
        Explanation: Subarrays formed with exactly 2 different integers: [1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,1,2]

        Example 2:

        Input: nums = [1,2,1,3,4], k = 3
        Output: 3
        Explanation: Subarrays formed with exactly 3 different integers: [1,2,1,3], [2,1,3], [1,3,4].

 

        Constraints:

            1 <= nums.length <= 2 * 104
            1 <= nums[i], k <= nums.length

    */
    public class Solution
    {
        public int SubarraysWithKDistinct(int[] nums, int k)
        {

            /*
                Note: exactly(K) = atMost(K) - atMost(K - 1)
            */

            /*
             *      intuitively,
                    for (i = 0, i < n; i++) {
                      for (j = i; j < n; j++) {
                        if ([i, j] with at most K distinct) numSubarrayAtMostKDistinct++;
                      }
                    }

                    optimize 1, loop j break earlier
                    for (i = 0, i < n; i++) {
                      for (j = i; j < n; j++) {
                        if ([i, j] with at most K distinct) numSubarrayAtMostKDistinct++;
                        else break;
                      }
                    }

                    optimize 2, j doen't restart at i but keeps increasing
                    for (i = 0, i < n; i++) {
                      for (; j < n; j++) {
                        if ([i, j] with at most K distinct) numSubarrayAtMostKDistinct= j - i + 1;
                        else break;
                      }
                    }
                    to check whether [i, j] with at most K distinct
                    we maintain a map chToFreq to record a digit and its corresponding frequency in curret window [i, j]
             */

            return SubarraysAtMost(nums, k) - SubarraysAtMost(nums, k - 1);
        }

        private int SubarraysAtMost(int[] nums, int k)
        {
            Dictionary<int, int> dictMap = new Dictionary<int, int>();

            int ans = 0;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < nums.Length; windowEnd++)
            {
                if (dictMap.ContainsKey(nums[windowEnd]))
                {
                    dictMap[nums[windowEnd]]++;
                }
                else
                {
                    dictMap.Add(nums[windowEnd], 1);
                }

                while (dictMap.Count > k)
                {
                    dictMap[nums[windowStart]]--;
                    if (dictMap[nums[windowStart]] == 0)
                    {
                        dictMap.Remove(nums[windowStart]);
                    }
                    windowStart++;
                }

                ans += windowEnd - windowStart + 1;
            }
            return ans;
        }
    }
}

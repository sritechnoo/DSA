using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._53_Maximum_Subarray
{
    /*Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

    A subarray is a contiguous part of an array.



    Example 1:

    Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
    Output: 6
    Explanation: [4,-1,2,1] has the largest sum = 6.

    Example 2:

    Input: nums = [1]
    Output: 1

    Example 3:

    Input: nums = [5,4,-1,7,8]
    Output: 23



    Constraints:

        1 <= nums.length <= 105
        -104 <= nums[i] <= 104



    Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
    */
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            var tabResult = MaxSubarraySumTabulation(nums);
            var spaceResult = MaxSubarraySumSpace(nums);
            return spaceResult;
        }

        private int MaxSubarraySumTabulation(int[] nums)
        {
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];

            int maxi = dp[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                maxi = Math.Max(dp[i], maxi);
            }
            return maxi;
        }

        private int MaxSubarraySumSpace(int[] nums)
        {
            int prev = nums[0];
            int maxi = prev;
            for (int i = 1; i < nums.Length; i++)
            {
                prev = Math.Max(prev + nums[i], nums[i]);
                maxi = Math.Max(prev, maxi);
            }
            return maxi;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Subsequences._416_Partition_Equal_Subset_Sum
{
    /*Given a non-empty array nums containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.



    Example 1:

    Input: nums = [1,5,11,5]
    Output: true
    Explanation: The array can be partitioned as [1, 5, 5] and [11].

    Example 2:

    Input: nums = [1,2,3,5]
    Output: false
    Explanation: The array cannot be partitioned into equal sum subsets.



    Constraints:

        1 <= nums.length <= 200
        1 <= nums[i] <= 100

    */

    public class Solution
    {
        public bool CanPartition(int[] nums)
        {
            int totalSum = 0;
            for (int i = 0; i < nums.Length; i++) { totalSum += nums[i]; }

            if (totalSum % 2 == 0) { return CanFormSubSeqSumEqualToK(nums, totalSum / 2); }
            return false;
        }

        public bool CanFormSubSeqSumEqualToK(int[] nums, int k)
        {
            int length = nums.Length;
            int[][] dp = new int[length][];
            for (int i = 0; i < length; i++)
            {
                dp[i] = new int[k + 1];
                Array.Fill(dp[i], -1);
            }
            //return DFS(length - 1, nums, k, dp);
            return Tabulation(nums, k);
        }

        private bool DFS(int ind, int[] nums, int target, int[][] dp)
        {
            if (target == 0) { return true; }

            if (ind == 0) { return nums[0] == target; }

            if (dp[ind][target] != -1) { return dp[ind][target] == 1; }

            bool take = false;
            if (target >= nums[ind]) { take = DFS(ind - 1, nums, target - nums[ind], dp); }

            bool notTake = DFS(ind - 1, nums, target, dp);

            dp[ind][target] = take || notTake ? 1 : 0;
            return dp[ind][target] == 1;
        }

        private bool Tabulation(int[] nums, int target)
        {
            bool[][] dp = new bool[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = new bool[target + 1];
                Array.Fill(dp[i], false);
            }

            for (int ind = 0; ind < nums.Length; ind++) { dp[ind][0] = true; }
            dp[0][nums[0]] = true;
                
            for (int ind = 1; ind < nums.Length; ind++)
            {
                for (int targetInd = 1; targetInd < target + 1; targetInd++)
                {
                    bool take = false;
                    if (target >= nums[ind])
                    {
                        take = dp[ind - 1][target - nums[ind]];
                    }
                    bool notTake = dp[ind - 1][target];

                    dp[ind][target] = take || notTake;
                }
            }
            return dp[dp.Length - 1][target];
        }
    }
}
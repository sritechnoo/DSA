using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.LIS._300LongestIncreasingSubsequence
{
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            return LISTab2(nums);
        }

        private int[,] initializeMatrixArray(int height, int width, int defaultValue)
        {
            int[,] matrixArray = new int[height, width];

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    matrixArray[r, c] = defaultValue;
                }
            }
            return matrixArray;
        }

        private int LISRecurse(int[] nums)
        {
            int lengthOfNum = nums.Length;
            int[,] dp = initializeMatrixArray(lengthOfNum, lengthOfNum + 1, -1);
            return LISRecurse(0, -1, nums, dp);
        }

        // Length of Longest Increasing function  starting from curr_index, whose previous index is prev_index
        private int LISRecurse(int curr_index, int prev_index, int[] nums, int[,] dp)
        {
            int numsLength = nums.Length;
            if (curr_index == numsLength)
            {
                return 0;
            }

            if (dp[curr_index, prev_index + 1] != -1)
            {
                return dp[curr_index, prev_index + 1];
            }

            int pickValue = Int32.MinValue;
            if (prev_index == -1 || nums[curr_index] > nums[prev_index])
            {
                pickValue = 1 + LISRecurse(curr_index + 1, curr_index, nums, dp);
            }

            int nonPickValue = 0 + LISRecurse(curr_index + 1, prev_index, nums, dp);

            dp[curr_index, prev_index + 1] = Math.Max(pickValue, nonPickValue);
            return dp[curr_index, prev_index + 1];
        }


        private int LISTab(int[] nums)
        {
            int lengthOfNum = nums.Length;

            int[,] dp = initializeMatrixArray(lengthOfNum + 1, lengthOfNum + 1, 0);

            //curr_index = lengthOfNum-1 to 0
            //prev_index = curr_index-1 to 0
            for (int curr_index = lengthOfNum - 1; curr_index >= 0; curr_index--)
            {
                for (int prev_index = curr_index - 1; prev_index >= 0; prev_index--)
                {

                    int len = 0 + dp[curr_index + 1, prev_index + 1];

                    if (prev_index == -1 || nums[curr_index] > nums[prev_index + 1])
                    {
                        int pickValue = 1 + dp[curr_index + 1, curr_index + 1];
                        len = Math.Max(len, pickValue);
                    }

                    dp[curr_index, prev_index + 1] = len;
                }
            }
            return dp[0, -1 + 1];
        }


        private int LISTab2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            int[] hash = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
                hash[i] = 1;
            }

            int maxi = 0;
            for (int ind = 0; ind < nums.Length; ind++)
            {
                for (int prev_ind = 0; prev_ind < ind; prev_ind++)
                {

                    if (nums[ind] > nums[prev_ind]
                       && 1 + dp[prev_ind] > dp[ind])
                    {

                        dp[ind] = 1 + dp[prev_ind];
                        hash[ind] = prev_ind;
                    }
                }
                maxi = Math.Max(maxi, dp[ind]);
            }
            return maxi;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.PrefixSum.Equilibrium_index_of_an_array
{
    public class Solution
    {
        public int Equilibrium(int[] arr)
        {
            return PreFixAndSuffixSumOptimized(arr);
        }

        private int BruteForce(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int leftSum = 0;
                for (int lefti = 0; lefti < i; lefti++)
                {
                    leftSum += nums[lefti];
                }

                int rightSum = 0;
                for (int righti = i + 1; righti < nums.Length; righti++)
                {
                    rightSum += nums[righti];
                }

                if (leftSum == rightSum) { return i; }
            }
            return -1;
        }

        private int PreFixAndSuffixSum(int[] nums)
        {
            int[] prefixSum = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0) { prefixSum[i] = nums[i]; }
                else { prefixSum[i] = prefixSum[i - 1] + nums[i]; }
            }

            int[] suffixSum = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == nums.Length - 1) { suffixSum[i] = nums[nums.Length - 1]; }
                else { suffixSum[i] = suffixSum[i + 1] + nums[i]; }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (prefixSum[i] == suffixSum[i])
                {
                    return i;
                }
            }

            return -1;
        }

        private int PreFixAndSuffixSumOptimized(int[] nums)
        {
            int totalSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                totalSum += nums[i];
            }

            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int rightSum = totalSum - leftSum - nums[i];

                if (leftSum == rightSum) { return i; }

                leftSum += nums[i];
            }

            return -1;
        }
    }
}

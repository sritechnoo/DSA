using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.PrefixSum.Length_of_the_longest_subarray_with_zero_Sum
{
    /*Problem Statement: Given an array containing both positive and negative integers, we have to find the length of the longest subarray with the sum of all elements equal to zero.

    Example 1:

    Input Format: N = 6, array[] = {9, -3, 3, -1, 6, -5}

    Result: 5

    Explanation: The following subarrays sum to zero:
    {-3, 3} , {-1, 6, -5}, {-3, 3, -1, 6, -5}
    Since we require the length of the longest subarray, our answer is 5!

    Example 2:

    Input Format: N = 8, array[] = {6, -2, 2, -8, 1, 7, 4, -10}

    Result: 8

    Subarrays with sum 0 : {-2, 2}, {-8, 1, 7}, {-2, 2, -8, 1, 7}, {6, -2, 2, -8, 1, 7, 4, -10}
    Length of longest subarray = 8

    Example 3:

    Input Format: N = 3, array[] = {1, 0, -5}

    Result: 1

    Subarray : {0}
    Length of longest subarray = 1

    Example 4:

    Input Format: N = 5, array[] = {1, 3, -5, 6, -2}

    Result: 0

    Subarray: There is no subarray that sums to zero*/

    public class Solution
    {
        public int GetLongestSubArrayWithZeroSumLength(int[] nums)
        {
            //return BruteForce(nums);
            return PrefixSumDictApproach(nums);
        }

        private int BruteForce(int[] nums)
        {

            int maxi = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int currSum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    currSum += nums[j];

                    if (currSum == 0) { maxi = Math.Max(maxi, currSum); }
                }
            }
            return maxi;
        }

        private int PrefixSumDictApproach(int[] nums)
        {
            int maxi = 0;

            Dictionary<int, int> prefixSumMap = new Dictionary<int, int>();
            int prefixSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                if (prefixSum == 0)
                {
                    maxi = Math.Max(maxi, i - 0 + 1);
                }
                else
                {
                    if (prefixSumMap.ContainsKey(prefixSum))
                    {
                        maxi = Math.Max(maxi, i - prefixSumMap[prefixSum]);
                    }
                    else
                    {
                        prefixSumMap.Add(prefixSum, i);
                    }
                }
            }
            return maxi;
        }
    }
}

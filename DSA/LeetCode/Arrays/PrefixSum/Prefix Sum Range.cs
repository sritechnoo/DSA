using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.PrefixSum.Prefix_Sum_Range
{
    /*
    Given an array arr of integers of size n. We need to compute the sum of elements from index i to index j. 
    The queries consisting of i and j index values will be executed multiple times.

    Examples: 

    Input : arr[] = {1, 2, 3, 4, 5}
            i = 1, j = 3
            i = 2, j = 4
    Output :  9
             12         

    Input : arr[] = {1, 2, 3, 4, 5}
            i = 0, j = 4 
            i = 1, j = 2 
    Output : 15
              5
    */
    public class Solution
    {


        public int GetRangeSum(int[] nums, int left, int right)
        {
            int[] preFixSum = GetPrefixSum(nums);

            if (left == 0) { return preFixSum[right]; }

            return preFixSum[right] - preFixSum[left - 1];
        }

        private int[] GetPrefixSum(int[] nums)
        {
            int[] preFixSum = new int[nums.Length];

            preFixSum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                preFixSum[i] = preFixSum[i - 1] + nums[i];
            }
            return preFixSum;
        }
    }
}

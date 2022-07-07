using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.PrefixSum.Find_if_there_is_a_subarray_with_0_sum
{
    /*Given an array of positive and negative numbers, find if there is a subarray (of size at-least one) with 0 sum.

   Examples : 

       Input: {4, 2, -3, 1, 6}
       Output: true 
       Explanation:
       There is a subarray with zero sum from index 1 to 3.

       Input: {4, 2, 0, 1, 6}
       Output: true

       Explanation : 

   Remaining Time -0:27
   1x

   The third element is zero. A single element is also a sub-array.

   Input: {-3, 2, 3, 1, 6}
   Output: false
    */
    public class Solution
    {
        public bool SubArrayWithZeroSumExists(int[] nums)
        {
            return PreFixSumDictApproach(nums);
        }

        private bool PreFixSumDictApproach(int[] nums)
        {
            Dictionary<int, int> preFixSumMap = new Dictionary<int, int>();
            int prefixSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                /* PrefixSum Becomes 0 */
                if (prefixSum == 0) { return true; }
                else
                {
                    /* Prefix Sum Repeats */
                    if (preFixSumMap.ContainsKey(prefixSum)) { return true; }
                    else { preFixSumMap.Add(prefixSum, i); }
                }
            }
            return false;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Prefix_Suffix._238ProductofArrayExceptSelf
{
    /*Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

    You must write an algorithm that runs in O(n) time and without using the division operation.



    Example 1:

    Input: nums = [1,2,3,4]
    Output: [24,12,8,6]

    Example 2:

    Input: nums = [-1,1,0,-3,3]
    Output: [0,0,9,0,0]



    Constraints:

        2 <= nums.length <= 105
        -30 <= nums[i] <= 30
        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.



    Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)
    */

    public class Solution
    {
        /*
         * https://www.enjoyalgorithms.com/blog/product-of-array-except-self
         */
        public int[] ProductExceptSelf(int[] nums)
        {
            return Prefix_Suffix_ProductExceptSelf(nums);
        }

        public int[] Prefix_Suffix_ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;

            int[] prefix = new int[n];
            prefix[0] = 1;
            for (int i = 0 + 1; i < n; i++)
            {
                prefix[i] = prefix[i - 1] * nums[i - 1];
            }

            int[] suffix = new int[n];
            suffix[n - 1] = 1;
            for (int i = n - 1 - 1; i >= 0; i--)
            {
                suffix[i] = suffix[i + 1] * nums[i + 1];
            }

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = prefix[i] * suffix[i];
            }
            return result;
        }

        public int[] Prefix_Suffix_SpaceOptimized_ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;

            int[] result = new int[n];
            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = result[i] * rightProduct;
                rightProduct = rightProduct * nums[i];
            }

            return result;
        }

    }
}

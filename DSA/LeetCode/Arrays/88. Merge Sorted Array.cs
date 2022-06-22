﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._88_Merge_Sorted_Array
{
    /*You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

   Merge nums1 and nums2 into a single array sorted in non-decreasing order.

   The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.



   Example 1:

   Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
   Output: [1,2,2,3,5,6]
   Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
   The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.

   Example 2:

   Input: nums1 = [1], m = 1, nums2 = [], n = 0
   Output: [1]
   Explanation: The arrays we are merging are [1] and [].
   The result of the merge is [1].

   Example 3:

   Input: nums1 = [0], m = 0, nums2 = [1], n = 1
   Output: [1]
   Explanation: The arrays we are merging are [] and [1].
   The result of the merge is [1].
   Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.



   Constraints:

       nums1.length == m + n
       nums2.length == n
       0 <= m, n <= 200
       1 <= m + n <= 200
       -109 <= nums1[i], nums2[j] <= 109



   Follow up: Can you come up with an algorithm that runs in O(m + n) time?
   */
    public class AscOrderComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            MergeApproach2(nums1, m, nums2, n);
        }

        private void MergeApproach1(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums3 = new int[m + n];
            int nums3Index = 0;
            for (int i = 0; i < m; i++) { nums3[nums3Index++] = nums1[i]; }
            for (int i = 0; i < n; i++) { nums3[nums3Index++] = nums2[i]; }

            Array.Sort(nums3, new AscOrderComparer());

            nums3Index = 0;
            for (int i = 0; i < m; i++) { nums1[i] = nums3[nums3Index++]; }
            for (int i = 0; i < n; i++) { nums2[i] = nums3[nums3Index++]; }
        }

        private void MergeApproach2(int[] nums1, int m, int[] nums2, int n)
        {
            int nums1Index = m - 1;
            int nums2Index = n - 1;
            int nums3Index = m + n - 1;

            while (nums1Index >= 0 && nums2Index >= 0)
            {
                if (nums1[nums1Index] > nums2[nums2Index])
                {
                    nums1[nums3Index] = nums1[nums1Index];
                    nums3Index = nums3Index - 1;
                    nums1Index = nums1Index - 1;
                }
                else
                {
                    nums1[nums3Index] = nums2[nums2Index];
                    nums3Index = nums3Index - 1;
                    nums2Index = nums2Index - 1;
                }
            }

            while (nums1Index >= 0)
                nums1[nums3Index--] = nums1[nums1Index--];

            while (nums2Index >= 0)
                nums1[nums3Index--] = nums2[nums2Index--];
        }
    }
}

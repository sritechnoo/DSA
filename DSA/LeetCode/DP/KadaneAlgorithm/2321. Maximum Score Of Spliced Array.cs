using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.KadaneAlgorithm._2321.Maximum_Score_Of_Spliced_Array
{
    /*You are given two 0-indexed integer arrays nums1 and nums2, both of length n.

    You can choose two integers left and right where 0 <= left <= right < n and swap the subarray nums1[left...right] with the subarray nums2[left...right].

        For example, if nums1 = [1,2,3,4,5] and nums2 = [11,12,13,14,15] and you choose left = 1 and right = 2, nums1 becomes [1,12,13,4,5] and nums2 becomes [11,2,3,14,15].

    You may choose to apply the mentioned operation once or not do anything.

    The score of the arrays is the maximum of sum(nums1) and sum(nums2), where sum(arr) is the sum of all the elements in the array arr.

    Return the maximum possible score.

    A subarray is a contiguous sequence of elements within an array. arr[left...right] denotes the subarray that contains the elements of nums between indices left and right (inclusive).



    Example 1:

    Input: nums1 = [60,60,60], nums2 = [10,90,10]
    Output: 210
    Explanation: Choosing left = 1 and right = 1, we have nums1 = [60,90,60] and nums2 = [10,60,10].
    The score is max(sum(nums1), sum(nums2)) = max(210, 80) = 210.

    Example 2:

    Input: nums1 = [20,40,20,70,30], nums2 = [50,20,50,40,20]
    Output: 220
    Explanation: Choosing left = 3, right = 4, we have nums1 = [20,40,20,40,20] and nums2 = [50,20,50,70,30].
    The score is max(sum(nums1), sum(nums2)) = max(140, 220) = 220.

    Example 3:

    Input: nums1 = [7,11,13], nums2 = [1,1,1]
    Output: 31
    Explanation: We choose not to swap any subarray.
    The score is max(sum(nums1), sum(nums2)) = max(31, 3) = 31.



    Constraints:

        n == nums1.length == nums2.length
        1 <= n <= 105
        1 <= nums1[i], nums2[i] <= 104

    */

    public class Solution
    {
        public int MaxSubarraySumSpace(int[] nums)
        {

            int maxiSum = nums[0];

            int currSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currSum = Math.Max(currSum + nums[i], nums[i]);
                maxiSum = Math.Max(currSum, maxiSum);
            }

            return maxiSum;
        }

        public int MaximumsSplicedArray(int[] nums1, int[] nums2)
        {
            int sum1 = 0;
            int[] a_b_array = new int[nums1.Length];
            Array.Fill(a_b_array, 0);

            int sum2 = 0;
            int[] b_a_array = new int[nums2.Length];
            Array.Fill(b_a_array, 0);

            for (int i = 0; i < nums1.Length; i++)
            {
                sum1 = sum1 + nums1[i];
                a_b_array[i] = nums1[i] - nums2[i];


                sum2 = sum2 + nums2[i];
                b_a_array[i] = nums2[i] - nums1[i];
            }

            int a_b_array_result = MaxSubarraySumSpace(a_b_array) + sum2;
            int b_a_array_result = MaxSubarraySumSpace(b_a_array) + sum1;

            return Math.Max(a_b_array_result, b_a_array_result);
        }
    }
}

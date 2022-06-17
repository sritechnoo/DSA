using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Permutations._31_Next_Permutation
{
    /*A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

        For example, for arr = [1,2,3], the following are considered permutations of arr: [1,2,3], [1,3,2], [3,1,2], [2,3,1].

    The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

        For example, the next permutation of arr = [1,2,3] is [1,3,2].
        Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
        While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.

    Given an array of integers nums, find the next permutation of nums.

    The replacement must be in place and use only constant extra memory.



    Example 1:

    Input: nums = [1,2,3]
    Output: [1,3,2]

    Example 2:

    Input: nums = [3,2,1]
    Output: [1,2,3]

    Example 3:

    Input: nums = [1,1,5]
    Output: [1,5,1]



    Constraints:

        1 <= nums.length <= 100
        0 <= nums[i] <= 100

    */

    /* 
     * References
     * https://www.youtube.com/watch?v=LuLCLgMElus
     * https://www.youtube.com/watch?v=6qXO72FkqwM
     */
    /*
     * Scan the array from right to left until an element is found which is smaller than the index at its right. Mark the index of such element as index.
     * Again scan the array from right to left until an element is found which is greater than the element found in the above step. Mark the index of such elements as j.
     * Swap the two elements at indices index and j.
     * Now, reverse the array from index index until the end of the array.
     */
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length == 1) { return; }


            /* Step:1: Find the last peak element previous index */
            /** Scan the array from right to left until an element is found which is smaller than the index at its right. Mark the index of such element as index.*/
            int peakElementPreviousIndex = -1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if ((nums[i] < nums[i + 1]))
                {
                    peakElementPreviousIndex = i;
                    break;
                }
            }

            /* Step:2: Find the next greater element */
            /** Again scan the array from right to left until an element is found which is greater than the element found in the above step. Mark the index of such elements as j.*/
            if (peakElementPreviousIndex > 0)
            {
                int nextGreaterElementIndex = 0;
                for (int i = nums.Length - 1; i >= peakElementPreviousIndex; i--)
                {
                    if (nums[i] > nums[peakElementPreviousIndex])
                    {
                        nextGreaterElementIndex = i;
                        break;
                    }
                }

                /* Step:3: Swap the last peak element previous element and next greater element */
                /** Swap the two elements at indices index and j.*/
                Swap(nums, peakElementPreviousIndex, nextGreaterElementIndex);
            }

            /* Step:4: Reverse the element from peak element*/
            /** Now, reverse the array from index index until the end of the array.*/
            Reverse(nums, peakElementPreviousIndex + 1, nums.Length - 1);

        }

        private void Swap(int[] nums, int indexa, int indexb)
        {
            int temp = nums[indexa];
            nums[indexa] = nums[indexb];
            nums[indexb] = temp;
        }

        private void Reverse(int[] nums, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                Swap(nums, startIndex, endIndex);
                startIndex++;
                endIndex--;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Sorting.MergeSort._912_Sort_an_Array
{
    /*Given an array of integers nums, sort the array in ascending order.



    Example 1:

    Input: nums = [5,2,3,1]
    Output: [1,2,3,5]

    Example 2:

    Input: nums = [5,1,1,2,0,0]
    Output: [0,0,1,1,2,5]



    Constraints:

        1 <= nums.length <= 5 * 104
        -5 * 104 <= nums[i] <= 5 * 104

    */


    public class Solution
    {
        public int[] SortArray(int[] nums)
        {
            MergeSort(nums, 0, nums.Length - 1);
            return nums;
        }

        private void MergeSort(int[] nums, int starti, int endi)
        {
            if (starti >= endi) { return; }

            int midi = (starti + endi) / 2;

            MergeSort(nums, starti, midi);
            MergeSort(nums, midi + 1, endi);

            Merge(nums, starti, midi, endi);
        }

        private void Merge(int[] nums, int starti, int midi, int endi)
        {
            int lefti = starti;
            int righti = midi + 1;

            int[] buffer = new int[endi - starti + 1];
            int bufferi = 0;

            while (lefti <= midi && righti <= endi)
            {
                if (nums[lefti] < nums[righti])
                {
                    buffer[bufferi++] = nums[lefti++];
                }
                else
                {
                    buffer[bufferi++] = nums[righti++];
                }
            }

            while (lefti <= midi) { buffer[bufferi++] = nums[lefti++]; }
            while (righti <= endi) { buffer[bufferi++] = nums[righti++]; }

            for (int i = starti; i <= endi; i++)
            {
                nums[i] = buffer[i - starti];
            }
        }
    }

}

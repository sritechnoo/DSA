using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays
{
    /*Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

    We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

    You must solve this problem without using the library's sort function.



    Example 1:

    Input: nums = [2,0,2,1,1,0]
    Output: [0,0,1,1,2,2]

    Example 2:

    Input: nums = [2,0,1]
    Output: [0,1,2]



    Constraints:

        n == nums.length
        1 <= n <= 300
        nums[i] is either 0, 1, or 2.



    Follow up: Could you come up with a one-pass algorithm using only constant extra space?
    */
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            SortColorsApproach(nums);
        }

        private void SortColorsApproach(int[] nums)
        {
            int zeros = 0;
            int ones = 0;
            int twos = 0;

            foreach (var num in nums)
            {
                switch (num)
                {
                    case 0:
                        zeros++;
                        break;
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                }
            }
            for (int i = 0; i < zeros; i++) { nums[i] = 0; }
            for (int i = 0; i < ones; i++) { nums[zeros + i] = 1; }
            for (int i = 0; i < twos; i++) { nums[zeros + ones + i] = 2; }
        }

        private void SortColorsApproach2_DutchNationalFlagAlgorithm(int[] A, int n)
        {
            /*
             * a[0..low-1] = 0 ==> All the elements towards left side of low is Zero.
             * a[low...mid-1] = 1
             * a[high+1...] = 2 ==> All the element right side of high is Two.
             */
            int lowIndex = 0;
            int midIndex = 0;
            int highIndex = A.Length - 1;

            while (midIndex <= highIndex)
            {
                switch (A[midIndex])
                {
                    case 0:
                        Swap(A, lowIndex, midIndex);
                        lowIndex++;
                        midIndex++;

                        break;
                    case 1:
                        midIndex++;

                        break;
                    case 2:
                        Swap(A, midIndex, highIndex);
                        highIndex--;

                        break;

                }
            }
        }

        private void Swap(int[] A, int aIndex, int bIndex)
        {
            int temp = A[aIndex];
            A[aIndex] = A[bIndex];
            A[bIndex] = temp;
        }

    }
}
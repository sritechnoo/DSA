using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._128_Longest_Consecutive_Sequence
{
    /*Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

    You must write an algorithm that runs in O(n) time.



    Example 1:

    Input: nums = [100,4,200,1,3,2]
    Output: 4
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

    Example 2:

    Input: nums = [0,3,7,2,5,8,4,6,0,1]
    Output: 9



    Constraints:

        0 <= nums.length <= 105
        -109 <= nums[i] <= 109

    */

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            //return LongestConsecutiveBruteForce(nums);
            return LongestConsecutiveHashSet(nums);
        }

        private int LongestConsecutiveBruteForce(int[] nums)
        {
            Array.Sort(nums);

            int maxiLongestLength = 1;
            int currLongestLength = 1;

            int prevNum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int currNum = nums[i];

                if (prevNum == currNum) { continue; }

                if (prevNum + 1 == currNum)
                {
                    currLongestLength++;

                }
                else
                {
                    currLongestLength = 1;
                }


                maxiLongestLength = Math.Max(maxiLongestLength, currLongestLength);
                prevNum = currNum;
            }
            return maxiLongestLength;
        }


        /*We will first push all are elements in the HashSet. 
        Then we will run a for loop and check for any number(x) 
        if it is the starting number of the consecutive sequence by checking if the HashSet contains (x-1) or not.
        If ‘x’ is the starting number of the consecutive sequence we will keep searching for the numbers y = x+1, x+2, x+3, ….. 
        And stop at the first ‘y’ which is not present in the HashSet. 
        Using this we can calculate the length of the longest consecutive subsequence. */

        private int LongestConsecutiveHashSet(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            int maxiLongestLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int currNum = nums[i];
                int prevNum = currNum - 1;

                /*Check Current Number is the starting number for longest Sequence or not*/
                if (set.Contains(prevNum) == false)
                {
                    int currLongestLength = 1;
                    while (set.Contains(currNum + 1))
                    {
                        currNum += 1;
                        currLongestLength += 1;
                    }
                    maxiLongestLength = Math.Max(maxiLongestLength, currLongestLength);
                }
            }
            return maxiLongestLength;
        }
    }
}

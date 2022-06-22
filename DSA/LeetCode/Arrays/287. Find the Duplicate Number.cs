using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._287_Find_the_Duplicate_Number
{
    /*Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

    There is only one repeated number in nums, return this repeated number.

    You must solve the problem without modifying the array nums and uses only constant extra space.



    Example 1:

    Input: nums = [1,3,4,2,2]
    Output: 2

    Example 2:

    Input: nums = [3,1,3,4,2]
    Output: 3



    Constraints:

        1 <= n <= 105
        nums.length == n + 1
        1 <= nums[i] <= n
        All the integers in nums appear only once except for precisely one integer which appears two or more times.



    Follow up:

        How can we prove that at least one duplicate number must exist in nums?
        Can you solve the problem in linear runtime complexity?

    */

    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            return FindDuplicateApproach(nums);
        }

        private int FindDuplicateApproach(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) { return nums[i]; }
            }

            return -1;
        }

        public int FindDuplicateApproach2(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (int num in nums)
            {
                if (seen.Contains(num)) { return num; }

                seen.Add(num);
            }
            return -1;
        }

        public int FindDuplicateApproach_Negative_Marking(int[] nums)
        {
            int duplicate = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                int cur = Math.Abs(nums[i]);
                if (nums[cur] < 0)
                {
                    duplicate = cur;
                    break;
                }
                nums[cur] = nums[cur] * -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Abs(nums[i]);
            }

            return duplicate;
        }

        public static int FindDuplicate_FastAndSlowPointer(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];
            do
            {
                slow = nums[slow]; /*slow.next*/
                fast = nums[nums[fast]];/*fast.next.next*/
            } while (slow != fast);

            fast = nums[0];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;
        }
    }
}


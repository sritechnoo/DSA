using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._18_4Sum
{
    /*Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

        0 <= a, b, c, d < n
        a, b, c, and d are distinct.
        nums[a] + nums[b] + nums[c] + nums[d] == target

    You may return the answer in any order.



    Example 1:

    Input: nums = [1,0,-1,0,-2,2], target = 0
    Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

    Example 2:

    Input: nums = [2,2,2,2,2], target = 8
    Output: [[2,2,2,2]]



    Constraints:

        1 <= nums.length <= 200
        -109 <= nums[i] <= 109
        -109 <= target <= 109

    */
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            return FourSum_UsingThreePointer(nums, target);
        }

        private IList<IList<int>> FourSum_UsingThreePointer(int[] nums, int target)
        {
            Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();

            for (int ai = 0; ai < nums.Length; ai++)
            {
                long a = nums[ai];

                for (int bi = ai + 1; bi < nums.Length; bi++)
                {
                    long b = nums[bi];


                    long ci = bi + 1;
                    long di = nums.Length - 1;
                    while (ci < di)
                    {
                        int c = nums[ci];
                        int d = nums[di];

                        if (a + b + c + d == target)
                        {
                            List<int> quad = new List<int>();
                            quad.Add((int)a);
                            quad.Add((int)b);
                            quad.Add((int)c);
                            quad.Add((int)d);
                            result.Add(quad);

                            // Processing the duplicates of number c
                            while (ci < di && nums[ci] == c) ++ci;

                            // Processing the duplicates of number d
                            while (ci < di && nums[di] == d) --di;
                        }
                        else if (a + b + c + d > target)
                        {
                            di--;
                        }
                        else
                        {
                            ci++;
                        }
                    }

                    // Processing the duplicates of number b
                    while (bi + 1 < nums.Length && nums[bi + 1] == b) ++bi;
                }

                // Processing the duplicates of number a
                while (ai + 1 < nums.Length && nums[ai + 1] == a) ++ai;
            }

            return result;
        }
    }
}

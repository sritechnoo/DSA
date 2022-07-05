using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace DSA.LeetCode.Arrays._1_Two_Sum
{
    /*Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

    You may assume that each input would have exactly one solution, and you may not use the same element twice.

    You can return the answer in any order.



    Example 1:

    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

    Example 2:

    Input: nums = [3,2,4], target = 6
    Output: [1,2]

    Example 3:

    Input: nums = [3,3], target = 6
    Output: [0,1]



    Constraints:

        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.
    */
    public class PairNode
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }

    public class AscByValueComparer : IComparer<PairNode>
    {
        public int Compare(PairNode a, PairNode b) => a.Value.CompareTo(b.Value);
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            return TwoSumTwoPointerReturnIndex(nums, target);
        }

        private int[] TwoSumTwoPointerReturnIndex(int[] nums, int target)
        {
            var originalArray = nums.Select((value, index) => new PairNode { Value = value, Index = index }).ToArray();

            Array.Sort(originalArray, new AscByValueComparer());

            int lowi = 0;
            int highi = nums.Length - 1;

            while (lowi <= highi)
            {
                int first = nums[lowi];
                int second = nums[highi];

                if (first + second == target)
                {
                    var resultedPairs = originalArray.Where((pair, index) => pair.Value == first || pair.Value == second);

                    return new int[]
                    {
                      originalArray.ElementAt(0).Index,
                      originalArray.ElementAt(1).Index,
                    };
                }

                if (first + second > target)
                {
                    highi--;
                }
                else
                {
                    lowi++;
                }
            }

            return new int[] { -1, -1 };
        }

        private int[] TwoSumHashTable(int[] nums, int target)
        {
            Hashtable htValueIndexPair = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int curValue = nums[i];
                int diff = target - curValue;

                if (htValueIndexPair[diff] != null)
                {
                    return new int[] { (int)htValueIndexPair[diff], i };
                }
                else
                {
                    if (htValueIndexPair.ContainsKey(curValue))
                    {
                        htValueIndexPair[curValue] = i;
                    }
                    else
                    {
                        htValueIndexPair.Add(curValue, i);
                    }

                }
            }
            return new int[] { -1, -1 };
        }

        private int[] TwoSumTwoPointerReturnNumber(int[] nums, int target)
        {

            Array.Sort(nums);

            int lowi = 0;
            int highi = nums.Length - 1;

            while (lowi <= highi)
            {
                int first = nums[lowi];
                int second = nums[highi];

                if (first + second == target)
                {
                    return new int[] { first, second };
                }

                if (first + second > target)
                {
                    highi--;
                }
                else
                {
                    lowi++;
                }
            }

            return new int[] { -1, -1 };
        }
    }
}

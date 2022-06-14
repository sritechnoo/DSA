using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.BackTrack._46Permutations
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            int numsLength = nums.Length;

            IList<IList<int>> result = new List<IList<int>>{};

            IList<int> ds = new List<int>();

            bool[] map = new bool[numsLength];
            Array.Fill(map, false);

            PermutateRecur(nums, result, ds, map);
            return result;
        }

        private void PermutateRecur(int[] nums, IList<IList<int>> result, IList<int> ds, bool[] map)
        {
            if (ds.Count == nums.Length)
            {
                result.Add(new List<int>(ds));
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (map[i] == false)
                {
                    map[i] = true;
                    ds.Add(nums[i]);
                    PermutateRecur(nums, result, ds, map);
                    ds.RemoveAt(ds.Count - 1);
                    map[i] = false;
                }
            }
        }
    }
}

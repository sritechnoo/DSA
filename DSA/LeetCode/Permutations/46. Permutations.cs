using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Permutations._46_Permutations
{
    /*Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.



    Example 1:

    Input: nums = [1,2,3]
    Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

    Example 2:

    Input: nums = [0,1]
    Output: [[0,1],[1,0]]

    Example 3:

    Input: nums = [1]
    Output: [[1]]



    Constraints:

        1 <= nums.length <= 6
        -10 <= nums[i] <= 10
        All the integers of nums are unique.

    */
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            int numsLength = nums.Length;

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> ds = new List<int>();

            bool[] map = new bool[numsLength];
            Array.Fill(map, false);

            dfs(nums, result, ds, map);
            return result;
        }

        private void dfs(int[] nums, IList<IList<int>> result, IList<int> ds, bool[] map)
        {
            if (ds.Count == nums.Length)
            {
                result.Add(new List<int>(ds));
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (map[i] == true) { continue; }

                map[i] = true;
                ds.Add(nums[i]);
                dfs(nums, result, ds, map);
                ds.RemoveAt(ds.Count - 1);
                map[i] = false;
            }
        }
    }
}

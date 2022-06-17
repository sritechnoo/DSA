using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Permutations._47_PermutationsII
{
    /*Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.



    Example 1:

    Input: nums = [1,1,2]
    Output:
    [[1,1,2],
     [1,2,1],
     [2,1,1]]

    Example 2:

    Input: nums = [1,2,3]
    Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]



    Constraints:

        1 <= nums.length <= 8
        -10 <= nums[i] <= 10

    */

    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            int numsLength = nums.Length;

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> ds = new List<int>();

            bool[] map = new bool[numsLength];
            Array.Fill(map, false);

            Array.Sort(nums);

            Dfs(nums, result, ds, map);
            return result;
        }

        private void Dfs(int[] nums, IList<IList<int>> result, IList<int> ds, bool[] map)
        {
            if (ds.Count == nums.Length)
            {
                result.Add(new List<int>(ds));
            }

            for (int ind = 0; ind < nums.Length; ind++)
            {
                if (map[ind] == true) { continue; }

                if (ind > 0 && nums[ind] == nums[ind - 1] && !map[ind - 1]) { continue; }

                map[ind] = true;
                ds.Add(nums[ind]);
                Dfs(nums, result, ds, map);
                ds.RemoveAt(ds.Count - 1);
                map[ind] = false;
            }
        }
    }
}

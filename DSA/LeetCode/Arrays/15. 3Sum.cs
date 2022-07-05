using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._15_3Sum
{
    /*Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

    Notice that the solution set must not contain duplicate triplets.



    Example 1:

    Input: nums = [-1,0,1,2,-1,-4]
    Output: [[-1,-1,2],[-1,0,1]]

    Example 2:

    Input: nums = []
    Output: []

    Example 3:

    Input: nums = [0]
    Output: []



    Constraints:

        0 <= nums.length <= 3000
        -105 <= nums[i] <= 105

    */
    public class SetEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] a, int[] b)
        {
            return a[0] == b[0]
                   && a[1] == b[1]
                   && a[2] == b[2];
        }

        public int GetHashCode(int[] x)
        {
            int hCode = x[0] ^ x[1] ^ x[2];
            return hCode.GetHashCode();
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //return ThreeSum_HashTable(nums);
            return ThreeSum_UsingTwoPointer(nums);
        }

        private IList<IList<int>> ThreeSum_HashTable(int[] nums, bool isUniqueRecordOnly = true)
        {
            Dictionary<int, int> hashTable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashTable.ContainsKey(nums[i]) == false) { hashTable.Add(nums[i], 0); }
                hashTable[nums[i]]++;
            }

            HashSet<int[]> resultSet = new HashSet<int[]>(new SetEqualityComparer());

            /* a + b + c = 0 */
            /* c = -(a + b)*/
            for (int ai = 0; ai < nums.Length; ai++)
            {
                hashTable[nums[ai]]--;
                for (int bi = ai + 1; bi < nums.Length; bi++)
                {
                    hashTable[nums[bi]]--;

                    int c = -(nums[ai] + nums[bi]);

                    if (hashTable.ContainsKey(c) && hashTable[c] > 0)
                    {
                        var resultItem = new int[] { nums[ai], nums[bi], c };

                        if (isUniqueRecordOnly)
                        {
                            Array.Sort(resultItem);
                            resultSet.Add(resultItem);
                        }
                        else
                        {
                            resultSet.Add(resultItem);
                        }
                    }

                    hashTable[nums[bi]]++;
                }
                hashTable[nums[ai]]++;
            }

            var returnResult = resultSet.Select(x => x.ToList() as IList<int>);
            return returnResult.ToList();
        }

        private IList<IList<int>> ThreeSum_UsingTwoPointer(int[] nums)
        {
            /* a + b + c = 0 */
            /* b + c  = -a */
            Array.Sort(nums);

            var result = new List<IList<int>>();

            for (int ai = 0; ai < nums.Length - 2; ai++)
            {
                /*Ignoring all the duplicate a */
                if (ai == 0 || ai > 0 && nums[ai - 1] != nums[ai])
                {
                    int bi = ai + 1;
                    int ci = nums.Length - 1;

                    int sum = 0 - nums[ai];

                    while (bi < ci)
                    {
                        int a = nums[ai];
                        int b = nums[bi];
                        int c = nums[ci];

                        if (b + c == sum)
                        {
                            result.Add(new List<int> { a, b, c });

                            /* Ignoring all the duplicate b and c*/
                            while (bi < ci && nums[bi] == nums[bi + 1]) bi++;
                            while (bi < ci && nums[ci] == nums[ci - 1]) ci--;

                            bi++; ci--;
                        }
                        else if (b + c > sum)
                        {
                            ci--;
                        }
                        else
                        {
                            bi++;
                        }

                    }
                }
            }

            return result;
        }
    }
}

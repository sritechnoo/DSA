using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._Pair_Sum
{
    /*You are given an integer array 'ARR' of size 'N' and an integer 'S'. Your task is to return the list of all pairs of elements such that each sum of elements of each pair equals 'S'.
    Note:

    Each pair should be sorted i.e the first value should be less than or equals to the second value. 

    Return the list of pairs sorted in non-decreasing order of their first value. In case if two pairs have the same first value, the pair with a smaller second value should come first.

    Input Format:

    The first line of input contains two space-separated integers 'N' and 'S', denoting the size of the input array and the value of 'S'.

    The second and last line of input contains 'N' space-separated integers, denoting the elements of the input array: ARR[i] where 0 <= i < 'N'.

    Output Format:

    Print 'C' lines, each line contains one pair i.e two space-separated integers, where 'C' denotes the count of pairs having sum equals to given value 'S'.

    Note:

    You are not required to print the output, it has already been taken care of. Just implement the function.

    Constraints:

    1 <= N <= 10^4
    -10^5 <= ARR[i] <= 10^5
    -2 * 10^5 <= S <= 2 * 10^5

    Time Limit: 1 sec

    Sample Input 1:

    5 5
    1 2 3 4 5

    Sample Output 1:

    1 4
    2 3

    Explaination For Sample Output 1:

    Here, 1 + 4 = 5
          2 + 3 = 5
    Hence the output will be, (1,4) , (2,3).

    Sample Input 2:

    5 0
    2 -3 3 3 -2

    Sample Output 2:

    -3 3
    -3 3
    -2 2

    */

    public class Solution
    {
        public int[][] PairSum(int[] arr, int s)
        {
            var pairCount = GetPairSumCount_1(arr, s);
            return PairSumBruteForce(arr, s);

        }

        private int[][] PairSumBruteForce(int[] arr, int sum)
        {
            List<List<int>> lst = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                int firstNumber = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int secondNumber = arr[j];

                    if (firstNumber + secondNumber == sum)
                    {
                        lst.Add(new List<int> { firstNumber, secondNumber });
                    }
                }
            }
            return lst.Select(x => x.ToArray()).ToArray();
        }

        private int GetPairSumCount_1(int[] arr, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map[arr[i]] = 0;
                }
                map[arr[i]] = map[arr[i]] + 1;
            }


            int twice_count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var diff = sum - arr[i];
                if (map[diff] != 0)
                {
                    twice_count += map[sum - arr[i]];
                }

                // if (arr[i], arr[i]) pair satisfies
                // the condition, then we need to ensure
                // that the count is decreased by one
                // such that the (arr[i], arr[i])
                // pair is not considered
                if (diff == arr[i])
                {
                    twice_count--;
                }
            }

            // return the half of twice_count
            return twice_count / 2;
        }

        private int GetPairSumCount_2(int[] arr, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currNo = arr[i];
                int diff = sum - currNo;
                if (map.ContainsKey(diff))
                {
                    count += map[diff];
                }

                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]] = map[arr[i]] + 1;
                }
                else
                {
                    map.Add(arr[i], 1);
                }
            }
            return count;
        }

    }
}

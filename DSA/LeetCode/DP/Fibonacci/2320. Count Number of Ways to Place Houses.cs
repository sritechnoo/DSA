using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Fibonacci._2320_Count_Number_of_Ways_to_Place_Houses
{
    /*There is a street with n * 2 plots, where there are n plots on each side of the street. The plots on each side are numbered from 1 to n. On each plot, a house can be placed.

    Return the number of ways houses can be placed such that no two houses are adjacent to each other on the same side of the street. Since the answer may be very large, return it modulo 109 + 7.

    Note that if a house is placed on the ith plot on one side of the street, a house can also be placed on the ith plot on the other side of the street.



    Example 1:

    Input: n = 1
    Output: 4
    Explanation: 
    Possible arrangements:
    1. All plots are empty.
    2. A house is placed on one side of the street.
    3. A house is placed on the other side of the street.
    4. Two houses are placed, one on each side of the street.
    */

    public class Solution
    {
        private const long MOD = 1000000007;
        public int CountHousePlacements(int n)
        {
            Dictionary<string, long> dp = new Dictionary<string, long>();
            long withOutFilled = DFS(n, false, dp);
            long withFilled = DFS(n, true, dp);

            long no_ways_for_one_side = (withOutFilled + withFilled) % MOD;

            return (int)((no_ways_for_one_side * no_ways_for_one_side) % MOD);
        }

        long DFS(int n, bool is_filled, Dictionary<string, long> dp)
        {
            if (n == 1)
                return 1;

            var dpKey = n.ToString() + '-' + is_filled.ToString();
            if (dp.ContainsKey(dpKey)) { return dp[dpKey]; }

            long result = 0;
            if (is_filled)
                result = DFS(n - 1, false, dp);
            else
                result = (DFS(n - 1, true, dp) + DFS(n - 1, false, dp)) % MOD;

            dp.Add(dpKey, result);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP._70_Climbing_Stairs
{
    /*You are climbing a staircase. It takes n steps to reach the top.

    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?



    Example 1:

    Input: n = 2
    Output: 2
    Explanation: There are two ways to climb to the top.
    1. 1 step + 1 step
    2. 2 steps

    Example 2:

    Input: n = 3
    Output: 3
    Explanation: There are three ways to climb to the top.
    1. 1 step + 1 step + 1 step
    2. 1 step + 2 steps
    3. 2 steps + 1 step



    Constraints:

        1 <= n <= 45

    */

    public class Solution
    {
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            return DFS(n, dp);
        }

        private int DFS(int ind, int[] dp)
        {
            if (ind == 0) return 1;
            if (ind < 0) return 0;

            if (dp[ind] != -1) { return dp[ind]; }

            int oneStepSubProbResult = DFS(ind - 1, dp);
            int twoStepSubProbResult = DFS(ind - 2, dp);

            return dp[ind] = oneStepSubProbResult + twoStepSubProbResult;
        }
    }
}

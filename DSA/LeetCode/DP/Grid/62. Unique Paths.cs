﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Grid._62_Unique_Paths
{
    /*There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

    Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

    The test cases are generated so that the answer will be less than or equal to 2 * 109.



    Example 1:

    Input: m = 3, n = 7
    Output: 28

    Example 2:

    Input: m = 3, n = 2
    Output: 3
    Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
    1. Right -> Down -> Down
    2. Down -> Down -> Right
    3. Down -> Right -> Down



    Constraints:

        1 <= m, n <= 100

    */

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int r = 0; r < m; r++)
            {
                dp[r] = new int[n];
                Array.Fill(dp[r], -1);
            }
            return DFS(0, 0, m, n, dp);
        }

        private int DFS(int rowIndex, int colIndex, int m, int n, int[][] dp)
        {
            if (rowIndex == m - 1 && colIndex == n - 1) { return 1; }

            if (rowIndex >= m || colIndex >= n) { return 0; }

            if (dp[rowIndex][colIndex] != -1) { return dp[rowIndex][colIndex]; }

            int down = DFS(rowIndex + 1, colIndex, m, n, dp);
            int right = DFS(rowIndex, colIndex + 1, m, n, dp);

            return dp[rowIndex][colIndex] = down + right;
        }
    }
}

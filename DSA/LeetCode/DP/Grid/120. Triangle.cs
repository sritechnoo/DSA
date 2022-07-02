using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Grid._120_Triangle
{
    /*Given a triangle array, return the minimum path sum from top to bottom.

    For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.



    Example 1:

    Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
    Output: 11
    Explanation: The triangle looks like:
       2
      3 4
     6 5 7
    4 1 8 3
    The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

    Example 2:

    Input: triangle = [[-10]]
    Output: -10



    Constraints:

        1 <= triangle.length <= 200
        triangle[0].length == 1
        triangle[i].length == triangle[i - 1].length + 1
        -104 <= triangle[i][j] <= 104


    Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?*/

    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int[][] dp = new int[triangle.Count][];
            for (int r = 0; r < triangle.Count; r++)
            {
                dp[r] = new int[r + 1];
                Array.Fill(dp[r], -1);
            }

            return DFS(0, 0, triangle, dp);
        }

        private int DFS(int r, int c, IList<IList<int>> triangle, int[][] dp)
        {
            if (dp[r][c] != -1) { return dp[r][c]; }

            if (r == triangle.Count - 1) return triangle[r][c];

            int down = triangle[r][c] + DFS(r + 1, c, triangle, dp);
            int diagonal = triangle[r][c] + DFS(r + 1, c + 1, triangle, dp);

            return dp[r][c] = Math.Min(down, diagonal);
        }
    }
}

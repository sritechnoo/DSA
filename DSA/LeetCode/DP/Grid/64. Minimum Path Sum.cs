using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Grid._64_Minimum_Path_Sum
{
    /*Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

    Note: You can only move either down or right at any point in time.



    Example 1:

    Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
    Output: 7
    Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

    Example 2:

    Input: grid = [[1,2,3],[4,5,6]]
    Output: 12



    Constraints:

        m == grid.length
        n == grid[i].length
        1 <= m, n <= 200
        0 <= grid[i][j] <= 100

    */

    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            var result = MinPathSumFromZerothIndex(grid);
            return result;
        }

        public int MinPathSumFromZerothIndex(int[][] grid)
        {
            return DFSFromZerothIndex(0, 0, grid); ;
        }

        int DFSFromZerothIndex(int rowIndex, int colIndex, int[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            if (rowIndex == rowLength - 1 && colIndex == colLength - 1) { return grid[rowIndex][colIndex]; }

            if (rowIndex == rowLength - 1) { return grid[rowIndex][colIndex] + DFSFromZerothIndex(rowIndex, colIndex + 1, grid); }

            if (colIndex == rowLength - 1) { return grid[rowIndex][colIndex] + DFSFromZerothIndex(rowIndex + 1, colIndex, grid); }

            int rightSubProbResult = grid[rowIndex][colIndex] + DFSFromZerothIndex(rowIndex, colIndex + 1, grid);
            int downSubProbResult = grid[rowIndex][colIndex] + DFSFromZerothIndex(rowIndex + 1, colIndex, grid);

            return Math.Max(rightSubProbResult, downSubProbResult);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Grid._980_Unique_Paths_III
{
    /*You are given an m x n integer array grid where grid[i][j] could be:

        1 representing the starting square. There is exactly one starting square.
        2 representing the ending square. There is exactly one ending square.
        0 representing empty squares we can walk over.
        -1 representing obstacles that we cannot walk over.

    Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.



    Example 1:

    Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
    Output: 2
    Explanation: We have the following two paths: 
    1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
    2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)

    Example 2:

    Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,0,2]]
    Output: 4
    Explanation: We have the following four paths: 
    1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
    2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
    3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
    4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)

    Example 3:

    Input: grid = [[0,1],[2,0]]
    Output: 0
    Explanation: There is no path that walks over every empty square exactly once.
    Note that the starting and ending square can be anywhere in the grid.



    Constraints:

        m == grid.length
        n == grid[i].length
        1 <= m, n <= 20
        1 <= m * n <= 20
        -1 <= grid[i][j] <= 2
        There is exactly one starting cell and one ending cell.

    */

    public class Solution
    {
        public int UniquePathsIII(int[][] grid)
        {
            int emptyCellCount = 0;

            int startRow = -1;
            int startCol = -1;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 0)
                    {
                        emptyCellCount++;
                    }

                    if (grid[r][c] == 1)
                    {
                        startRow = r;
                        startCol = c;
                    }
                }
            }

            return DFS_BackTrack(startRow, startCol, grid, 0, emptyCellCount + 1);
        }

        private int DFS_BackTrack(int rowIndex, int colIndex, int[][] grid, int currEmptyCellCount, int totalEmptyCount)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            if (rowIndex < 0 || rowIndex >= rowLength
              || colIndex < 0 || colIndex >= colLength
              || grid[rowIndex][colIndex] == -1)
            {
                return 0;
            }

            if (grid[rowIndex][colIndex] == 2)
            {
                if (currEmptyCellCount == totalEmptyCount) { return 1; }
                else { return 0; }
            }

            int result = 0;
            List<(int, int)> dirs = new List<(int, int)> { (1, 0), (0, 1), (0, -1), (-1, 0) };

            grid[rowIndex][colIndex] = -1;
            foreach (var dir in dirs)
            {
                int newRowIndex = rowIndex + dir.Item1;
                int newColIndex = colIndex + dir.Item2;
                result += DFS_BackTrack(newRowIndex, newColIndex, grid, currEmptyCellCount + 1, totalEmptyCount);
            }
            grid[rowIndex][colIndex] = 0;

            return result;
        }
    }
}

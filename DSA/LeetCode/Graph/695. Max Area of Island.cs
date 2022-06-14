using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._695MaxAreaofIsland
{
    public class Solution
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            return new DFSApproach().MaxAreaOfIslands(grid);
        }
    }

    public class DFSApproach
    {
        public DFSApproach()
        {

        }

        public int MaxAreaOfIslands(int[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            bool[][] visited = new bool[rowLength][];
            for (int r = 0; r < rowLength; r++)
            {
                visited[r] = new bool[colLength];
                Array.Fill(visited[r], false);
            }


            int maxAreaOfIsland = 0;
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (grid[r][c] == 1 && visited[r][c] == false)
                    {
                        int areaOfIsland = DFS(grid, r, c, visited);
                        maxAreaOfIsland = Math.Max(maxAreaOfIsland, areaOfIsland);
                    }
                }
            }

            return maxAreaOfIsland;
        }

        private List<(int, int)> directions = new List<(int, int)> { (-1, 0), (1, 0), (0, -1), (0, 1) };
        public int DFS(int[][] grid, int r, int c, bool[][] visited)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            visited[r][c] = true;
            int areaOfIsland = 1;

            foreach (var dir in directions)
            {
                int newr = r + dir.Item1;
                int newc = c + dir.Item2;

                if ((newr >= 0 && newr < rowLength)
                   && (newc >= 0 && newc < colLength)
                   && (grid[newr][newc] == 1 && visited[newr][newc] == false)
                )
                {
                    areaOfIsland += DFS(grid, newr, newc, visited);
                }
            }
            return areaOfIsland;
        }
    }
}

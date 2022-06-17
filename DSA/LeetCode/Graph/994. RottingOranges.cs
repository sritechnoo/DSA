using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._994RottingOranges
{
    public class Solution
    {

        //0 representing an empty cell,
        //1 representing a fresh orange, or
        //2 representing a rotten orange.
        public int OrangesRotting(int[][] grid)
        {
            return new BFSDistance().OrangesRotting(grid);
        }
    }

    public class BFSDistance
    {
        public BFSDistance()
        {

        }

        public int OrangesRotting(int[][] grid)
        {

            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            int[][] dist = new int[rowLength][];
            for (int r = 0; r < rowLength; r++)
            {
                dist[r] = new int[colLength];
                Array.Fill(dist[r], 0);
            }


            Queue<(int, int)> rottenQueue = new Queue<(int, int)>();
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        rottenQueue.Enqueue((r, c));
                    }
                    else if (grid[r][c] == 1)
                    {
                        dist[r][c] = int.MaxValue;
                    }
                }
            }

            List<(int, int)> directions = new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) };

            while (rottenQueue.Count > 0)
            {
                (int, int) u = rottenQueue.Dequeue();
                int ux = u.Item1;
                int uy = u.Item2;

                foreach (var direction in directions)
                {
                    var vx = u.Item1 + direction.Item1;
                    var vy = u.Item2 + direction.Item2;

                    if ((vx >= 0 && vx < rowLength)
                        && (vy >= 0 && vy < colLength)
                        && dist[vx][vy] > dist[ux][uy] + 1
                       )
                    {
                        dist[vx][vy] = dist[ux][uy] + 1;
                        rottenQueue.Enqueue((vx, vy));
                    }
                }
            }

            int maxdistance = 0;
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    maxdistance = Math.Max(maxdistance, dist[r][c]);
                }
            }
            return maxdistance == int.MaxValue ? -1 : maxdistance;
        }
    }
}

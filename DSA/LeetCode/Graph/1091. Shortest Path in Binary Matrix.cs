using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._1091ShortestPathinBinaryMatrix
{
    public class Solution
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            return new BFSDistance().ShortestPathBinaryMatrix(grid);
        }
    }

    public class BFSDistance
    {
        public int ShortestPathBinaryMatrix(int[][] mat)
        {
            if (mat[0][0] == 1) return -1;

            int rowLength = mat.Length;
            int colLength = mat[0].Length;

            int[][] distanceMatrix = new int[rowLength][];
            for (int r = 0; r < distanceMatrix.Length; r++)
            {
                distanceMatrix[r] = new int[colLength];
                Array.Fill(distanceMatrix[r], -1);
            }

            bool[][] visitedMatrix = new bool[rowLength][];
            for (int r = 0; r < visitedMatrix.Length; r++)
            {
                visitedMatrix[r] = new bool[colLength];
                Array.Fill(visitedMatrix[r], false);
            }

            Queue<(int, int)> startQueue = new Queue<(int, int)>();

            distanceMatrix[0][0] = 1;
            startQueue.Enqueue((0, 0));
            visitedMatrix[0][0] = true;

            List<(int, int)> directions = new List<(int, int)> { (0, 1), (0, -1), (1, 0), (-1, 0), (1, -1), (-1, 1), (-1, -1), (1, 1) };
            while (startQueue.Count > 0)
            {
                (int, int) u = startQueue.Dequeue();
                int ux = u.Item1;
                int uy = u.Item2;

                foreach (var direction in directions)
                {
                    int vx = ux + direction.Item1;
                    int vy = uy + direction.Item2;

                    if (
                        (vx >= 0 && vx < rowLength)
                        && (vy >= 0 && vy < colLength)
                        && (mat[vx][vy] == 0)
                        && (visitedMatrix[vx][vy] == false)
                        && (distanceMatrix[vx][vy] == -1)
                     )
                    {
                        distanceMatrix[vx][vy] = distanceMatrix[ux][uy] + 1;
                        startQueue.Enqueue((vx, vy));
                        visitedMatrix[vx][vy] = true;
                    }
                }
            }
            return distanceMatrix[rowLength - 1][colLength - 1];
        }
    }
}

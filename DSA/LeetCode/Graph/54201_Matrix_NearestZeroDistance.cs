using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._54201_Matrix_NearestZeroDistance
{
    public class Solution
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            return new BFSDistance().UpdateMatrix(mat);
        }
    }

    public class BFSDistance
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            int rowLength = mat.Length;
            int colLength = mat[0].Length;

            int[][] distanceMatrix = new int[rowLength][];
            for (int r = 0; r < distanceMatrix.Length; r++)
            {
                distanceMatrix[r] = new int[colLength];
                Array.Fill(distanceMatrix[r], int.MaxValue);
            }

            Queue<(int, int)> startQueue = new Queue<(int, int)>();
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (mat[r][c] == 0)
                    {
                        distanceMatrix[r][c] = 0;
                        startQueue.Enqueue((r, c));
                    }
                }
            }

            List<(int, int)> directions = new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) };
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
                        && (distanceMatrix[vx][vy] > distanceMatrix[ux][uy] + 1)
                     )
                    {
                        distanceMatrix[vx][vy] = distanceMatrix[ux][uy] + 1;
                        startQueue.Enqueue((vx, vy));
                    }
                }
            }
            return distanceMatrix;
        }
    }
}

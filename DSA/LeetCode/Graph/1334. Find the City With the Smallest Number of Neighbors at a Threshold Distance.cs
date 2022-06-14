using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._1334FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance
{
    public class Solution
    {
        /*
         There are n cities numbered from 0 to n-1. Given the array edges where edges[i] = [fromi, toi, weighti] represents a bidirectional and weighted edge between cities fromi and toi, and given the integer distanceThreshold.

        Return the city with the smallest number of cities that are reachable through some path and whose distance is at most distanceThreshold, If there are multiple such cities, return the city with the greatest number.

        Notice that the distance of a path connecting cities i and j is equal to the sum of the edges' weights along that path.

 

        Example 1:

        Input: n = 4, edges = [[0,1,3],[1,2,1],[1,3,4],[2,3,1]], distanceThreshold = 4
        Output: 3
        Explanation: The figure above describes the graph. 
        The neighboring cities at a distanceThreshold = 4 for each city are:
        City 0 -> [City 1, City 2] 
        City 1 -> [City 0, City 2, City 3] 
        City 2 -> [City 0, City 1, City 3] 
        City 3 -> [City 1, City 2] 
        Cities 0 and 3 have 2 neighboring cities at a distanceThreshold = 4, but we have to return city 3 since it has the greatest number.

        */

        // all pairs (src - dest)nodes --> distance

        // Floyd Warshall -  Multiple src to multiple dest.
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            double MAX_VALUE = Math.Pow(10, 4) + 1;

            double[][] cost = new double[n][];
            for (int i = 0; i < n; i++)
            {
                cost[i] = new double[n];
                Array.Fill(cost[i], MAX_VALUE);
            }

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                int wt = edge[2];
                cost[u][v] = wt;
                cost[v][u] = wt;
            }

            for (int i = 0; i < n; i++)
            {
                cost[i][i] = 0;
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        cost[i][j] = Math.Min(cost[i][j], cost[i][k] + cost[k][j]);
                    }
                }
            }

            int resultNode = 0;
            int minCount = n;
            for (int i = 0; i < n; i++)
            {
                int currentMinCount = 0;
                for (int j = 0; j < n; j++)
                {
                    if (cost[i][j] < distanceThreshold) { currentMinCount++; }
                }

                if (minCount > currentMinCount)
                {
                    minCount = currentMinCount;
                    resultNode = 0;
                }
            }
            return resultNode;
        }
    }
}

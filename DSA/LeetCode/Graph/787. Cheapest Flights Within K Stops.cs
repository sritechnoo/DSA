using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._787CheapestFlightsWithinKStops
{
    /*
      There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.

     You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.
    */

    public class Solution
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            return BellManFordAlgorithm(n, flights, src, dst, k);
        }

        public int BellManFordAlgorithm(int n, int[][] flights, int src, int dst, int k)
        {
            double[] cost = new double[n];
            Array.Fill(cost, Math.Pow(10, 4) + 1);

            cost[src] = 0;
            for (int i = 0; i <= k; i++)
            {
                double[] temp = new double[n];
                Array.Copy(cost, temp, n);

                foreach (var weightedEdge in flights)
                {
                    int u = weightedEdge[0];
                    int v = weightedEdge[1];
                    int weight = weightedEdge[2];

                    temp[v] = Math.Min(temp[v], cost[u] + weight);
                }
                cost = temp;
            }
            return cost[dst] == Math.Pow(10, 4) + 1 ? -1 : (int)cost[dst];
        }

    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._1334FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance
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

    public class DistanceAscComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[1].CompareTo(y[1]);
        }
    }

    public class AllSolution
    {
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            int INF = (int)1e9 + 7;

            Dictionary<int, List<(int, int)>> adj = new Dictionary<int, List<(int, int)>>();

            /*Initialization*/
            for (int i = 0; i < n; i++)
            {
                int node = i;
                adj.Add(node, new List<(int, int)>());
            }
            /*Adjacancy List*/
            foreach (var e in edges)
            {
                int u = e[0];
                int v = e[1];
                int wt = e[2];

                adj[u].Add((v, wt));
                adj[v].Add((u, wt));
            }

            /*Initialization*/
            int[][] distanceMatrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Array.Fill(distanceMatrix[i], INF);
                distanceMatrix[i][i] = 0;
            }

            /*Adjacancy Matrix*/
            foreach (var e in edges)
            {
                int u = e[0];
                int v = e[1];
                int d = e[2];

                distanceMatrix[u][v] = d;
                distanceMatrix[v][u] = d;
            }


            FloydWarshall(n, adj, distanceMatrix);
            for (int i = 0; i < n; i++)
            {
                Dijkstra(n, adj, distanceMatrix[i], i);
                BellMenFord(n, edges, distanceMatrix[i], i);
                SPFA(n, adj, distanceMatrix[i], i);
            }

            int minCity = -1;
            int minCount = n;

            for (int i = 0; i < n; i++)
            {
                int curCount = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) { continue; }
                    if (distanceMatrix[i][j] <= distanceThreshold) { curCount++; }
                }
                if (curCount <= minCount)
                {
                    minCount = curCount;
                    minCity = i;
                }
            }

            return minCity;
        }

        void SPFA(int n, Dictionary<int, List<(int, int)>> adj, int[] dist, int src)
        {
            //Deque<Integer> q = new ArrayDeque<>();
            Queue<int> q = new Queue<int>();

            int[] updateTimes = new int[n];
            q.Enqueue(src);


            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (var next in adj[u])
                {
                    int v = next.Item1;
                    int wt = next.Item2;

                    if (dist[v] > dist[u] + wt)
                    {
                        dist[v] = dist[u] + wt;
                        updateTimes[v]++;

                        q.Enqueue(v);

                        if (updateTimes[v] > n) { Console.WriteLine("wrong"); }
                    }
                }
            }
        }

        void BellMenFord(int n, int[][] edges, int[] dist, int src)
        {
            for (int k = 1; k < n; k++)
            {
                foreach (var e in edges)
                {
                    int u = e[0];
                    int v = e[1];
                    int duv = e[2];

                    if (dist[u] > dist[v] + duv)
                    {
                        dist[u] = dist[v] + duv;
                    }

                    if (dist[v] > dist[u] + duv)
                    {
                        dist[v] = dist[u] + duv;
                    }
                }
            }
        }

        void Dijkstra(int n, Dictionary<int, List<(int, int)>> adj, int[] dist, int src)
        {
            PriorityQueue<int[], int[]> pq = new PriorityQueue<int[], int[]>(new DistanceAscComparer());
            pq.Enqueue(new int[] { src, 0 }, new int[] { src, 0 });

            while (pq.Count > 0)
            {
                int[] cur = pq.Dequeue();
                int u = cur[0];
                int du = cur[1];
                if (du > dist[u]) { continue; }

                foreach (var nb in adj[u])
                {
                    int v = nb.Item1;
                    int duv = nb.Item2;
                    if (dist[v] > du + duv)
                    {
                        dist[v] = du + duv;
                        pq.Enqueue(new int[] { v, dist[v] }, new int[] { v, dist[v] });
                    }
                }
            }
        }

        void FloydWarshall(int n, Dictionary<int, List<(int, int)>> adj, int[][] dist)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
    }

    public class Solution
    {
        // all pairs (src - dest)nodes --> distance
        // Floyd Warshall -  Multiple src to multiple dest.
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            double MAX_VALUE = Math.Pow(10, 4) + 1;

            double[][] distanceMatrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                distanceMatrix[i] = new double[n];
                Array.Fill(distanceMatrix[i], MAX_VALUE);
            }

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                int wt = edge[2];

                distanceMatrix[u][v] = wt;
                distanceMatrix[v][u] = wt;
            }

            /*Distance from Src to Src is 0 */
            for (int i = 0; i < n; i++)
            {
                distanceMatrix[i][i] = 0;
            }

            /*Floyd Warshall Algorithm*/
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        distanceMatrix[i][j] = Math.Min(distanceMatrix[i][j], distanceMatrix[i][k] + distanceMatrix[k][j]);
                    }
                }
            }


            int minReachableCount = n;
            int resultStartNode = 0;
            for (int startNode = 0; startNode < n; startNode++)
            {
                int reachableCount = 0;

                for (int endNode = 0; endNode < n; endNode++)
                {
                    if (startNode == endNode) { continue; }
                    if (distanceMatrix[startNode][endNode] < distanceThreshold)
                    {
                        reachableCount++;
                    }
                }
                if (reachableCount <= minReachableCount)
                {
                    minReachableCount = reachableCount;
                    resultStartNode = startNode;
                }
            }
            return resultStartNode;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._743NetworkDelayTime
{
    public class Solution
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            return new DijikstraApproach().NetworkDelayTime(times, n, k);
        }
    }

    public class BFSApproach
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<(int, int)>> adjList = new Dictionary<int, List<(int, int)>>();

            foreach (var edge in times)
            {
                if (adjList.ContainsKey(edge[0]) == false)
                {
                    adjList.Add(edge[0], new List<(int, int)>());
                }
                adjList[edge[0]].Add((edge[1], edge[2]));
            }

            int[] distance = new int[n + 1];
            Array.Fill(distance, int.MaxValue);


            BFS(n, adjList, distance, k);

            int answer = int.MinValue;
            for (int node = 1; node <= n; node++)
            {
                answer = Math.Max(answer, distance[node]);
            }
            return answer == int.MaxValue ? -1 : answer;
        }

        private void BFS(int n, Dictionary<int, List<(int, int)>> adjList, int[] distanceArray, int src)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(src);
            distanceArray[src] = 0;

            while (q.Count > 0)
            {
                int u = q.Dequeue();

                if (!adjList.ContainsKey(u)) { continue; }

                foreach (var vnode in adjList[u])
                {
                    int v = vnode.Item1;
                    int vtime = vnode.Item2;

                    if (distanceArray[v] > distanceArray[u] + vtime)
                    {
                        distanceArray[v] = distanceArray[u] + vtime;
                        q.Enqueue(v);
                    }
                }
            }
        }
    }

    public class DijikstraApproach
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<(int, int)>> adjList = new Dictionary<int, List<(int, int)>>();

            foreach (var edge in times)
            {
                if (adjList.ContainsKey(edge[0]) == false)
                {
                    adjList.Add(edge[0], new List<(int, int)>());
                }
                adjList[edge[0]].Add((edge[1], edge[2]));
            }

            int[] distance = new int[n + 1];
            Array.Fill(distance, int.MaxValue);

            Dijikstra(n, adjList, distance, k);


            int answer = int.MinValue;
            for (int node = 1; node <= n; node++)
            {
                answer = Math.Max(answer, distance[node]);
            }
            return answer == int.MaxValue ? -1 : answer;
        }

        private void Dijikstra(int n, Dictionary<int, List<(int, int)>> adjList, int[] distance, int src)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            distance[src] = 0;
            pq.Enqueue(src, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int uTime);

                if (uTime > distance[u])
                {
                    continue;
                }

                if (!adjList.ContainsKey(u))
                {
                    continue;
                }

                foreach (var vnode in adjList[u])
                {
                    int v = vnode.Item1;
                    int vtime = vnode.Item2;

                    if (distance[v] > uTime + vtime)
                    {
                        distance[v] = uTime + vtime;

                        pq.Enqueue(v, distance[v]);
                    }
                }
            }
        }
    }
}

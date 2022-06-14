using System;
using System.Collections.Generic;

namespace DSA.LeetCode.Graph._785IsGraphBipartite
{
    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {
            return new DFSApproach().IsBipartite(graph);
        }
    }

    public class DFSApproach
    {
        public bool IsBipartite(int[][] graph)
        {
            int numberOfNodes = graph.Length;

            int[] colors = new int[numberOfNodes];
            Array.Fill(colors, -1);

            for (int node = 0; node < numberOfNodes; node++)
            {
                if (colors[node] == -1)
                {
                    colors[node] = 1;
                    if (!DFS(graph, colors, node))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool DFS(int[][] graph, int[] colors, int uNode)
        {
            foreach (var vNode in graph[uNode])
            {
                if (colors[uNode] == colors[vNode])
                {
                    return false;
                }
                else if (colors[vNode] == -1)
                {
                    colors[vNode] = 1 - colors[uNode];
                    if (!DFS(graph, colors, vNode))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }

    public class BFSApproach
    {
        public bool IsBipartite(int[][] graph)
        {
            int numberOfNodes = graph.Length;

            int[] colors = new int[numberOfNodes];
            Array.Fill(colors, -1);

            for (int node = 0; node < numberOfNodes; node++)
            {
                if (colors[node] == -1)
                {
                    if (!BFS(graph, colors, node))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool BFS(int[][] graph, int[] colors, int node)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(node);
            colors[node] = 1;

            while (queue.Count > 0)
            {
                int uNode = queue.Dequeue();

                foreach (var vNode in graph[uNode])
                {
                    if (colors[vNode] == colors[uNode]) { return false; }
                    else if (colors[vNode] == -1)
                    {
                        colors[vNode] = 1 - colors[uNode];
                        queue.Enqueue(vNode);
                    }
                }
            }

            return true;
        }

    }

}

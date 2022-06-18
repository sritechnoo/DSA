using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.LeetCode.Graph._802_FindEventualSafeStates
{
    /*There is a directed graph of n nodes with each node labeled from 0 to n - 1. The graph is represented by a 0-indexed 2D integer array graph where graph[i] is an integer array of nodes adjacent to node i, meaning there is an edge from node i to each node in graph[i].

    A node is a terminal node if there are no outgoing edges. A node is a safe node if every possible path starting from that node leads to a terminal node.

    Return an array containing all the safe nodes of the graph. The answer should be sorted in ascending order.



    Example 1:
    Illustration of graph

    Input: graph = [[1,2],[2,3],[5],[0],[5],[],[]]
    Output: [2,4,5,6]
    Explanation: The given graph is shown above.
    Nodes 5 and 6 are terminal nodes as there are no outgoing edges from either of them.
    Every path starting at nodes 2, 4, 5, and 6 all lead to either node 5 or 6.

    Example 2:

    Input: graph = [[1,2,3,4],[1,2],[3,4],[0,4],[]]
    Output: [4]
    Explanation:
    Only node 4 is a terminal node, and every path starting at node 4 leads to node 4.



    Constraints:

        n == graph.length
        1 <= n <= 104
        0 <= graph[i].length <= n
        0 <= graph[i][j] <= n - 1
        graph[i] is sorted in a strictly increasing order.
        The graph may contain self-loops.
        The number of edges in the graph will be in the range [1, 4 * 104].

    */
    public class Solution
    {
        /* 
         * GOAL: Return all the nodes which will not be part of cycle.
         */

        /*
         * Approach:1: Detect if node is forming a cycle , do this for all nodes.
         * TC: O(Nodes * Nodes Log Edges) ==> O(Nodes^2)
         * SC: O(Nodes) 
         * 
         */

        /* Approach:2:
         * Reverse the graph
         * Do Topological Sort --> Cycle Will Never be Included
         */

        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int numberOfNodes = graph.Length;

            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for (int node = 0; node < numberOfNodes; node++)
            {
                adj.Add(node, graph[node].ToList());
            }

            bool[] visited = new bool[numberOfNodes];
            Array.Fill(visited, false);

            bool[] dfsVisted = new bool[numberOfNodes];
            Array.Fill(dfsVisted, false);

            bool[] presentCycle = new bool[numberOfNodes];
            Array.Fill(presentCycle, false);

            for (int node = 0; node < numberOfNodes; node++)
            {
                if (visited[node] == false)
                {
                    DFSCycle(node, adj, visited, dfsVisted, presentCycle);
                }
            }

            IList<int> result = new List<int>();
            for (int node = 0; node < numberOfNodes; node++)
            {
                if (presentCycle[node] == true) { result.Add(node); }
            }
            return result;
        }

        private bool DFSCycle(int node, Dictionary<int, List<int>> adj, bool[] visited, bool[] dfsVisited, bool[] presentCycle)
        {
            visited[node] = true;
            dfsVisited[node] = true;

            foreach (var neighbor in adj[node])
            {
                if (visited[neighbor] == false)
                {
                    if (DFSCycle(neighbor, adj, visited, dfsVisited, presentCycle) == true)
                    {
                        presentCycle[node] = true;
                        return true;
                    }
                }
                else if (dfsVisited[neighbor] == true)
                {
                    presentCycle[node] = true;
                    return true;
                }
            }
            dfsVisited[node] = false;

            return false;

        }

        public IList<int> EventualSafeNodesApproach1(int[][] graph)
        {
            int numberOfNodes = graph.Length;

            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for (int node = 0; node < numberOfNodes; node++)
            {
                adj.Add(node, graph[node].ToList());
            }



            int[] indegreeForReversedGraph = new int[numberOfNodes];
            Dictionary<int, List<int>> reversedGraph = new Dictionary<int, List<int>>();
            for (int node = 0; node < numberOfNodes; node++)
            {
                reversedGraph.Add(node, new List<int>());
            }

            for (int unode = 0; unode < numberOfNodes; unode++)
            {
                foreach (int vnode in graph[unode])
                {
                    adj[vnode].Add(unode);

                    indegreeForReversedGraph[unode]++;
                }
            }

            Queue<int> queue = new Queue<int>();

            for (int node = 0; node < numberOfNodes; node++)
            {
                if (indegreeForReversedGraph[node] == 0) { queue.Enqueue(node); }
            }

            List<int> orderListForReversedGraph = new List<int>();
            while (queue.Count > 0)
            {
                int uNode = queue.Dequeue();
                orderListForReversedGraph.Add(uNode);

                foreach (var vNode in reversedGraph[uNode])
                {
                    indegreeForReversedGraph[vNode]--;
                    if (indegreeForReversedGraph[vNode] == 0) { queue.Enqueue(vNode); }
                }
            }

            Array.Sort(orderListForReversedGraph.ToArray());
            return orderListForReversedGraph;
        }
    }
}

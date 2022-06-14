﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._1319NumberofOperationstoMakeNetworkConnected
{
    /*There are n computers numbered from 0 to n - 1 connected by ethernet cables connections forming a network where connections[i] = [ai, bi] represents a connection between computers ai and bi. Any computer can reach any other computer directly or indirectly through the network.

    You are given an initial computer network connections. You can extract certain cables between two directly connected computers, and place them between any pair of disconnected computers to make them directly connected.

    Return the minimum number of times you need to do this in order to make all the computers connected. If it is not possible, return -1.



    Example 1:

    Input: n = 4, connections = [[0,1],[0,2],[1,2]]
    Output: 1
    Explanation: Remove cable between computer 1 and 2 and place between computers 1 and 3.

    Example 2:

    Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2],[1,3]]
    Output: 2

    Example 3:

    Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2]]
    Output: -1
    Explanation: There are not enough cables.
    */

    using System.Collections.Generic;

    public class Solution
    {
        public int MakeConnected(int n, int[][] connections)
        {
            return new DFSApproach().MakeConnected(n, connections);
        }
    }

    public class DFSApproach
    {
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1) return -1;

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            foreach (var connection in connections)
            {
                int u = connection[0];
                int v = connection[1];

                if (adjList.ContainsKey(u) == false) { adjList.Add(u, new List<int>()); }
                adjList[u].Add(v);

                if (adjList.ContainsKey(v) == false) { adjList.Add(v, new List<int>()); }
                adjList[v].Add(u);

            }

            bool[] visited = new bool[n];
            Array.Fill(visited, false);

            int components = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == false)
                {
                    DFS(adjList, visited, i);
                    components++;
                }
            }
            return components - 1;
        }

        public void DFS(Dictionary<int, List<int>> adjList, bool[] visited, int src)
        {
            visited[src] = true;
            if (adjList.ContainsKey(src) == false) { return; }

            List<int> neighbours = adjList[src];
            foreach (var vnode in neighbours)
            {
                if (visited[vnode] == false)
                {
                    DFS(adjList, visited, vnode);
                }
            }
        }
    }
}

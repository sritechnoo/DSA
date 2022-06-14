using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._684RedundantConnection
{
    /*In this problem, a tree is an undirected graph that is connected and has no cycles.

    You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added. The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. The graph is represented as an array edges of length n where edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi in the graph.

    Return an edge that can be removed so that the resulting graph is a tree of n nodes. If there are multiple answers, return the answer that occurs last in the input.

 

    Example 1:

    Input: edges = [[1,2],[1,3],[2,3]]
    Output: [2,3]
    */
    public class Solution
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            return new DisJointSetApproach().FindRedundantConnection(edges);
        }
    }

    public class DisJointSetApproach
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            int numberOfEdges = edges.Length;
            DisJointSet disJointSet = new DisJointSet(numberOfEdges + 1);

            foreach (var edge in edges)
            {

                if (disJointSet.Union(edge[0], edge[1]) == false)
                {
                    return new int[] { edge[0], edge[1] };
                }
            }
            return new int[] { };
        }
    }

    public class DisJointSet
    {
        private int componentCount;
        private int[] parentComponents;
        private int[] parentComponentSize;

        public DisJointSet(int N)
        {
            this.componentCount = N;
            this.parentComponents = new int[N];
            this.parentComponentSize = new int[N];
            for (int i = 0; i < N; i++)
            {
                parentComponents[i] = i;
                parentComponentSize[i] = 1;
            }
        }

        public int Count()
        {
            return componentCount;
        }

        public int[] GetParentComponents()
        {
            return parentComponents;
        }

        public int FindParent(int node)
        {
            if (node == parentComponents[node]) { return node; }

            return parentComponents[node] = FindParent(parentComponents[node]);
        }

        public bool Union(int u, int v)
        {
            int uParent = FindParent(u);
            int vParent = FindParent(v);

            if (uParent == vParent) { return false; }

            parentComponents[vParent] = uParent;
            componentCount--;

            return true;
        }

        public bool UnionWithSize(int u, int v)
        {
            int uParent = FindParent(u);
            int vParent = FindParent(v);

            if (uParent == vParent) { return false; }

            if (parentComponentSize[uParent] > parentComponentSize[vParent])
            {
                parentComponents[vParent] = uParent;
                parentComponentSize[uParent] += vParent;
                componentCount--;
            }
            else
            {
                parentComponents[uParent] = vParent;
                parentComponentSize[vParent] += uParent;
                componentCount--;
            }
            return true;
        }
    }

}

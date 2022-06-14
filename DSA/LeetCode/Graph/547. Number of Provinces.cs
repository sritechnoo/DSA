using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._547NumberofProvinces
{
    /*
     There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly with city c, then city a is connected indirectly with city c.

    A province is a group of directly or indirectly connected cities and no other cities outside of the group.

    You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.

    Return the total number of provinces.

 

    Example 1:

    Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
    Output: 2
    */
    public class Solution
    {
        public int FindCircleNum(int[][] isConnected)
        {
            return new DFSApproach().FindCircleNum(isConnected);
        }
    }

    public class DFSApproach
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int numberOfCites = isConnected.Length;
            if (numberOfCites == 0) { return 0; }

            bool[] visited = new bool[numberOfCites];
            Array.Fill(visited, false);

            int connectedCities = 0;
            for(int i=0; i<numberOfCites; i++)
            {
                if (visited[i] == false)
                {
                    DFS(isConnected, visited, i);
                    connectedCities++;
                }
            }

            return connectedCities;
        }

        public void DFS(int[][] isConnected, bool[] visited, int i)
        {
            visited[i] = true;
            for (int j = 0; j < isConnected.Length; j++)
            {
                if(isConnected[i][j]==1 && visited[j] == false)
                {
                    DFS(isConnected, visited, j);
                }
            }

        }
    }
}

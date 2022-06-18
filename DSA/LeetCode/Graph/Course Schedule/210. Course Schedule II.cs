using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Graph.Course_Schedule._210_Course_Schedule_II
{
    /*There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

        For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.

    Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.



    Example 1:

    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: [0,1]
    Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

    Example 2:

    Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
    Output: [0,2,1,3]
    Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
    So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

    Example 3:

    Input: numCourses = 1, prerequisites = []
    Output: [0]



    Constraints:

        1 <= numCourses <= 2000
        0 <= prerequisites.length <= numCourses * (numCourses - 1)
        prerequisites[i].length == 2
        0 <= ai, bi < numCourses
        ai != bi
        All the pairs [ai, bi] are distinct.

    */

    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            
            var result = TopologicalSortingBFS(numCourses, prerequisites);
            var orderList = result.Item1;
            return orderList.Count == numCourses ? orderList.ToArray() : new List<int>().ToArray();
        }

        private (List<int>, Dictionary<int, HashSet<int>>) TopologicalSortingBFS(int numCourses, int[][] prerequisites, int[][] queries)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] inDegree = new int[numCourses];

            List<int> orderList = new List<int>();
            Dictionary<int, HashSet<int>> preRequsiteMapResult = new Dictionary<int, HashSet<int>>();


            /*Initialization*/
            for (int i = 0; i < numCourses; i++)
            {
                int node = i;
                adjList.Add(node, new List<int>());
                inDegree[node] = 0;

                preRequsiteMapResult.Add(node, new HashSet<int>());
            }

            /*Adjacancy List Creation*/
            foreach (var prerequsite in prerequisites)
            {
                int u = prerequsite[0];
                int v = prerequsite[1];

                /* u->v */
                adjList[u].Add(v);

                inDegree[v]++;
            }


            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0) { queue.Enqueue(i); }
            }

            while (queue.Count > 0)
            {
                int uNode = queue.Dequeue();
                orderList.Add(uNode);

                foreach (var vNode in adjList[uNode])
                {
                    preRequsiteMapResult[vNode].Add(uNode);
                    foreach (var item in preRequsiteMapResult[uNode])
                    {
                        preRequsiteMapResult[vNode].Add(item);
                    }


                    inDegree[vNode]--;
                    if (inDegree[vNode] == 0) { queue.Enqueue(vNode); }
                }

            }
            return (orderList, preRequsiteMapResult);
        }

    }
}

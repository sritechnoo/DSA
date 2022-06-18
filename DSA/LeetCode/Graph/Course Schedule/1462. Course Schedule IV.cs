using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Graph.Course_Schedule._1462CourseSchedule_IV
{
    /*There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course ai first if you want to take course bi.

        For example, the pair [0, 1] indicates that you have to take course 0 before you can take course 1.

    Prerequisites can also be indirect. If course a is a prerequisite of course b, and course b is a prerequisite of course c, then course a is a prerequisite of course c.

    You are also given an array queries where queries[j] = [uj, vj]. For the jth query, you should answer whether course uj is a prerequisite of course vj or not.

    Return a boolean array answer, where answer[j] is the answer to the jth query.



    Example 1:

    Input: numCourses = 2, prerequisites = [[1,0]], queries = [[0,1],[1,0]]
    Output: [false,true]
    Explanation: The pair [1, 0] indicates that you have to take course 1 before you can take course 0.
    Course 0 is not a prerequisite of course 1, but the opposite is true.

    Example 2:

    Input: numCourses = 2, prerequisites = [], queries = [[1,0],[0,1]]
    Output: [false,false]
    Explanation: There are no prerequisites, and each course is independent.

    Example 3:

    Input: numCourses = 3, prerequisites = [[1,2],[1,0],[2,0]], queries = [[1,0],[1,2]]
    Output: [true,true]



    Constraints:

        2 <= numCourses <= 100
        0 <= prerequisites.length <= (numCourses * (numCourses - 1) / 2)
        prerequisites[i].length == 2
        0 <= ai, bi <= n - 1
        ai != bi
        All the pairs [ai, bi] are unique.
        The prerequisites graph has no cycles.
        1 <= queries.length <= 104
        0 <= ui, vi <= n - 1
        ui != vi

    */

    public class Solution
    {
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            var topologicalResult = TopologicalSortingBFS(numCourses, prerequisites, queries);
            var orderList = topologicalResult.Item1;
            var preRequsiteList = topologicalResult.Item2;

            var result = new List<bool>();
            foreach (var query in queries)
            {
                var prerequisitesList = preRequsiteList[query[1]];

                result.Add(prerequisitesList.Contains(query[0]));
            }
            return result;
        }

        private (List<int>, Dictionary<int, HashSet<int>>) TopologicalSortingBFS(int numCourses, int[][] prerequisites, int[][] queries)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] inDegree = new int[numCourses];

            List<int> orderList = new List<int>();
            Dictionary<int, HashSet<int>> preRequsiteMapResult = new Dictionary<int, HashSet<int>>();


            /*Initialization*/
            for (int node = 0; node < numCourses; node++)
            {
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

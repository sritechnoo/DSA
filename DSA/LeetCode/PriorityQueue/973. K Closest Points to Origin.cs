using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue._973_K_Closest_Points_to_Origin
{
    /*Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).

    The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).

    You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).



    Example 1:

    Input: points = [[1,3],[-2,2]], k = 1
    Output: [[-2,2]]
    Explanation:
    The distance between (1, 3) and the origin is sqrt(10).
    The distance between (-2, 2) and the origin is sqrt(8).
    Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
    We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].

    Example 2:

    Input: points = [[3,3],[5,-1],[-2,4]], k = 2
    Output: [[3,3],[-2,4]]
    Explanation: The answer [[-2,4],[3,3]] would also be accepted.



    Constraints:

        1 <= k <= points.length <= 104
        -104 < xi, yi < 104

    */

    public class Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public int distanceFromOrigin { get; set; }

        public Node(int _x, int _y, int _distance)
        {
            this.x = _x;
            this.y = _y;
            this.distanceFromOrigin = _distance;
        }

        public override string ToString()
        {
            return this.x + "," + this.y + "=" + this.distanceFromOrigin;
        }
    }

    public class MinHeapComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return x.distanceFromOrigin - y.distanceFromOrigin;
        }
    }

    public class MaxHeapComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return y.distanceFromOrigin - x.distanceFromOrigin;
        }
    }

    public class Solution
    {
        public int[][] KClosest(int[][] points, int k)
        {
            PriorityQueue<Node, Node> maxHeap = new PriorityQueue<Node, Node>(new MaxHeapComparer());

            foreach (int[] point in points)
            {
                int x = point[0];
                int y = point[1];
                int distance = x * x + y * y;

                Node currentNode = new Node(x, y, distance);
                Console.WriteLine(currentNode.ToString());
                maxHeap.Enqueue(currentNode, currentNode);

                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }

            Console.WriteLine("-----------------");

            int[][] result = new int[maxHeap.Count][];
            for (int i = 0; i < k; i++)
            {
                Node currentNode = maxHeap.Dequeue();
                Console.WriteLine(currentNode.ToString());
                result[i] = new int[] { currentNode.x, currentNode.y };
            }
            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue._1439_Find_the_Kth_Smallest_Sum_of_a_Matrix_With_Sorted_Rows
{
    /*You are given an m x n matrix mat that has its rows sorted in non-decreasing order and an integer k.

You are allowed to choose exactly one element from each row to form an array.

Return the kth smallest array sum among all possible arrays.

 

Example 1:

Input: mat = [[1,3,11],[2,4,6]], k = 5
Output: 7
Explanation: Choosing one element from each row, the first k smallest sum are:
[1,2], [1,4], [3,2], [3,4], [1,6]. Where the 5th sum is 7.

Example 2:

Input: mat = [[1,3,11],[2,4,6]], k = 9
Output: 17

Example 3:

Input: mat = [[1,10,10],[1,4,5],[2,3,6]], k = 7
Output: 9
Explanation: Choosing one element from each row, the first k smallest sum are:
[1,1,2], [1,1,3], [1,4,2], [1,4,3], [1,1,6], [1,5,2], [1,5,3]. Where the 7th sum is 9.  

 

Constraints:

    m == mat.length
    n == mat.length[i]
    1 <= m, n <= 40
    1 <= mat[i][j] <= 5000
    1 <= k <= min(200, nm)
    mat[i] is a non-decreasing array.

*/
    public class Node
    {
        public int[] ColumnIndexMatrix { get; set; }
        public int Sum { get; set; }
        public Node() { }
        public Node(int[] columnIndexMatrix, int sum)
        {
            ColumnIndexMatrix = columnIndexMatrix;
            Sum = sum;
        }
    }

    public class MinHeap : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return x.Sum.CompareTo(y.Sum);
        }
    }

    public class MaxHeap : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return y.Sum.CompareTo(y.Sum);
        }
    }

    public class Solution
    {
        public int KthSmallest(int[][] mat, int k)
        {
            int rowLength = mat.Length;
            int colLength = mat[0].Length;

            PriorityQueue<Node, Node> minheap = new PriorityQueue<Node, Node>(new MinHeap());
            HashSet<int[]> set = new HashSet<int[]>();

            int[] ColumnIndexMatrix = new int[rowLength];
            int firstSum = 0;
            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                ColumnIndexMatrix[rowIndex] = 0;
                firstSum += mat[rowIndex][0];
            }
            
            Node currentNode = new Node(ColumnIndexMatrix, firstSum);
       
            minheap.Enqueue(currentNode, currentNode);
            set.Add(currentNode.ColumnIndexMatrix);

            while (k-- > 0)
            {
                currentNode = minheap.Peek();

                for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    if (currentNode.ColumnIndexMatrix[rowIndex] + 1 < colLength)
                    {
                        Node nextNode = GetNextNewNode(mat, rowLength, currentNode, rowIndex);

                        if (set.Contains(nextNode.ColumnIndexMatrix)) { continue; }

                        minheap.Enqueue(nextNode, nextNode);
                        set.Add(nextNode.ColumnIndexMatrix);
                    }
                }
            }
            return currentNode.Sum;
        }

        private static Node GetNextNewNode(int[][] mat, int rowLength, Node currentNode, int rowIndex)
        {
            Node newNode = new Node();

            newNode.ColumnIndexMatrix = new int[rowLength];
            Array.Copy(currentNode.ColumnIndexMatrix, newNode.ColumnIndexMatrix, currentNode.ColumnIndexMatrix.Length);
            newNode.ColumnIndexMatrix[rowIndex]++;

            newNode.Sum = currentNode.Sum - mat[rowIndex][currentNode.ColumnIndexMatrix[rowIndex]] + mat[rowIndex][currentNode.ColumnIndexMatrix[rowIndex] + 1];
            return newNode;
        }
    }
}

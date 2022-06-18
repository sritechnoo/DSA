using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue.Connect_n_ropes_with_minimum_cost
{
    /*There are given n ropes of different lengths, we need to connect these ropes into one rope. The cost to connect two ropes is equal to the sum of their lengths. We need to connect the ropes with minimum cost.

    For example, if we are given 4 ropes of lengths 4, 3, 2, and 6. We can connect the ropes in the following ways. 
    1) First, connect ropes of lengths 2 and 3. Now we have three ropes of lengths 4, 6, and 5. 
    2) Now connect ropes of lengths 4 and 5. Now we have two ropes of lengths 6 and 9. 
    3) Finally connect the two ropes and all ropes have connected.
    Total cost for connecting all ropes is 5 + 9 + 15 = 29. This is the optimized cost for connecting ropes. Other ways of connecting ropes would always have same or more cost. For example, if we connect 4 and 6 first (we get three strings of 3, 2, and 10), then connect 10 and 3 (we get two strings of 13 and 2). Finally, we connect 13 and 2. Total cost in this way is 10 + 13 + 15 = 38.*/


    public class MinHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class ConnectRopes
    {
        int MinCost(int[] arr, int n)
        {
            // Create a priority queue
            List<int> pq = new List<int>();

            // Adding items to the pQueue
            for (int i = 0; i < n; i++)
            {
                pq.Add(arr[i]);
            }

            // Initialize result
            int res = 0;

            // While size of priority queue
            // is more than 1
            while (pq.Count > 1)
            {
                pq.Sort(new MinHeapComparer());

                // Extract shortest two ropes from pq
                int first = pq[0];
                pq.RemoveRange(0, 1);

                int second = pq[1];
                pq.RemoveRange(0, 1);

                // Connect the ropes: update result
                // and insert the new rope to pq
                res += first + second;
                pq.Add(first + second);
            }
            return res;
        }

        int MinCostPriortyQueue(int[] arr, int n)
        {

            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(new MinHeapComparer());

            for (int i = 0; i < n; i++)
            {
                minHeap.Enqueue(i, i);
            }

            int result = 0;
            while (minHeap.Count > 1)
            {
                // Extract shortest two ropes from pq
                int first = minHeap.Dequeue();
                int second = minHeap.Dequeue();

                // Connect the ropes: update result
                // and insert the new rope to pq
                result += first + second;
                minHeap.Enqueue(first + second, first + second);
            }

            return result;
        }

    }
}

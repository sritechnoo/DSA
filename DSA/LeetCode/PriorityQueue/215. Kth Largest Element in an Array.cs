using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.PriorityQueue._215KthLargestElementinanArray
{
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

    public class Solution
    {
        /*PriorityQueue: https://medium.com/@dorlugasigal/c-10-priorityqueue-is-here-5067e2628470#:~:text=priority%20queues%20can%20be%20used,by%20providing%20a%20different%20comparer.&text=In%20min%20heaps%2C%20every%20element,than%20the%20elements%20below%20them.*/
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(new MinHeapComparer());
            for (int i = 0; i < nums.Length; i++)
            {
                minHeap.Enqueue(nums[i], nums[i]);

                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }
            return minHeap.Peek();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.PriorityQueue._215KthLargestElementinanArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
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

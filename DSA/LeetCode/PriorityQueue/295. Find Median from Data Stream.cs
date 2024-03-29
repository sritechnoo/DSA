﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue._295_Find_Median_from_Data_Stream
{
    /*The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value and the median is the mean of the two middle values.

        For example, for arr = [2,3,4], the median is 3.
        For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.

    Implement the MedianFinder class:

        MedianFinder() initializes the MedianFinder object.
        void addNum(int num) adds the integer num from the data stream to the data structure.
        double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.



    Example 1:

    Input
    ["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
    [[], [1], [2], [], [3], []]
    Output
    [null, null, null, 1.5, null, 2.0]

    Explanation
    MedianFinder medianFinder = new MedianFinder();
    medianFinder.addNum(1);    // arr = [1]
    medianFinder.addNum(2);    // arr = [1, 2]
    medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
    medianFinder.addNum(3);    // arr[1, 2, 3]
    medianFinder.findMedian(); // return 2.0



    Constraints:

        -105 <= num <= 105
        There will be at least one element in the data structure before calling findMedian.
        At most 5 * 104 calls will be made to addNum and findMedian.



    Follow up:

        If all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?
        If 99% of all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?

    */

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */

    public class MinHeapComparer : IComparer<int>
    {
        public int Compare(int left, int right)
        {
            return left.CompareTo(right);
        }
    }

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int left, int right)
        {
            return right.CompareTo(left);
        }
    }

    public class MedianFinder
    {
        PriorityQueue<int, int> maxHeapFirst = new PriorityQueue<int, int>();
        PriorityQueue<int, int> minHeapSecond = new PriorityQueue<int, int>();

        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {
            maxHeapFirst.Enqueue(num, num);
            int currentElement = maxHeapFirst.Dequeue();
            minHeapSecond.Enqueue(currentElement, currentElement);

            if (maxHeapFirst.Count < minHeapSecond.Count)
            {
                currentElement = minHeapSecond.Dequeue();
                maxHeapFirst.Enqueue(currentElement, currentElement);
            }
        }

        public double FindMedian()
        {
            if (maxHeapFirst.Count == minHeapSecond.Count)
            {
                return (maxHeapFirst.Peek() + minHeapSecond.Peek()) / 2;
            }
            else
            {
                return maxHeapFirst.Count > minHeapSecond.Count ? maxHeapFirst.Peek() : minHeapSecond.Peek();
            }
        }
    }
}

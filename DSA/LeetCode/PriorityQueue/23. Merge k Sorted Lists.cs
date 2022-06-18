using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue._23_Merge_k_Sorted_Lists
{
    /*You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

    Merge all the linked-lists into one sorted linked-list and return it.



    Example 1:

    Input: lists = [[1,4,5],[1,3,4],[2,6]]
    Output: [1,1,2,3,4,4,5,6]
    Explanation: The linked-lists are:
    [
      1->4->5,
      1->3->4,
      2->6
    ]
    merging them into one sorted list:
    1->1->2->3->4->4->5->6

    Example 2:

    Input: lists = []
    Output: []

    Example 3:

    Input: lists = [[]]
    Output: []



    Constraints:

        k == lists.length
        0 <= k <= 104
        0 <= lists[i].length <= 500
        -104 <= lists[i][j] <= 104
        lists[i] is sorted in ascending order.
        The sum of lists[i].length will not exceed 104.

    */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class MinHeapComparer : IComparer<ListNode>
    {
        public int Compare(ListNode left, ListNode right)
        {
            return left.val.CompareTo(right.val);
        }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0 || lists == null) { return null; }

            PriorityQueue<ListNode, ListNode> minHeap = new PriorityQueue<ListNode, ListNode>(new MinHeapComparer());
            foreach (var node in lists)
            {
                if (node != null) { minHeap.Enqueue(node, node); }
            }

            if (minHeap.Count == 0) { return null; }

            ListNode result = new ListNode(-1);
            ListNode curr = result;

            while (minHeap.Count > 0)
            {
                curr.next = minHeap.Dequeue();
                curr = curr.next;

                if (curr.next != null) { minHeap.Enqueue(curr.next, curr.next); }
            }

            return result.next;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Sorting.MergeSort._23_Merge_k_Sorted_Lists
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

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) { return null; }
            return MergeKLists(lists, 0, lists.Length - 1);
        }
        public ListNode MergeKLists(ListNode[] lists, int startIndex, int endIndex)
        {
            if (startIndex == endIndex) { return lists[startIndex]; }

            int mid = (startIndex + endIndex) / 2;

            ListNode left = MergeKLists(lists, startIndex, mid);
            ListNode right = MergeKLists(lists, mid + 1, endIndex);

            return MergeTwoList(left, right);

        }
        public ListNode MergeTwoList(ListNode left, ListNode right)
        {
            ListNode result = new ListNode(-1);
            ListNode curr = result;

            while (left != null || right != null)
            {
                if (left == null)
                {
                    curr.next = right;
                    right = right.next;
                }
                else if (right == null)
                {
                    curr.next = left;
                    left = left.next;
                }
                else if (left.val < right.val)
                {
                    curr.next = left;
                    left = left.next;

                }
                else
                {
                    curr.next = right;
                    right = right.next;

                }
                curr = curr.next;
            }

            return result.next;
        }
    }
}

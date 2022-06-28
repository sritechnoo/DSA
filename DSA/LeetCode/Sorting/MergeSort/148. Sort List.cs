using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Sorting.MergeSort._148_Sort_List
{
    /*Given the head of a linked list, return the list after sorting it in ascending order.



    Example 1:

    Input: head = [4,2,1,3]
    Output: [1,2,3,4]

    Example 2:

    Input: head = [-1,5,3,4,0]
    Output: [-1,0,3,4,5]

    Example 3:

    Input: head = []
    Output: []



    Constraints:

        The number of nodes in the list is in the range [0, 5 * 104].
        -105 <= Node.val <= 105



    Follow up: Can you sort the linked list in O(n logn) time and O(1) memory (i.e. constant space)?
    */

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
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
        public ListNode SortList(ListNode head)
        {
            return MergeSort(head);
        }

        private ListNode MergeSort(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode midNode = GetMiddleNode(head);

            ListNode leftNode = MergeSort(head);
            ListNode rightNode = MergeSort(midNode);

            ListNode result = MergeTwoList(leftNode, rightNode);
            return result;
        }

        private ListNode MergeTwoList(ListNode left, ListNode right)
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

        private ListNode GetMiddleNode(ListNode head)
        {
            ListNode midPrev = null;

            while (head != null && head.next != null)
            {
                midPrev = (midPrev == null) ? head : midPrev.next;
                head = head.next.next;
            }

            ListNode mid = midPrev.next;
            midPrev.next = null;

            return mid;
        }
    }
}

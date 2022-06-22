using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.LinkedList._92_Reverse_Linked_List_II
{
    /*Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.



    Example 1:

    Input: head = [1,2,3,4,5], left = 2, right = 4
    Output: [1,4,3,2,5]

    Example 2:

    Input: head = [5], left = 1, right = 1
    Output: [5]



    Constraints:

        The number of nodes in the list is n.
        1 <= n <= 500
        -500 <= Node.val <= 500
        1 <= left <= right <= n
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
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            return ReverseBetweenRec(head, left, right);
        }

        private ListNode ReverseBetweenRec(ListNode head, int left, int right)
        {
            if (left == 1)
            {
                return ReverseOnlyNNodeRec(head, right);
            }
            head.next = ReverseBetweenRec(head.next, left - 1, right - 1);

            return head;
        }

        private ListNode ReverseOnlyNNodeRec(ListNode head, int right)
        {
            if (right == 1)
            {
                return head;
            }

            ListNode newHead = ReverseOnlyNNodeRec(head.next, right - 1);

            ListNode headNext = head.next;

            head.next = headNext.next;
            headNext.next = head;

            return newHead;

        }

    }
}

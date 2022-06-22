using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.LinkedList._206_Reverse_Linked_List
{
    /*en the head of a singly linked list, reverse the list, and return the reversed list.



    Example 1:

    Input: head = [1,2,3,4,5]
    Output: [5,4,3,2,1]

    Example 2:

    Input: head = [1,2]
    Output: [2,1]

    Example 3:

    Input: head = []
    Output: []



    Constraints:

        The number of nodes in the list is the range [0, 5000].
        -5000 <= Node.val <= 5000



    Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?*/


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
        public ListNode ReverseList(ListNode head)
        {
            return ReverseListRecurse(head);
        }

        private ListNode ReverseListRecurse(ListNode currentNode)
        {
            if (currentNode == null)
            {
                return currentNode;
            }

            if (currentNode.next == null)
            {
                return currentNode;
            }

            var reversedNewHead = ReverseListRecurse(currentNode.next);

            var nextNode = currentNode.next;
            nextNode.next = currentNode;

            currentNode.next = null;

            return reversedNewHead;
        }

        private ListNode ReverseListIter(ListNode currentNode)
        {
            if (currentNode == null) { return currentNode; }

            ListNode previousNode = null;
            ListNode currNode = currentNode;
            ListNode nextNode = currentNode.next;

            while (currNode != null)
            {
                nextNode = currNode.next;

                currNode.next = previousNode;
                previousNode = currNode;

                currNode = nextNode;
            }
            return previousNode;
        }

    }
}

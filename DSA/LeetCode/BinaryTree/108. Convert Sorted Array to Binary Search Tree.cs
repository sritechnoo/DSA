using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.BinaryTree._108ConvertSortedArraytoBinarySearchTree
{
    /*Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.

    A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.



    Example 1:

    Input: nums = [-10,-3,0,5,9]
    Output: [0,-3,9,-10,null,5]
    Explanation: [0,-10,5,null,-3,null,9] is also accepted:

    Example 2:

    Input: nums = [1,3]
    Output: [3,1]
    Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.



    Constraints:

        1 <= nums.length <= 104
        -104 <= nums[i] <= 104
        nums is sorted in a strictly increasing order.

    */

    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length <= 0) { return null; }

            var result = f(nums, 0, nums.Length - 1);
            return result;
        }

        private TreeNode f(int[] nums, int start, int end)
        {
            if (start > end) { return null; }


            int mid = (start + end) / 2;
            TreeNode rootNode = new TreeNode(nums[mid]);
            rootNode.left = f(nums, start, mid - 1);
            rootNode.right = f(nums, mid + 1, end);

            return rootNode;
        }
    }

}
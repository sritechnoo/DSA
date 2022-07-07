using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.BinaryTree.Find_a_pair_with_given_sum_in_BST
{
    class Node
    {
        public int data;
        public Node left, right;
    };

    public class Solution
    {
        static bool DFSInOrder(Node root, int sum, HashSet<int> set)
        {
            if (root == null) { return false; }

            if (DFSInOrder(root.left, sum, set)) { return true; }

            var diff = sum - root.data;
            if (set.Contains(diff))
            {
                Console.WriteLine("Pair is found (" + (sum - root.data) + ", " + root.data + ")");
                return true;
            }
            else
            {
                set.Add(root.data);
            }

            if (DFSInOrder(root.left, sum, set)) { return true; }

            return false;
        }

        void FindPair(Node root, int sum)
        {
            HashSet<int> set = new HashSet<int>();
            if (!DFSInOrder(root, sum, set)) { Console.Write("Pairs do not exit" + "\n"); }
        }
    }
}

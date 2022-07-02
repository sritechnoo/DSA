using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SegmentTrees.Sereja_and_Brackets
{
    public class Solution
    {
        public void Main()
        {
            char[] nums = new char[] { '(', '(',')',')' };
            SegmentTreeBracket sgt = new SegmentTreeBracket(nums);

            int L = 2;
            int R = 5;
            sgt.Query(0, 0, nums.Length - 1, L, R);


            int updateIndex = 2;
            char val = '(';
            sgt.Update(0, 0, nums.Length - 1, updateIndex, val);
        }
    }

    public class Node
    {
        public int open, close, full;
        public Node()
        {

        }
        public Node(int _open, int _close, int _full)
        {
            open = _open;
            close = _close;
            full = _full;
        }
    }
    public class SegmentTreeBracket
    {
        char[] arr;
        Node[] segTree;
        public SegmentTreeBracket(char[] _arr)
        {
            arr = _arr;
            segTree = new Node[4 * _arr.Length];
            this.Build(0, 0, _arr.Length - 1);
        }

        private void Build(int ind, int lowi, int highi)
        {
            /*Fill the Array Values to the Leaf Nodes*/
            if (lowi == highi)
            {
                var leafNode = new Node(_open: arr[lowi] == '(' ? 1 : 0,
                                       _close: arr[lowi] == ')' ? 1 : 0,
                                       _full: 0);

                segTree[ind] = leafNode;
                return;
            }

            int midi = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentind = (ind - 1) / 2;

            Build(leftind, lowi, midi);
            Build(rightind, midi + 1, highi);

            var leftNode = segTree[leftind];
            var rightNode = segTree[rightind];
            var currentRootNode = new Node();
            currentRootNode.open = leftNode.open + rightNode.open - Math.Min(leftNode.open, rightNode.open);
            currentRootNode.close = leftNode.close + rightNode.close - Math.Min(leftNode.close, rightNode.close);
            currentRootNode.full = leftNode.full + rightNode.full + Math.Min(leftNode.full, rightNode.full);
            segTree[ind] = currentRootNode;
        }

        public Node Query(int ind, int lowi, int highi, int L, int R)
        {
            /*No Overlap: return Opposite */
            if (highi < L || R < lowi) { return new Node(); }


            /*Complete Overlap: return seg[indi] */
            if (L <= lowi && highi <= R) { return segTree[ind]; }


            /*Partial Overlap: return leftValue + rightValue */
            int midind = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentindi = (ind - 1) / 2;

            Node leftNode = Query(leftind, lowi, midind, L, R);
            Node rightNode = Query(rightind, midind + 1, highi, L, R);
        
            var currentRootNode = new Node();
            currentRootNode.open = leftNode.open + rightNode.open - Math.Min(leftNode.open, rightNode.open);
            currentRootNode.close = leftNode.close + rightNode.close - Math.Min(leftNode.close, rightNode.close);
            currentRootNode.full = leftNode.full + rightNode.full + Math.Min(leftNode.full, rightNode.full);
            return currentRootNode;
        }

        /* To Update a[position] = val */
        public void Update(int ind, int lowi, int highi, int position, char val)
        {
            if (lowi == highi)
            {
                arr[position] = val;

                var leafNode = new Node(_open: arr[lowi] == '(' ? 1 : 0,
                                       _close: arr[lowi] == ')' ? 1 : 0,
                                       _full: 0);

                segTree[ind] = leafNode;
                return;
            }

            int midind = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentindi = (ind - 1) / 2;

            if (position < midind)
            {
                Update(leftind, lowi, midind, position, val);
            }
            else
            {
                Update(rightind, midind + 1, highi, position, val);
            }

            var leftNode = segTree[leftind];
            var rightNode = segTree[rightind];
            var currentRootNode = new Node();
            currentRootNode.open = leftNode.open + rightNode.open - Math.Min(leftNode.open, rightNode.open);
            currentRootNode.close = leftNode.close + rightNode.close - Math.Min(leftNode.close, rightNode.close);
            currentRootNode.full = leftNode.full + rightNode.full + Math.Min(leftNode.full, rightNode.full);
            segTree[ind] = currentRootNode;
        }
    }
}

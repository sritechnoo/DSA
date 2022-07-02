using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SegmentTrees.SegmentTreeMinimumWithinRange
{
    public class Solution
    {
        public void Main()
        {
            int[] nums = new int[] { 10, 5, 9, 7, 2, 9, 4 };
            SegmentTreeMinimumWithinRange sgt = new SegmentTreeMinimumWithinRange(nums);

            int L = 2;
            int R = 5;
            sgt.Query(0, 0, nums.Length - 1, L, R);


            int updateIndex = 2;
            int val = 30;
            sgt.Update(0, 0, nums.Length - 1, updateIndex, val);
        }
    }
    public class SegmentTreeMinimumWithinRange
    {
        int[] arr;
        int[] segTree;
        public SegmentTreeMinimumWithinRange(int[] _arr)
        {
            arr = _arr;
            segTree = new int[4 * _arr.Length];
            this.Build(0, 0, _arr.Length - 1);
        }

        private void Build(int ind, int lowi, int highi)
        {
            /*Fill the Array Values to the Leaf Nodes*/
            if (lowi == highi)
            {
                segTree[ind] = arr[lowi];
                return;
            }

            int midi = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentind = (ind - 1) / 2;

            Build(leftind, lowi, midi);
            Build(rightind, midi + 1, highi);

            segTree[ind] = Math.Min(segTree[leftind], segTree[rightind]);
        }

        public int Query(int ind, int lowi, int highi, int L, int R)
        {
            /*No Overlap: return Opposite */
            if (highi < L || R < lowi) { return int.MaxValue; }


            /*Complete Overlap: return seg[indi] */
            if (L <= lowi && highi <= R) { return segTree[ind]; }


            /*Partial Overlap: return leftValue + rightValue */
            int mid = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentindi = (ind - 1) / 2;

            int leftValue = Query(leftind, lowi, mid, L, R);
            int rightValue = Query(rightind, mid + 1, highi, L, R);
            return Math.Min(leftValue, rightValue);
        }

        /* To Update a[position] = val */
        public void Update(int indi, int lowi, int highi, int position, int val)
        {
            if (lowi == highi)
            {
                arr[position] = val;
                segTree[indi] = val;
                return;
            }

            int mid = (highi + lowi) / 2;
            int leftind = 2 * indi + 1;
            int rightind = 2 * indi + 2;
            int parentindi = (indi - 1) / 2;

            if (position < mid)
            {
                Update(leftind, lowi, mid, position, val);
            }
            else
            {
                Update(rightind, mid + 1, highi, position, val);
            }

            segTree[indi] = Math.Min(segTree[leftind], segTree[rightind]);
        }
    }
}

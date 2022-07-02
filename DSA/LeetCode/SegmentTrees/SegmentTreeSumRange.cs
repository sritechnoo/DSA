﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SegmentTrees.SegmentTreeSumRange
{
    public class Solution
    {
        public void Main()
        {
            int[] nums = new int[] { 10, 5, 9, 7, 2, 9, 4 };
            SegmentTreeSumRange sgt = new SegmentTreeSumRange(nums);

            int L = 2;
            int R = 5;
            sgt.Query(0, 0, nums.Length - 1, L, R);


            int updateIndex = 2;
            int val = 30;
            sgt.Update(0, 0, nums.Length - 1, updateIndex, val);
        }
    }

    public class SegmentTreeSumRange
    {
        int[] arr;
        int[] segTree;
        public SegmentTreeSumRange(int[] _arr)
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

            segTree[ind] = segTree[leftind] + segTree[rightind];
        }

        public int Query(int ind, int lowi, int highi, int L, int R)
        {
            /*No Overlap: return Opposite */
            if (highi < L || R < lowi) { return 0; }


            /*Complete Overlap: return seg[indi] */
            if (L <= lowi && highi <= R) { return segTree[ind]; }


            /*Partial Overlap: return leftValue + rightValue */
            int midind = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentindi = (ind - 1) / 2;

            int leftValue = Query(leftind, lowi, midind, L, R);
            int rightValue = Query(rightind, midind + 1, highi, L, R);
            return leftValue + rightValue;
        }

        /* To Update a[position] = val */
        public void Update(int ind, int lowi, int highi, int position, int val)
        {
            if (lowi == highi)
            {
                arr[position] = val;
                segTree[ind] = val;
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

            segTree[ind] = segTree[leftind] + segTree[rightind];
        }
    }
}

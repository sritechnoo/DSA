using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SegmentTrees.XorThenOr
{
    /*D. Xenia and Bit Operations
    time limit per test2 seconds
    memory limit per test256 megabytes
    inputstandard input
    outputstandard output
    Xenia the beginner programmer has a sequence a, consisting of 2n non-negative integers: a1, a2, ..., a2n. Xenia is currently studying bit operations. To better understand how they work, Xenia decided to calculate some value v for a.

    Namely, it takes several iterations to calculate value v. At the first iteration, Xenia writes a new sequence a1 or a2, a3 or a4, ..., a2n - 1 or a2n, consisting of 2n - 1 elements. In other words, she writes down the bit-wise OR of adjacent elements of sequence a. At the second iteration, Xenia writes the bitwise exclusive OR of adjacent elements of the sequence obtained after the first iteration. At the third iteration Xenia writes the bitwise OR of the adjacent elements of the sequence obtained after the second iteration. And so on; the operations of bitwise exclusive OR and bitwise OR alternate. In the end, she obtains a sequence consisting of one element, and that element is v.

    Let's consider an example. Suppose that sequence a = (1, 2, 3, 4). Then let's write down all the transformations (1, 2, 3, 4)  →  (1 or 2 = 3, 3 or 4 = 7)  →  (3 xor 7 = 4). The result is v = 4.

    You are given Xenia's initial sequence. But to calculate value v for a given sequence would be too easy, so you are given additional m queries. Each query is a pair of integers p, b. Query p, b means that you need to perform the assignment ap = b. After each query, you need to print the new value v for the new sequence a.

    Input
    The first line contains two integers n and m (1 ≤ n ≤ 17, 1 ≤ m ≤ 105). The next line contains 2n integers a1, a2, ..., a2n (0 ≤ ai < 230). Each of the next m lines contains queries. The i-th line contains integers pi, bi (1 ≤ pi ≤ 2n, 0 ≤ bi < 230) — the i-th query.

    Output
    Print m integers — the i-th integer denotes value v for sequence a after the i-th query.

    Examples
    inputCopy
    2 4
    1 6 3 5
    1 4
    3 4
    1 2
    1 2
    outputCopy
    1
    3
    3
    3
    Note
    For more information on the bit operations, you can follow this link: http://en.wikipedia.org/wiki/Bitwise_operation*/

    public class Solution
    {
        public void Main()
        {
            int[] nums = new int[] { 10, 5, 9, 7, 2, 9, 4 };
            SegmentTreeOrThenXor sgt = new SegmentTreeOrThenXor(nums);

            int L = 2;
            int R = 5;
            sgt.Query(0, 0, nums.Length - 1, L, R);


            int updateIndex = 2;
            int val = 30;
            sgt.Update(0, 0, nums.Length - 1, true, updateIndex, val);
        }
    }

    public class SegmentTreeOrThenXor
    {
        int[] arr;
        int[] segTree;
        public SegmentTreeOrThenXor(int[] _arr)
        {
            arr = _arr;
            segTree = new int[4 * _arr.Length];
            this.Build(0, 0, _arr.Length - 1, true);
        }

        private void Build(int ind, int lowi, int highi, bool isOrOpertation)
        {
            /*To Fill the Array Values to the Leaf Nodes*/
            if (lowi == highi)
            {
                segTree[ind] = arr[lowi];
                return;
            }

            int midi = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentind = (ind - 1) / 2;

            Build(leftind, lowi, midi, !isOrOpertation);
            Build(rightind, midi + 1, highi, !isOrOpertation);

            if (isOrOpertation)
            {
                segTree[ind] = segTree[leftind] | segTree[rightind];
            }
            else
            {
                segTree[ind] = segTree[leftind] ^ segTree[rightind];
            }
        }

        public int Query(int ind, int lowi, int highi, int L, int R)
        {
            /*No Overlap: return Opposite */
            if (highi < L || R < lowi) { return int.MaxValue; }


            /*Complete Overlap: return seg[indi] */
            if (L <= lowi && highi <= R) { return segTree[ind]; }


            /*Partial Overlap: return leftValue + rightValue */
            int midind = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentind = (ind - 1) / 2;

            int leftValue = Query(leftind, lowi, midind, L, R);
            int rightValue = Query(rightind, midind + 1, highi, L, R);
            return Math.Min(leftValue, rightValue);
        }

        /* To Update a[position] = val */
        public void Update(int ind, int lowi, int highi, bool isOrOpertation, int position, int val)
        {
            if (lowi == highi)
            {
                arr[position] = val;
                segTree[ind] = val;
                return;
            }

            int midi = (highi + lowi) / 2;
            int leftind = 2 * ind + 1;
            int rightind = 2 * ind + 2;
            int parentind = (ind - 1) / 2;

            if (position < midi)
            {
                Update(leftind, lowi, midi, !isOrOpertation, position, val);
            }
            else
            {
                Update(rightind, midi + 1, highi, !isOrOpertation, position, val);
            }

            if (isOrOpertation)
            {
                segTree[ind] = segTree[leftind] | segTree[rightind];
            }
            else
            {
                segTree[ind] = segTree[leftind] ^ segTree[rightind];
            }
        }
    }
}

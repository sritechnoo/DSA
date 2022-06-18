using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.PriorityQueue._373_Find_K_Pairs_with_Smallest_Sums
{
    /*You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

    Define a pair (u, v) which consists of one element from the first array and one element from the second array.

    Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.



    Example 1:

    Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
    Output: [[1,2],[1,4],[1,6]]
    Explanation: The first 3 pairs are returned from the sequence: [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]

    Example 2:

    Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
    Output: [[1,1],[1,1]]
    Explanation: The first 2 pairs are returned from the sequence: [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]

    Example 3:

    Input: nums1 = [1,2], nums2 = [3], k = 3
    Output: [[1,3],[2,3]]
    Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]



    Constraints:

        1 <= nums1.length, nums2.length <= 105
        -109 <= nums1[i], nums2[i] <= 109
        nums1 and nums2 both are sorted in ascending order.
        1 <= k <= 104

    */

    public class MinHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class Solution
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            int nums1Length = nums1.Length;
            int nums2Length = nums2.Length;

            if (nums1Length == 0 || nums2Length == 0) { return new List<IList<int>>(); }

            PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>(new MinHeapComparer());

            for (int j = 0; j < nums2Length; j++)
            {
                minHeap.Enqueue((0, j), nums1[0] + nums2[j]);
            }


            var result = new List<IList<int>>();
            while (minHeap.Count > 0 && k-- > 0)
            {
                var currElement = minHeap.Dequeue();

                var currenti = currElement.Item1;
                var currentj = currElement.Item2;

                result.Add(new List<int> { nums1[currenti], nums2[currentj] });

                var nexti = currenti + 1;
                var nextj = currentj;

                if (nextj == nums2Length) { continue; }
                minHeap.Enqueue((nexti, nextj), nums1[nexti] + nums2[nextj]);

            }
            return result;

        }

        public IList<IList<int>> KSmallestPairs1(int[] nums1, int[] nums2, int k)
        {
            int nums1Length = nums1.Length;
            int nums2Length = nums2.Length;

            if (nums1Length == 0 || nums2Length == 0) { return new List<IList<int>>(); }

            PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>(new MinHeapComparer());

            for (int i = 0; i < nums1Length; i++)
            {
                minHeap.Enqueue((i, 0), nums1[i] + nums2[0]);
            }


            var result = new List<IList<int>>();
            while (minHeap.Count > 0 && k-- > 0)
            {
                var currElement = minHeap.Dequeue();

                var currenti = currElement.Item1;
                var currentj = currElement.Item2;

                result.Add(new List<int> { nums1[currenti], nums2[currentj] });

                var nexti = currenti;
                var nextj = currentj + 1;

                if (nextj == nums2Length) { continue; }
                minHeap.Enqueue((nexti, nextj), nums1[nexti] + nums2[nextj]);

            }
            return result;

        }

    }
}

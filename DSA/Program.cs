using System;
using DSA.LeetCode.PriorityQueue._215KthLargestElementinanArray;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().FindKthLargest(nums: new int[] { 3, 2, 1, 5, 6, 4 }, k: 2);

            Console.WriteLine(result);
        }
    }
}

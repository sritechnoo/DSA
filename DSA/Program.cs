using System;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region _215KthLargestElementinanArray
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            var instance = new DSA.LeetCode.PriorityQueue._215KthLargestElementinanArray.Solution();
            var result = instance.FindKthLargest(nums: nums, k: k);
            Console.WriteLine(result);
            #endregion

            #region _73SetMatrixZeroes
            int[][] matrix = new int[3][]
                {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 }
                };
            new DSA.LeetCode.Matrix._73SetMatrixZeroes.Solution().SetZeroes(matrix);
            #endregion

            Console.WriteLine("Hello World");
        }
    }
}

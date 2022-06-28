using System;
using System.Collections.Generic;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region _215KthLargestElementinanArray
            //int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            //int k = 2;
            //var instance = new DSA.LeetCode.PriorityQueue._215KthLargestElementinanArray.Solution();
            //var result = instance.FindKthLargest(nums: nums, k: k);
            //Console.WriteLine(result);
            //#endregion

            //#region _73SetMatrixZeroes
            //int[][] matrix = new int[3][]
            //    {
            //    new int[] { 1, 1, 1 },
            //    new int[] { 1, 0, 1 },
            //    new int[] { 1, 1, 1 }
            //    };
            //new DSA.LeetCode.Matrix._73SetMatrixZeroes.Solution().SetZeroes(matrix);
            //#endregion

            //IList<IList<int>> GenerateResult = new DSA.LeetCode.Matrix._118PascalsTriangle.Solution().Generate(3);
            //Console.WriteLine(GenerateResult);

            //int[] nums = new int[] { 1, 2, 3 };
            //new DSA.LeetCode.Permutations._31_Next_Permutation.Solution().NextPermutation(nums);

            //var result =new DSA.LeetCode.Permutations._60_PermutationSequence.Solution().GetPermutation(n: 4, k: 9);
            //Console.WriteLine(result);

            //string s = "a1b2";
            //var result = new LeetCode.Permutations._784_LetterCasePermutation.Solution().LetterCasePermutation(s: s);
            //Console.WriteLine(result);

            //int numCourses = 4;
            //int[][] prerequisites = new int[][]
            //{
            //    new int[] { 1, 0 },
            //    new int[] { 2, 0 },
            //    new int[] { 3, 1 },
            //    new int[] { 3, 2 },
            //};

            //int numCourses = 2;
            //int[][] prerequisites = new int[numCourses][];

            //int numCourses = 3;
            //int[][] prerequisites = new int[][]
            //{
            //    new int[] { 1, 0 },
            //    new int[] { 1, 2 },
            //    new int[] { 0, 1 }
            //};

            //var result = new LeetCode.Graph.Course_Schedule._210_Course_Schedule_II.Solution().FindOrder(numCourses: numCourses, prerequisites: prerequisites);
            //Console.WriteLine(result);

            //int[] nums1 = new int[] { 1, 7, 11 };
            //int[] nums2 = new int[] { 2, 4, 6 };
            //int k = 3;
            //var result = new LeetCode.PriorityQueue._373_Find_K_Pairs_with_Smallest_Sums.Solution().KSmallestPairs(nums1: nums1, nums2: nums2, k: k);
            //Console.WriteLine(result);

            //int[] nums = new int[] { 4, 2, 3 };
            //int k = 3;
            //var result = new LeetCode.PriorityQueue._1005_Maximize_Sum_Of_Array_After_K_Negations.Solution().LargestSumAfterKNegations(nums: nums, k: k);

            //int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //var result = new LeetCode.Arrays._53_Maximum_Subarray.Solution().MaxSubArray(nums);
            //Console.WriteLine(result);


            //int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            //int m = 3;

            //int[] nums2 = new int[] { 2, 5, 6 };
            //int n = 3;

            //new LeetCode.Arrays._88_Merge_Sorted_Array.Solution().Merge(nums1, m, nums2, n);


            //var result = new LeetCode.DP._91_Decode_Ways.Solution().NumDecodings(s: "12");
            //Console.WriteLine(result);

            //int[] coins = new int[] { 1, 2, 5 };
            //int amount = 11;
            //var result = new LeetCode.DP.Subsequences._322_Coin_Change.Solution().CoinChange(coins: coins, amount: amount);
            //Console.WriteLine(result);

            //int[][] grid = new int[][]
            //{
            //    new int[] { 2,0,0,1 },
            //    new int[] { 0,3,1,0 },
            //    new int[] { 0,5,2,0 },
            //    new int[] { 4,0,0,2 },
            //};
            //var result = new LeetCode.Matrix._6101_Check_if_Matrix_Is_X_Matrix.Solution().CheckXMatrix(grid: grid);
            //Console.WriteLine(result);


            int[] nums = new int[] { 5, 2, 3, 1 };
            var result = new DSA.LeetCode.Sorting.MergeSort._912_Sort_an_Array.Solution().SortArray(nums:nums);
            Console.WriteLine(result);





            Console.WriteLine("Hello World");
        }
    }
}

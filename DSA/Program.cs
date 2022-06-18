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

            int numCourses = 4;
            int[][] prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 0 },
                new int[] { 3, 1 },
                new int[] { 3, 2 },
            };

            //int numCourses = 2;
            //int[][] prerequisites = new int[numCourses][];

            //int numCourses = 3;
            //int[][] prerequisites = new int[][]
            //{
            //    new int[] { 1, 0 },
            //    new int[] { 1, 2 },
            //    new int[] { 0, 1 }
            //};

            var result = new LeetCode.Graph.Course_Schedule._210_Course_Schedule_II.Solution().FindOrder(numCourses: numCourses, prerequisites: prerequisites);
            Console.WriteLine(result);

            Console.WriteLine("Hello World");
        }
    }
}

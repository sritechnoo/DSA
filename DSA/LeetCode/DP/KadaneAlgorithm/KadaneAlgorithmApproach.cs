using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.KadaneAlgorithm
{
    /*Kadane's Algorithm is an iterative dynamic programming algorithm. 
    It calculates the maximum sum subarray ending at a particular position 
    by using the maximum sum subarray ending at the previous position.*/
    public class KadaneAlgorithmApproach
    {
        private int MaxSubarraySumTabulation(int[] nums)
        {
            int[] currSum = new int[nums.Length];
            currSum[0] = nums[0];

            int maxi = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currSum[i] = Math.Max(currSum[i - 1] + nums[i], nums[i]);
                maxi = Math.Max(currSum[i], maxi);
            }
            return maxi;
        }

        private int MaxSubarraySumSpace(int[] nums)
        {

            int maxi = nums[0];

            int currSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currSum = Math.Max(currSum + nums[i], nums[i]);
                maxi = Math.Max(currSum, maxi);
            }
            return maxi;
        }
    }
}

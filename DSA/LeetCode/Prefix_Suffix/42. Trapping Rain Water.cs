using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Prefix_Suffix._42TrappingRainWater
{
    /*
     Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.



    Example 1:

    Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
    Output: 6
    Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

    Example 2:

    Input: height = [4,2,0,3,2,5]
    Output: 9



    Constraints:

        n == height.length
        1 <= n <= 2 * 104
        0 <= height[i] <= 105

    */

    public class Solution
    {
        public int Trap(int[] height)
        {
            return Traps(height);
        }

        private int Traps(int[] heights)
        {
            int[] leftMax = new int[heights.Length];
            leftMax[0] = heights[0];
            for (int i = 1; i < heights.Length - 1; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], heights[i]);
            }

            int[] rightMax = new int[heights.Length];
            rightMax[heights.Length - 1] = heights[heights.Length - 1];
            for (int i = heights.Length - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], heights[i]);
            }

            int result = 0;
            for (int i = 1; i < heights.Length - 1; i++)
            {
                result += Math.Min(rightMax[i], leftMax[i]) - heights[i];
            }
            return result;
        }
    }
}

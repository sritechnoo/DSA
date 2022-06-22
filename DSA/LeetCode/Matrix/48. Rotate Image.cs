using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Matrix._48_Rotate_Image
{
	/*You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

    You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.



    Example 1:

    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [[7,4,1],[8,5,2],[9,6,3]]

    Example 2:

    Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
    Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]



    Constraints:

        n == matrix.length == matrix[i].length
        1 <= n <= 20
        -1000 <= matrix[i][j] <= 1000

    */
	public class Solution
	{
		public void Rotate(int[][] matrix)
		{
			RotateApproach(matrix);
		}

		private void RotateApproach(int[][] matrix)
		{
			/*
             1.Transpose the Matrix
             2. Reverse the element in each row
             */
			int rowLength = matrix.Length;
			int colLength = matrix[0].Length;

			/* 1. Transposing Matrix*/
			for (int r = 0; r < rowLength; r++)
			{
				for (int c = r; c < colLength; c++)
				{
					int temp = matrix[r][c];
					matrix[r][c] = matrix[c][r];
					matrix[c][r] = temp;
				}
			}

			for (int r = 0; r < rowLength; r++)
			{
				int[] row = matrix[r];
				Reverse(row, 0, colLength - 1);
			}
		}

		private void Reverse(int[] nums, int l, int r)
		{
			while (l < r) { Swap(nums, l++, r--); }

		}

		private void Swap(int[] nums, int l, int r)
		{
			int temp = nums[l];
			nums[l] = nums[r];
			nums[r] = temp;
		}
	}
}
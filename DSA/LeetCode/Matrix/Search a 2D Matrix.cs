using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Matrix
{
    /*
    Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix 
    has the following properties:

        Integers in each row are sorted from left to right.
        The first integer of each row is greater than the last integer of the previous row.



    Example 1:

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    Output: true

    Example 2:

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    Output: false
    */

    public class Solution
    {

        public bool SearchMatrix(int[][] matrix, int target)
        {
            return Search(matrix, target);
        }

        private bool Search(int[][] matrix, int target)
        {
            int row = 0;
            int col = matrix[0].Length - 1;

            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == target)
                {
                    return true;
                }

                if (matrix[row][col] < target)
                {
                    row++;
                }
                else
                {
                    col--;
                }
            }

            return false;
        }

        private bool SearchMatrixBruteForce(int[][] matrix, int target)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == target)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}

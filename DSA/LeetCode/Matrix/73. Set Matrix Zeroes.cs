using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Matrix._73SetMatrixZeroes
{
    /*Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

    You must do it in place.



    Example 1:

    Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
    Output: [[1,0,1],[0,0,0],[1,0,1]]

    Example 2:

    Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
    Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]



    Constraints:

        m == matrix.length
        n == matrix[0].length
        1 <= m, n <= 200
        -231 <= matrix[i][j] <= 231 - 1



    Follow up:

        A straightforward solution using O(mn) space is probably a bad idea.
        A simple improvement uses O(m + n) space, but still not the best solution.
        Could you devise a constant space solution?

    */

    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            int rowLength = matrix.Length;
            int colLength = matrix[0].Length;

            HashSet<int> zeroRows = new HashSet<int>();
            HashSet<int> zeroCols = new HashSet<int>();
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        zeroRows.Add(r);
                        zeroCols.Add(c);
                    }
                }
            }

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (zeroRows.Contains(r) || zeroCols.Contains(c))
                    {
                        matrix[r][c] = 0;
                    }
                }
            }

        }
    }
}

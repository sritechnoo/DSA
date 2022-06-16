using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Matrix._118PascalsTriangle
{
    public class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int r = 0; r < numRows; r++)
            {
                int[] row = new int[r + 1];

                row[0] = 1;
                for (int c = 1; c < r; c++)
                {
                    row[c] = result[r - 1][c - 1] + result[r - 1][c];
                }
                row[r] = 1;

                result.Add(row.ToList());
            }

            return result;
        }
    }
}

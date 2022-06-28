using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.Count_Reverse_Pairs
{
    public class Solution
    {
        public int GetPairCount(int[] arr, int n)
        {
            int pairsCount = 0;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > 2 * arr[j]) { pairsCount++; }

            return pairsCount;
        }
    }

}

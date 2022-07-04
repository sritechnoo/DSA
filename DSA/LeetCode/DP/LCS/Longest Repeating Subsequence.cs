using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.LCS.Longest_Repeating_Subsequence
{
    /*Given a string, find the length of the longest repeating subsequence, such that the two subsequences don’t have same string character at the same position, i.e. any ith character in the two subsequences shouldn’t have the same index in the original string. 

   longest-repeating-subsequence

   Examples:

   Input: str = "abc"
   Output: 0
   There is no repeating subsequence

   Input: str = "aab"
   Output: 1
   The two subsequence are 'a'(first) and 'a'(second). 
   Note that 'b' cannot be considered as part of subsequence 
   as it would be at same index in both.

   Input: str = "aabb"
   Output: 2

   Input: str = "axxxy"
   Output: 2

   Recommended PracticeLongest Repeating SubsequenceTry It!

   This problem is just the modification of Longest Common Subsequence problem. The idea is to find the LCS(str, str) where, str is the input string with the restriction that when both the characters are same, they shouldn’t be on the same index in the two strings. */
    public class Solution
    {
        public int LongestRepeatingSubsequence(string text)
        {
            int[][] dp = new int[text.Length][];
            for (int row = 0; row < text.Length; row++)
            {
                dp[row] = new int[text.Length];
                Array.Fill(dp[row], -1);
            }

            int result = DFS(0, 0, text, text, dp);
            return result;
        }

        private int DFS(int ind1, int ind2, string text1, string text2, int[][] dp)
        {
            if (ind1 < 0 || ind2 < 0) return 0;

            if (dp[ind1][ind2] != -1) { return dp[ind1][ind2]; }

            if (text1[ind1] == text2[ind2]
               && ind1 != ind2)
            {
                return 1 + DFS(ind1 - 1, ind2 - 1, text1, text2, dp);

            }
            else
            {
                var s1Take_s2NotTake = DFS(ind1, ind2 - 1, text1, text2, dp);
                var s2Take_s1NotTake = DFS(ind1 - 1, ind2, text1, text2, dp);
                return dp[ind1][ind2] = Math.Max(s1Take_s2NotTake, s2Take_s1NotTake);
            }
        }
    }
}


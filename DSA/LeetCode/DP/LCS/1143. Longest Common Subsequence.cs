using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.LCS._1143_Longest_Common_Subsequence
{
    /*Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.

    A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.

        For example, "ace" is a subsequence of "abcde".

    A common subsequence of two strings is a subsequence that is common to both strings.



    Example 1:

    Input: text1 = "abcde", text2 = "ace" 
    Output: 3  
    Explanation: The longest common subsequence is "ace" and its length is 3.

    Example 2:

    Input: text1 = "abc", text2 = "abc"
    Output: 3
    Explanation: The longest common subsequence is "abc" and its length is 3.

    Example 3:

    Input: text1 = "abc", text2 = "def"
    Output: 0
    Explanation: There is no such common subsequence, so the result is 0.



    Constraints:

        1 <= text1.length, text2.length <= 1000
        text1 and text2 consist of only lowercase English characters.

    */

    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[][] dp = new int[text1.Length][];
            for (int row = 0; row < text1.Length; row++)
            {
                dp[row] = new int[][text2.Length];
                Array.Fill(dp[row], -1);
            }

            int result = LCSDFS(0, 0, text1, text2);
            return result;
        }

        private int LCSDFS(int ind1, int ind2, string text1, string text2)
        {
            if (ind1 < 0 || ind2 < 0) return 0;

            if (DP[ind1][ind2] != -1) { return dp[ind1][ind2]; }

            if (text1[ind1] == text2[ind2])
            {
                return 1 + LCSDFS(ind1 - 1, ind2 - 1, text1, text2);

            }
            else
            {
                var s1Take_s2NotTake = LCSDFS(ind1, ind2 - 1, text1, text2);
                var s2Take_s1NotTake = LCSDFS(ind1 - 1, ind2, text1, text2);
                return dp[ind1][ind2] = Math.Max(s1Take_s2NotTake, s2Take_s1NotTake);

            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Strings._72_Edit_Distance
{
    /*Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

    You have the following three operations permitted on a word:

        Insert a character
        Delete a character
        Replace a character



    Example 1:

    Input: word1 = "horse", word2 = "ros"
    Output: 3
    Explanation: 
    horse -> rorse (replace 'h' with 'r')
    rorse -> rose (remove 'r')
    rose -> ros (remove 'e')

    Example 2:

    Input: word1 = "intention", word2 = "execution"
    Output: 5
    Explanation: 
    intention -> inention (remove 't')
    inention -> enention (replace 'i' with 'e')
    enention -> exention (replace 'n' with 'x')
    exention -> exection (replace 'n' with 'c')
    exection -> execution (insert 'u')



    Constraints:

        0 <= word1.length, word2.length <= 500
        word1 and word2 consist of lowercase English letters.

    */
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            int[][] dp = new int[word1.Length][];
            for (int i = 0; i < word1.Length; i++)
            {
                dp[i] = new int[word2.Length];
                Array.Fill(dp[i], -1);
            }

            return DFS(word1, word2, word1.Length - 1, word2.Length - 1, dp);
        }

        private int DFS(String S1, String S2, int i, int j, int[][] dp)
        {
            if (i < 0) { return j + 1; }

            if (j < 0) { return i + 1; }

            if (dp[i][j] != -1) { return dp[i][j]; }

            if (S1[i] == S2[j])
            {
                return dp[i][j] = 0 + DFS(S1, S2, i - 1, j - 1, dp);
            }

            int deleteOperation = DFS(S1, S2, i - 1, j, dp);
            int updateOperation = DFS(S1, S2, i - 1, j - 1, dp);
            int insertOperation = DFS(S1, S2, i, j - 1, dp);

            return dp[i][j] = 1 + Math.Min(Math.Min(deleteOperation, updateOperation), insertOperation);
        }
    }
}

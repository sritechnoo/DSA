﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP._91_Decode_Ways
{
    /*A message containing letters from A-Z can be encoded into numbers using the following mapping:

    'A' -> "1"
    'B' -> "2"
    ...
    'Z' -> "26"

    To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse of the mapping above (there may be multiple ways). For example, "11106" can be mapped into:

        "AAJF" with the grouping (1 1 10 6)
        "KJF" with the grouping (11 10 6)

    Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".

    Given a string s containing only digits, return the number of ways to decode it.

    The test cases are generated so that the answer fits in a 32-bit integer.



    Example 1:

    Input: s = "12"
    Output: 2
    Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).

    Example 2:

    Input: s = "226"
    Output: 3
    Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

    Example 3:

    Input: s = "06"
    Output: 0
    Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").



    Constraints:

        1 <= s.length <= 100
        s contains only digits and may contain leading zero(s).

    */

    public class Solution
    {
        public int NumDecodings(string s)
        {
            int[] dp = new int[s.Length + 1];
            Array.Fill(dp, -1);
            return DFS(s, 0, dp);
        }

        private int DFS(string s, int ind, int[] dp)
        {
            if (ind == s.Length) { return 1; }

            if (s[ind] == '0') { return 0; }

            if (dp[ind] != -1) { return dp[ind]; }

            int singleDigit = DFS(s, ind + 1, dp);

            int twoDigit = 0;
            if (ind + 1 < s.Length && s[ind] == '1')
            {
                twoDigit = DFS(s, ind + 2, dp);
            }

            if (ind + 1 < s.Length && s[ind] == '2' && s[ind + 1] <= '6')
            {
                twoDigit = DFS(s, ind + 2, dp);
            }

            int result = singleDigit + twoDigit;

            return dp[ind] = result;
        }
    }
}

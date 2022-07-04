using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Strings._97_Interleaving_String
{
    /*Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

    An interleaving of two strings s and t is a configuration where they are divided into non-empty substrings such that:

        s = s1 + s2 + ... + sn
        t = t1 + t2 + ... + tm
        |n - m| <= 1
        The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...

    Note: a + b is the concatenation of strings a and b.



    Example 1:

    Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
    Output: true

    Example 2:

    Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
    Output: false

    Example 3:

    Input: s1 = "", s2 = "", s3 = ""
    Output: true



    Constraints:

        0 <= s1.length, s2.length <= 100
        0 <= s3.length <= 200
        s1, s2, and s3 consist of lowercase English letters.



    Follow up: Could you solve it using only O(s2.length) additional memory space?
    */

    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            Dictionary<string, bool> dp = new Dictionary<string, bool>();
            return s1.Length > 0 && s2.Length > 0 && s3.Length > 0 && (s1.Length + s2.Length == s3.Length) && DFS(0, 0, 0, s1, s2, s3, dp);
        }

        public bool DFS(int ind1, int ind2, int ind3, string s1, string s2, string s3, Dictionary<string, bool> dp)
        {
            if (ind3 == s3.Length)
            {
                if (ind1 == s1.Length && ind2 == s2.Length) { return true; }
                else { return false; }
            }

            string key = $"{ind1}_{ind2}_{ind3}";
            if (dp.ContainsKey(key)) { return dp[key]; }

            if (ind1 == s1.Length)
            {
                return dp[key] = (s2[ind2] == s3[ind3])
                                 ? DFS(ind1, ind2 + 1, ind3 + 1, s1, s2, s3, dp)
                                 : false;
            }

            if (ind2 == s2.Length)
            {
                return dp[key] = (s1[ind1] == s3[ind3])
                                  ? DFS(ind1 + 1, ind2, ind3 + 1, s1, s2, s3, dp)
                                  : false;

            }



            bool first = (s1[ind1] == s3[ind3])
                                  ? DFS(ind1 + 1, ind2, ind3 + 1, s1, s2, s3, dp)
                                  : false;

            bool second = (s2[ind2] == s3[ind3])
                                 ? DFS(ind1, ind2 + 1, ind3 + 1, s1, s2, s3, dp)
                                 : false;


            return dp[key] = first | second;
        }
    }
}

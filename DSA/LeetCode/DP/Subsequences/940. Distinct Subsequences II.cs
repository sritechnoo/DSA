using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Subsequences._940_Distinct_Subsequences_II
{
    /*Given a string s, return the number of distinct non-empty subsequences of s. Since the answer may be very large, return it modulo 109 + 7.
    A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not.



    Example 1:

    Input: s = "abc"
    Output: 7
    Explanation: The 7 distinct subsequences are "a", "b", "c", "ab", "ac", "bc", and "abc".

    Example 2:

    Input: s = "aba"
    Output: 6
    Explanation: The 6 distinct subsequences are "a", "b", "ab", "aa", "ba", and "aba".

    Example 3:

    Input: s = "aaa"
    Output: 3
    Explanation: The 3 distinct subsequences are "a", "aa" and "aaa".



    Constraints:

        1 <= s.length <= 2000
        s consists of lowercase English letters.

    */

    public class Solution
    {
        private const long MOD = 1000000007;
        public int DistinctSubseqII(string s)
        {
            var result = (int)DFS(s, 0, new Dictionary<char, long>());
            return result;
        }

        private long DFS(string s, int index, Dictionary<char, long> frequencyMap)
        {
            if (index == s.Length) { return 1; }

            long value = DFS(s, index + 1, frequencyMap);

            char currentChar = s[index];
            if (!frequencyMap.ContainsKey(currentChar))
            {
                long result = (value * 2) % MOD;
                frequencyMap.Add(currentChar, result);
                return result;
            }
            else
            {
                long result = (value * 2 - frequencyMap[currentChar]) % MOD;
                frequencyMap[currentChar] = value;
                return result;
            }
        }
    }
}

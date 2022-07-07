using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.SlidingWindow._3LongestSubstringWithoutRepeatingCharacters
{
    /*
     * Given a string s, find the length of the longest substring without repeating characters.



    Example 1:

    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.

    Example 2:

    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.

    Example 3:

    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.



    Constraints:

        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.


     */

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            return LengthOfLongestSubstringSlidingWindow(s);
        }

        public int BruteForce(string s)
        {
            int maxi = int.MinValue;

            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> charSet = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    char currentChar = s[j];
                    if (charSet.Contains(currentChar))
                    {
                        maxi = Math.Max(maxi, j - i);
                        break;
                    }
                    charSet.Add(currentChar);
                }
            }
            return maxi;
        }

        public int LengthOfLongestSubstringSlidingWindow(string s)
        {
            int maxLength = 0;
            HashSet<char> set = new HashSet<char>();

            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < s.Length; windowEnd++)
            {
                char currChar = s[windowEnd];

                while (set.Contains(currChar))
                {
                    set.Remove(s[windowStart]);
                    windowStart++;
                }

                set.Add(currChar);
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }
            return maxLength;
        }
    }
}

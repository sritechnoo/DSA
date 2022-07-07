using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SlidingWindow.LongestSubstringKDistinct
{
    class LongestSubstringKDistinct
    {
        public int FindLength(String str, int k)
        {
            Dictionary<Char, int> charFrequencyMap = new Dictionary<Char, int>();
            int maxLength = 0;

            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str.ElementAt(windowEnd);
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    charFrequencyMap[rightChar] = charFrequencyMap[rightChar] + 1;
                }
                else
                {
                    charFrequencyMap.Add(rightChar, 1);
                }

                while (charFrequencyMap.Count() > k)
                {
                    char leftChar = str.ElementAt(windowStart);
                    charFrequencyMap[leftChar] = charFrequencyMap[leftChar] - 1;

                    if (charFrequencyMap[leftChar] == 0)
                    {
                        charFrequencyMap.Remove(leftChar);
                    }
                    windowStart++;
                }
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }

            return maxLength;
        }
    }

}

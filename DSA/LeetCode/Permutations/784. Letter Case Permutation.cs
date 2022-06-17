using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Permutations._784_LetterCasePermutation
{
    /*Given a string s, you can transform every letter individually to be lowercase or uppercase to create another string.

    Return a list of all possible strings we could create. Return the output in any order.



    Example 1:

    Input: s = "a1b2"
    Output: ["a1b2","a1B2","A1b2","A1B2"]

    Example 2:

    Input: s = "3z4"
    Output: ["3z4","3Z4"]



    Constraints:

        1 <= s.length <= 12
        s consists of lowercase English letters, uppercase English letters, and digits.

    */

    public class Solution
    {
        public IList<string> LetterCasePermutation(string s)
        {
            List<String> result = new List<string>();
            DFS(s.ToCharArray(), 0, result);
            return result;
        }

        private void DFS(char[] input, int ind, List<String> result)
        {
            if (ind == input.Length)
            {
                result.Add(new String(input));
                return;
            }

            if (char.IsLetter(input[ind]))
            {
                //Lower case branch
                input[ind] = char.ToLower(input[ind]);
                DFS(input, ind + 1, result);

                //Upper case branch
                input[ind] = char.ToUpper(input[ind]);
                DFS(input, ind + 1, result);
            }
            else
            {
                DFS(input, ind + 1, result);
            }
        }
    }
}


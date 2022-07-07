using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.Check_if_a_string_has_all_unique_characters_without_using_any_additional_data_structure
{
    public class Solution
    {
        public bool CheckIfStringContainsUniqueChar(string input)
        {
            int check = 0;

            foreach (var currChar in input)
            {
                int currCharInInt = currChar - 'a';

                /*Check Current char bit is set or not */
                if ((check & (1 << currCharInInt)) > 0) { return false; }

                /*set the char bit as 1*/
                check |= (1 << currCharInInt);
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._990SatisfiabilityofEqualityEquations
{
    /*You are given an array of strings equations that represent relationships between variables where each string equations[i] is of length 4 and takes one of two different forms: "xi==yi" or "xi!=yi".Here, xi and yi are lowercase letters (not necessarily different) that represent one-letter variable names.

   Return true if it is possible to assign integers to variable names so as to satisfy all the given equations, or false otherwise.



   Example 1:

   Input: equations = ["a==b","b!=a"]
   Output: false
   Explanation: If we assign say, a = 1 and b = 1, then the first equation is satisfied, but not the second.
   There is no way to assign the variables to satisfy both equations.

   Example 2:

   Input: equations = ["b==a","a==b"]
   Output: true
   Explanation: We could assign a = 1 and b = 1 to satisfy both equations.



   Constraints:

       1 <= equations.length <= 500
       equations[i].length == 4
       equations[i][0] is a lowercase letter.
       equations[i][1] is either '=' or '!'.
       equations[i][2] is '='.
       equations[i][3] is a lowercase letter.

   */
    public class Solution
    {
        public bool EquationsPossible(string[] equations)
        {
            DisJointSet disJointSet = new DisJointSet(26);

            foreach (var equation in equations)
            {
                if (equation[1] == '=')
                {
                    disJointSet.Union(equation[0] - 'a', equation[3] - 'a');
                }
            }

            foreach (var equation in equations)
            {
                if (equation[1] == '!')
                {
                    if (disJointSet.Find(equation[0] - 'a') == disJointSet.Find(equation[3] - 'a'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public class DisJointSet
    {
        private int[] parents;
        private int circles;

        public DisJointSet(int n)
        {
            parents = new int[n];
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
            }
            circles = n;
        }

        public int Find(int x)
        {
            if (parents[x] == x) { return x; }

            return Find(parents[x]);
        }

        public bool Union(int a, int b)
        {
            int groupA = Find(a);
            int groupB = Find(b);

            if (groupA == groupB) { return false; }

            parents[groupA] = groupB;
            circles--;
            return true;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Number_of_ways_to_pair_people
{
    public class Solution
    {
        /*Given that there are p people in a party. Each person can either join dance as a single individual or as a pair with any other. The task is to find the number of different ways in which p people can join the dance.
        Examples: 


        Input : p = 3
        Output : 4
        Let the three people be P1, P2 and P3
        Different ways are: {P1, P2, P3}, {{P1, P2}, P3},
        {{P1, P3}, P2} and {{P2, P3}, P1}.

        Input : p = 2
        Output : 2
        The groups are: {P1, P2} and {{P1, P2}}.


        Approach: The idea is to use dynamic programming to solve this problem. There are two situations: Either the person join dance as single individual or as a pair. For the first case the problem reduces to finding the solution for p-1 people. For the second case, there are p-1 choices to select an individual for pairing and after selecting an individual for pairing the problem reduces to finding solution for p-2 people as two people among p are already paired. 
        So the formula for dp is: 


        dp[p] = dp[p-1] + (p-1) * dp[p-2].*/

        public int findWaysToPair(int p)
        {
            return DFS(p);
        }

        private int DFS(int p)
        {
            if (p <= 0) { return 0; }

            if (p == 1) { return 1; }
            if (p == 2) { return 2; }

            int single = DFS(p - 1);
            int pair = (p - 1) * DFS(p - 2);

            return single + pair;
        }
    }
}

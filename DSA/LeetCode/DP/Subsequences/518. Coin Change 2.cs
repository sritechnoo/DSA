using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Subsequences._518_Coin_Change_2
{
    /*You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

    Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0.

    You may assume that you have an infinite number of each kind of coin.

    The answer is guaranteed to fit into a signed 32-bit integer.



    Example 1:

    Input: amount = 5, coins = [1,2,5]
    Output: 4
    Explanation: there are four ways to make up the amount:
    5=5
    5=2+2+1
    5=2+1+1+1
    5=1+1+1+1+1

    Example 2:

    Input: amount = 3, coins = [2]
    Output: 0
    Explanation: the amount of 3 cannot be made up just with coins of 2.

    Example 3:

    Input: amount = 10, coins = [10]
    Output: 1



    Constraints:

        1 <= coins.length <= 300
        1 <= coins[i] <= 5000
        All the values of coins are unique.
        0 <= amount <= 5000

    */

    public class Solution
    {
        public int Change(int amount, int[] coins)
        {
            return CoinChangeFromZerothIndex(coins, amount);
        }

        public int CoinChangeFromZerothIndex(int[] coins, int amount)
        {
            int[][] dp = new int[coins.Length][];
            for (int row = 0; row < coins.Length; row++)
            {
                dp[row] = new int[amount + 1];
                Array.Fill(dp[row], -1);
            }

            var result = DFSFromZerothIndex(coins, amount, 0, dp);
            return result == int.MaxValue ? -1 : result;
        }

        private int DFSFromZerothIndex(int[] coins, int amount, int ind, int[][] dp)
        {
            if (amount == 0) { return 1; }

            if (amount < 0) { return 0; }

            if (ind == coins.Length) { return 0; }

            if (dp[ind][amount] != -1) { return dp[ind][amount]; }


            int notTake = 0 + DFSFromZerothIndex(coins, amount, ind + 1, dp);

            int take = 0;
            if (coins[ind] <= amount)
            {
                take = DFSFromZerothIndex(coins, amount - coins[ind], ind, dp);
            }

            return dp[ind][amount] = take + notTake;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.Subsequences._322_Coin_Change
{
    /*You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

    Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    You may assume that you have an infinite number of each kind of coin.



    Example 1:

    Input: coins = [1,2,5], amount = 11
    Output: 3
    Explanation: 11 = 5 + 5 + 1

    Example 2:

    Input: coins = [2], amount = 3
    Output: -1

    Example 3:

    Input: coins = [1], amount = 0
    Output: 0



    Constraints:

        1 <= coins.length <= 12
        1 <= coins[i] <= 231 - 1
        0 <= amount <= 104

    */

    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            //var result = CoinChangeFromLastIndex(coins, amount);
            var result = CoinChangeFromZerothIndex(coins, amount);
            return result == int.MaxValue ? -1 : result;
        }


        public int CoinChangeFromLastIndex(int[] coins, int amount)
        {
            int[][] dp = new int[coins.Length][];
            for (int row = 0; row < coins.Length; row++)
            {
                dp[row] = new int[amount + 1];
                Array.Fill(dp[row], -1);
            }

            var result = DFSFromLastIndex(coins, amount, coins.Length - 1, dp);
            return result == int.MaxValue ? -1 : result;
        }

        private int DFSFromLastIndex(int[] coins, int amount, int ind, int[][] dp)
        {

            if (ind == 0)
            {
                if (amount % coins[0] == 0) { return amount / coins[0]; }
                else { return int.MaxValue; }
            }

            if (dp[ind][amount] != -1) { return dp[ind][amount]; }

            int notTake = 0 + DFSFromLastIndex(coins, amount, ind - 1, dp);

            int take = int.MaxValue;
            if (coins[ind] <= amount)
            {
                int subProbResult = DFSFromLastIndex(coins, amount - coins[ind], ind, dp);
                take = subProbResult != int.MaxValue ? 1 + subProbResult : int.MaxValue;
            }

            return dp[ind][amount] = Math.Min(take, notTake);
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
            if (amount == 0) { return 0; }

            if (amount < 0) { return int.MaxValue; }

            if (ind == coins.Length) { return int.MaxValue; }

            if (dp[ind][amount] != -1) { return dp[ind][amount]; }


            int notTake = 0 + DFSFromZerothIndex(coins, amount, ind + 1, dp);

            int take = int.MaxValue;
            if (coins[ind] <= amount)
            {
                int subProbResult = DFSFromZerothIndex(coins, amount - coins[ind], ind, dp);
                take = subProbResult != int.MaxValue ? 1 + subProbResult : int.MaxValue;
            }

            return dp[ind][amount] = Math.Min(take, notTake);
        }
    }
}

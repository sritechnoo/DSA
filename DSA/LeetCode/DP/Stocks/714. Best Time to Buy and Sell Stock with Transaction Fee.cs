using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.Stocks._714BestTimetoBuyandSellStockwithTransactionFee
{
    /*
     You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.

   Find the maximum profit you can achieve. You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.

   Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).



   Example 1:

   Input: prices = [1,3,2,8,4,9], fee = 2
   Output: 8
   Explanation: The maximum profit can be achieved by:
   - Buying at prices[0] = 1
   - Selling at prices[3] = 8
   - Buying at prices[4] = 4
   - Selling at prices[5] = 9
   The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.

   Example 2:

   Input: prices = [1,3,7,5,10,3], fee = 3
   Output: 6



   Constraints:

       1 <= prices.length <= 5 * 104
       1 <= prices[i] < 5 * 104
       0 <= fee < 5 * 104

   */

    public class Solution
    {
        public int MaxProfit(int[] prices, int fee)
        {
            return RecureFunctionDP(0, true, new Dictionary<string, int>(), prices, fee);
        }

        int RecureFunction(int ind, bool isBuyAllowed, int[] prices, int fee)
        {
            int n = prices.Length;
            if (ind == n) { return 0; }

            if (isBuyAllowed)
            {
                int buyPick = -prices[ind] + RecureFunction(ind + 1, false, prices, fee);
                int buyNotPick = 0 + RecureFunction(ind + 1, true, prices, fee);

                return Math.Max(buyPick, buyNotPick);
            }
            else
            {
                int sellPick = prices[ind] + RecureFunction(ind + 1, true, prices, fee) - fee;
                int sellNotPick = 0 + RecureFunction(ind + 1, false, prices, fee);

                return Math.Max(sellPick, sellNotPick);
            }
        }

        int RecureFunctionDP(int ind, bool isBuyAllowed, Dictionary<string, int> dp, int[] prices, int fee)
        {
            int n = prices.Length;
            string dpKey = $"{ind}-{isBuyAllowed}";
            if (ind == n) { return 0; }

            if (dp.ContainsKey(dpKey)) { return dp[dpKey]; }

            if (isBuyAllowed)
            {
                int buyPick = -prices[ind] + RecureFunctionDP(ind + 1, false, dp, prices, fee);
                int buyNotPick = 0 + RecureFunctionDP(ind + 1, true, dp, prices, fee);

                var result = Math.Max(buyPick, buyNotPick);
                dp.Add(dpKey, result);
                return result;
            }
            else
            {
                int sellPick = prices[ind] + RecureFunctionDP(ind + 1, true, dp, prices, fee) - fee;
                int sellNotPick = 0 + RecureFunctionDP(ind + 1, false, dp, prices, fee);

                var result = Math.Max(sellPick, sellNotPick);
                dp.Add(dpKey, result);
                return result;
            }
        }
    }
}

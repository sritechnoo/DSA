using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.Stocks._309BestTimetoBuyandSellStockwithCooldown
{
    /*You are given an array prices where prices[i] is the price of a given stock on the ith day.

    Find the maximum profit you can achieve. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:

        After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).

    Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).



    Example 1:

    Input: prices = [1,2,3,0,2]
    Output: 3
    Explanation: transactions = [buy, sell, cooldown, buy, sell]

    Example 2:

    Input: prices = [1]
    Output: 0



    Constraints:

        1 <= prices.length <= 5000
        0 <= prices[i] <= 1000

    */

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            return RecureFunctionDP(0, true, new Dictionary<string, int>(), prices);
        }

        int RecureFunction(int ind, bool isBuyAllowed, int[] prices)
        {
            int n = prices.Length;
            if (ind == n) { return 0; }


            if (isBuyAllowed)
            {
                int buyPick = -prices[ind] + RecureFunction(ind + 1, false, prices);
                int buyNotPick = 0 + RecureFunction(ind + 1, true, prices);

                return Math.Max(buyPick, buyNotPick);
            }
            else
            {
                int sellPick = prices[ind] + RecureFunction(ind + 1, true, prices);
                int sellNotPick = 0 + RecureFunction(ind + 1, false, prices);

                return Math.Max(sellPick, sellNotPick);
            }
        }

        int RecureFunctionDP(int ind, bool isBuyAllowed, Dictionary<string, int> dp, int[] prices)
        {
            string dpKey = $"{ind}-{isBuyAllowed}";
            int n = prices.Length;

            if (ind >= n) { return 0; }

            if (dp.ContainsKey(dpKey)) { return dp[dpKey]; }

            if (isBuyAllowed)
            {
                int buyPick = -prices[ind] + RecureFunctionDP(ind + 1, false, dp, prices);
                int buyNotPick = 0 + RecureFunctionDP(ind + 1, true, dp, prices);

                var result = Math.Max(buyPick, buyNotPick);
                dp.Add(dpKey, result);
                return result;
            }
            else
            {
                int sellPick = prices[ind] + RecureFunctionDP(ind + 2, true, dp, prices);
                int sellNotPick = 0 + RecureFunctionDP(ind + 1, false, dp, prices);

                var result = Math.Max(sellPick, sellNotPick);
                dp.Add(dpKey, result);
                return result;
            }
        }
    }
}

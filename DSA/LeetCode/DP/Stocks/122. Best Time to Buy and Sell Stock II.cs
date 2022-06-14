using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.Stocks._122BestTimetoBuyandSellStockII
{
    /*You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

    On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.

    Find and return the maximum profit you can achieve.



    Example 1:

    Input: prices = [7,1,5,3,6,4]
    Output: 7
    Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
    Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
    Total profit is 4 + 3 = 7.

    Example 2:

    Input: prices = [1,2,3,4,5]
    Output: 4
    Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
    Total profit is 4.

    Example 3:

    Input: prices = [7,6,4,3,1]
    Output: 0
    Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.



    Constraints:

        1 <= prices.length <= 3 * 104
        0 <= prices[i] <= 104

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
            int n = prices.Length;
            string dpKey = $"{ind}-{isBuyAllowed}";
            if (ind == n) { return 0; }

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
                int sellPick = prices[ind] + RecureFunctionDP(ind + 1, true, dp, prices);
                int sellNotPick = 0 + RecureFunctionDP(ind + 1, false, dp, prices);

                var result = Math.Max(sellPick, sellNotPick);
                dp.Add(dpKey, result);
                return result;
            }
        }
    }
}

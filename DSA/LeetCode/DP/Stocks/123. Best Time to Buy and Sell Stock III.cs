using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.Stocks._123BestTimetoBuyandSellStockIII
{
    /*
     You are given an array prices where prices[i] is the price of a given stock on the ith day.

    Find the maximum profit you can achieve. You may complete at most two transactions.

    Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).



    Example 1:

    Input: prices = [3,3,5,0,0,3,1,4]
    Output: 6
    Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
    Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.

    Example 2:

    Input: prices = [1,2,3,4,5]
    Output: 4
    Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
    Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time. You must sell before buying again.

    Example 3:

    Input: prices = [7,6,4,3,1]
    Output: 0
    Explanation: In this case, no transaction is done, i.e. max profit = 0.



    Constraints:

        1 <= prices.length <= 105
        0 <= prices[i] <= 105

    */

    using System.Collections.Generic;

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            return RecureFunctionDP(0, true, new Dictionary<string, int>(), prices, 2);
        }


        int RecureFunctionDP(int ind, bool isBuyAllowed, Dictionary<string, int> dp, int[] prices, int kTransaction)
        {
            int n = prices.Length;
            string dpKey = $"{ind}-{isBuyAllowed}-{kTransaction}";

            if (dp.ContainsKey(dpKey)) { return dp[dpKey]; }

            if (ind == n) { return 0; }

            if (kTransaction <= 0) { return 0; }

            if (isBuyAllowed)
            {
                int buyPick = -prices[ind] + RecureFunctionDP(ind + 1, false, dp, prices, kTransaction);
                int buyNotPick = 0 + RecureFunctionDP(ind + 1, true, dp, prices, kTransaction);

                var result = Math.Max(buyPick, buyNotPick);
                dp.Add(dpKey, result);
                return result;
            }
            else
            {
                int sellPick = prices[ind] + RecureFunctionDP(ind + 1, true, dp, prices, kTransaction - 1);
                int sellNotPick = 0 + RecureFunctionDP(ind + 1, false, dp, prices, kTransaction);

                var result = Math.Max(sellPick, sellNotPick);
                dp.Add(dpKey, result);
                return result;
            }
        }
    }
}

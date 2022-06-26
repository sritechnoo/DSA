using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.Grid._688_Knight_Probability_in_Chessboard
{
    public class Solution
    {
        public double KnightProbability(int n, int k, int row, int column)
        {
            Dictionary<string, double> memo = new Dictionary<string, double>();
            return DFS(n, k, row, column, memo);
        }

        List<(int, int)> directions = new List<(int, int)> { (-2, 1), (-1, 2), (1, 2), (2, 1), (2, -1), (1, -2), (-1, -2), (-2, -1) };
        public double DFS(int N, int K, int r, int c, Dictionary<string, double> memo)
        {
            if (r < 0 || r >= N || c < 0 || c >= N || K < 0)
            {
                return 0;
            }

            if (K == 0)
            {
                return 1;
            }
            string key = K + "," + r + "," + c;

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            double result = 0;
            foreach (var direction in directions)
            {
                int newr = r + direction.Item1;
                int newc = c + direction.Item2;
                result += DFS(N, K - 1, newr, newc, memo);
            }

            memo.Add(key, result / 8);
            return memo[key];
        }
    }
}

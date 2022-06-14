using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.DP.LCS
{

    public class LongestCommonSubSeq
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int result = GetLCSTab(text1, text2);
            return result;
        }

        private T[] GetInitializedArray<T>(int length, T value)
        {
            var array = new T[length];
            for (int index = 0; index < length; index++)
            {
                array[index] = value;
            }
            return array;
        }
        private T[,] GetInitializedMatrixArray<T>(int height, int width, T value)
        {
            var matrixArray = new T[height, width];
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    matrixArray[row, col] = value;
                }
            }
            return matrixArray;
        }


        public int GetLCSWithoutShift(string text1, string text2)
        {
            int[,] dp = GetInitializedMatrixArray(text1.Length, text2.Length, -1);
            int result = GetLCSWithoutShiftRecurse(text1.Length - 1, text2.Length - 1, text1, text2, dp);
            return result;
        }
        private int GetLCSWithoutShiftRecurse(int ind1, int ind2, string text1, string text2, int[,] dp)
        {
            if (ind1 < 0 || ind2 < 0) { return 0; }

            if (dp[ind1, ind2] != -1) { return dp[ind1, ind2]; }

            if (text1[ind1] == text2[ind2])
            {
                dp[ind1, ind2] = 1 + GetLCSWithoutShiftRecurse(ind1 - 1, ind2 - 1, text1, text2, dp);
                return dp[ind1, ind2];
            }
            else
            {
                var s1Take_s2NotTake = GetLCSWithoutShiftRecurse(ind1, ind2 - 1, text1, text2, dp);
                var s2Take_s1NotTake = GetLCSWithoutShiftRecurse(ind1 - 1, ind2, text1, text2, dp);

                dp[ind1, ind2] = Math.Max(s1Take_s2NotTake, s2Take_s1NotTake);
                return dp[ind1, ind2];
            }
        }


        public int GetLCSWithShift(string text1, string text2)
        {
            int[,] dp = GetInitializedMatrixArray(text1.Length + 1, text2.Length + 1, -1);
            int result = GetLCSWithShiftRecurse(text1.Length - 1 + 1, text2.Length - 1 + 1, text1, text2, dp);
            return result;
        }
        private int GetLCSWithShiftRecurse(int ind1, int ind2, string text1, string text2, int[,] dp)
        {
            if (ind1 == 0 || ind2 == 0) { return 0; }

            if (dp[ind1, ind2] != -1) { return dp[ind1, ind2]; }

            if (text1[ind1 - 1] == text2[ind2 - 1])
            {
                dp[ind1, ind2] = 1 + GetLCSWithShiftRecurse(ind1 - 1, ind2 - 1, text1, text2, dp);
                return dp[ind1, ind2];
            }
            else
            {
                var s1Take_s2NotTake = GetLCSWithShiftRecurse(ind1, ind2 - 1, text1, text2, dp);
                var s2Take_s1NotTake = GetLCSWithShiftRecurse(ind1 - 1, ind2, text1, text2, dp);

                dp[ind1, ind2] = Math.Max(s1Take_s2NotTake, s2Take_s1NotTake);

                return dp[ind1, ind2];
            }
        }


        public int GetLCSTab(string text1, string text2)
        {
            var lcsTabulation = GetLCSTabulation(text1, text2);
            int rowLength = lcsTabulation.GetLength(0);
            int colLength = lcsTabulation.GetLength(1);

            PrintLCSTabulation(text1, text2, lcsTabulation);

            var lcsString = GetLCSString(text1, text2, lcsTabulation);

            var lcsLength = lcsTabulation[rowLength - 1, colLength - 1];
            return lcsLength;
        }
        private int[,] GetLCSTabulation(string text1, string text2)
        {
            int[,] dp = GetInitializedMatrixArray(text1.Length + 1, text2.Length + 1, 0);

            int rowLength = dp.GetLength(0);
            int colLength = dp.GetLength(1);

            // for ind1 == 0
            for (int colIndex = 0; colIndex < colLength; colIndex++)
            {
                dp[0, colIndex] = 0;
            }

            // for ind2 == 0
            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                dp[rowIndex, 0] = 0;
            }

            for (int rowIndex = 1; rowIndex < rowLength; rowIndex++)
            {
                for (int colIndex = 1; colIndex < colLength; colIndex++)
                {
                    if (text1[rowIndex - 1] == text2[colIndex - 1])
                    {
                        dp[rowIndex, colIndex] = 1 + dp[rowIndex - 1, colIndex - 1];
                    }
                    else
                    {
                        var s1Take_s2NotTake = dp[rowIndex, colIndex - 1];
                        var s2Take_s1NotTake = dp[rowIndex - 1, colIndex];

                        dp[rowIndex, colIndex] = Math.Max(s1Take_s2NotTake, s2Take_s1NotTake);
                    }
                }
            }
            return dp;
        }
        private void PrintLCSTabulation(string text1, string text2, int[,] dp)
        {
            var rowLength = dp.GetLength(0);
            var colLength = dp.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colLength; colIndex++)
                {
                    Console.Write(dp[rowIndex, colIndex]);
                    Console.Write("\t");

                }
                Console.WriteLine("\n");
            }
        }
        private string GetLCSString(string text1, string text2, int[,] dp)
        {
            int rowLength = dp.GetLength(0);
            int colLength = dp.GetLength(1);

            var rowIndex = rowLength - 1;
            var colIndex = colLength - 1;

            int resultLength = dp[rowIndex, colIndex];
            string result = string.Empty;


            while (rowIndex > 0 && colIndex > 0)
            {
                if (text1[rowIndex - 1] == text2[colIndex - 1])
                {
                    result = text1[rowIndex - 1] + result;
                    rowIndex--;
                    colIndex--;
                    continue;
                }

                // previous Column > previous Row
                if (dp[rowIndex, colIndex - 1] > dp[rowIndex, colIndex - 1])
                {
                    colIndex--;
                }
                else
                {
                    rowIndex--;
                }
            }

            Console.WriteLine($"LCS String = {result}");
            return result;
        }
    }
}

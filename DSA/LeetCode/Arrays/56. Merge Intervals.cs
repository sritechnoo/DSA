using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays._56_Merge_Intervals
{
    /*Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.



    Example 1:

    Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    Output: [[1,6],[8,10],[15,18]]
    Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

    Example 2:

    Input: intervals = [[1,4],[4,5]]
    Output: [[1,5]]
    Explanation: Intervals [1,4] and [4,5] are considered overlapping.



    Constraints:

        1 <= intervals.length <= 104
        intervals[i].length == 2
        0 <= starti <= endi <= 104

    */

    public class StartTimeAscComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[0]);
        }
    }

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, new StartTimeAscComparer());
            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);
            for (int ind = 1; ind < intervals.Length; ind++)
            {
                int[] LastItem = result[result.Count - 1];
                int[] currItem = intervals[ind];

                if (LastItem[1] < currItem[0])
                {
                    result.Add(intervals[ind]);
                }
                else
                {
                    LastItem[1] = Math.Max(LastItem[1], currItem[1]);
                }
            }

            var finalResult = result.Select(x => new int[] { x[0], x[1] });
            return finalResult.ToArray();
        }
    }
}

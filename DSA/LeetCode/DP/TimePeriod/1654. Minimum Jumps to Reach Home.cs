using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.TimePeriod._1654.Minimum_Jumps_to_Reach_Home
{
    /*A certain bug's home is on the x-axis at position x. Help them get there from position 0.

    The bug jumps according to the following rules:

        It can jump exactly a positions forward (to the right).
        It can jump exactly b positions backward (to the left).
        It cannot jump backward twice in a row.
        It cannot jump to any forbidden positions.

    The bug may jump forward beyond its home, but it cannot jump to positions numbered with negative integers.

    Given an array of integers forbidden, where forbidden[i] means that the bug cannot jump to the position forbidden[i], and integers a, b, and x, return the minimum number of jumps needed for the bug to reach its home. If there is no possible sequence of jumps that lands the bug on position x, return -1.



    Example 1:

    Input: forbidden = [14,4,18,1,15], a = 3, b = 15, x = 9
    Output: 3
    Explanation: 3 jumps forward (0 -> 3 -> 6 -> 9) will get the bug home.

    Example 2:

    Input: forbidden = [8,3,16,6,12,20], a = 15, b = 13, x = 11
    Output: -1

    Example 3:

    Input: forbidden = [1,6,2,14,5,17,4], a = 16, b = 9, x = 7
    Output: 2
    Explanation: One jump forward (0 -> 16) then one jump backward (16 -> 7) will get the bug home.



    Constraints:

        1 <= forbidden.length <= 1000
        1 <= a, b, forbidden[i] <= 2000
        0 <= x <= 2000
        All the elements in forbidden are distinct.
        Position x is not forbidden.

    */
    public class Solution
    {
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {

            //return DFS(0, false, forbidden, a, b, x);
            return BFS(forbidden, a, b, x);
        }

        private int DFS(int ind, bool isLastStepIsBack, int[] forbidden, int fwdStep, int backwardstep, int target)
        {

            if (ind == target) { return 0; }

            if (forbidden.Contains(ind)) return int.MaxValue;

            int result;

            if (isLastStepIsBack == false)
            {
                int fwdResult = 1 + DFS(ind + fwdStep, false, forbidden, fwdStep, backwardstep, target);
                int backResult = 1 + DFS(ind + backwardstep, true, forbidden, fwdStep, backwardstep, target);
                result = Math.Min(fwdResult, backResult);
            }
            else
            {
                result = 1 + DFS(ind + fwdStep, false, forbidden, fwdStep, backwardstep, target);
            }

            return result;
        }


        private int BFS(int[] forbidden, int a, int b, int x)
        {
            int maxReachLimit = 2000 + a + b;

            var forbiddenSet = new HashSet<int>(forbidden);
            var visitedSet = new HashSet<(int, bool)>();

            var queue = new Queue<(int Pos, bool IsBackward)>();

            queue.Enqueue((0, false));

            int totalSteps = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;

                while (count-- > 0)
                {
                    var cur = queue.Dequeue();

                    if (cur.Pos == x) return totalSteps;

                    if (forbiddenSet.Contains(cur.Pos) || visitedSet.Contains(cur)) continue;

                    visitedSet.Add(cur);

                    if (cur.Pos + a <= maxReachLimit)
                        queue.Enqueue((cur.Pos + a, false));

                    if (cur.Pos - b >= 0 && !cur.IsBackward)
                        queue.Enqueue((cur.Pos - b, true));
                }
                totalSteps++;
            }

            return -1;
        }
    }
}

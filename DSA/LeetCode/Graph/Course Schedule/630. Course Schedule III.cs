using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Graph.Course_Schedule._630_Course_Schedule_III
{
    /*There are n different online courses numbered from 1 to n. You are given an array courses where courses[i] = [durationi, lastDayi] indicate that the ith course should be taken continuously for durationi days and must be finished before or on lastDayi.

    You will start on the 1st day and you cannot take two or more courses simultaneously.

    Return the maximum number of courses that you can take.



    Example 1:

    Input: courses = [[100,200],[200,1300],[1000,1250],[2000,3200]]
    Output: 3
    Explanation: 
    There are totally 4 courses, but you can take 3 courses at most:
    First, take the 1st course, it costs 100 days so you will finish it on the 100th day, and ready to take the next course on the 101st day.
    Second, take the 3rd course, it costs 1000 days so you will finish it on the 1100th day, and ready to take the next course on the 1101st day. 
    Third, take the 2nd course, it costs 200 days so you will finish it on the 1300th day. 
    The 4th course cannot be taken now, since you will finish it on the 3300th day, which exceeds the closed date.

    Example 2:

    Input: courses = [[1,2]]
    Output: 1

    Example 3:

    Input: courses = [[3,2],[4,3]]
    Output: 0
    */
    /*
     * https://www.youtube.com/watch?v=ey8FxYsFAMU
     */

    public class Solution
    {
        public class CourseDeadLineAscComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[1].CompareTo(y[1]);
            }
        }

        public class MinHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }

        public class MaxHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        public int ScheduleCourse(int[][] courses)
        {
            Array.Sort(courses, new CourseDeadLineAscComparer());

            int totalDuration = 0;
            PriorityQueue<int, int> maxHeapForDuration = new PriorityQueue<int, int>(new MaxHeapComparer());

            for (int i = 0; i < courses.Length; i++)
            {
                int currentDuration = courses[i][0];
                int currentDeadline = courses[i][1];

                if (currentDuration <= currentDeadline)
                {
                    //Check if adding this current course will be completed within the current deadline
                    if (totalDuration + currentDuration <= currentDeadline)
                    {
                        maxHeapForDuration.Enqueue(currentDuration, currentDuration);
                        totalDuration = totalDuration + currentDuration;
                    }
                    else
                    {
                        if (maxHeapForDuration.Peek() > currentDuration)
                        {
                            totalDuration = totalDuration - maxHeapForDuration.Dequeue();

                            maxHeapForDuration.Enqueue(currentDuration, currentDuration);
                            totalDuration = totalDuration + currentDuration;
                        }
                    }
                }
            }
            return maxHeapForDuration.Count;
        }
    }
}

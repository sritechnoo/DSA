using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.SlidingWindow.Minimum_subarray_size
{
    public class Solution
    {
        public int Minimum_subarray_size(int[] nums, int k, int n)
        {

            int ans = n;
            int sum = 0;

            int starti = 0;
            for (int endi = 0; endi < n; endi++)
            {

                // Sliding window from left
                sum += nums[endi];

                while (sum > k)
                {
                    // Sliding window from right
                    sum -= nums[starti];
                    starti++;

                    // Storing sub-array size - 1
                    // for which sum was greater than k
                    ans = Math.Min(ans, endi - starti + 1);

                    // Sum will be 0 if start>end
                    // because all elements are positive
                    // start>end only when arr[end]>k i.e,
                    // there is an array element with
                    // value greater than k, so sub-array
                    // sum cannot be less than k.
                    if (sum == 0) { break; }
                }

                if (sum == 0)
                {
                    break;
                }
            }

            return ans;
        }

    }
}

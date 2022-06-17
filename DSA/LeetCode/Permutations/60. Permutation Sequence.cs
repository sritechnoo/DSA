using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Permutations._60_PermutationSequence
{
    /*The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

   By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

   "123"
   "132"
   "213"
   "231"
   "312"
   "321"
   Given n and k, return the kth permutation sequence.



   Example 1:

   Input: n = 3, k = 3
   Output: "213"
   Example 2:

   Input: n = 4, k = 9
   Output: "2314"
   Example 3:

   Input: n = 3, k = 1
   Output: "123"


   Constraints:

   1 <= n <= 9
   1 <= k <= n!*/

    /*
     * N=4 and k=9  means k-1th index ==>  9-1 = 8th Index
     * 
     * 
     *  0th Bucket
     *  Each Bucket Size = fact(N-1) ==> fact(4-1) = fact(3) = 6
     *  0 => 1 234
     *  1 => 1 243
     *  2 => 1 324
     *  3 => 1 342
     *  4 => 1 432      
     *  5 => 1 432
     *  
     *  
     *  1th Bucket
     *  Each Bucket Size = 6
     *  6 => 2 134
     *  7 => 2 143
     *  8 => 2 314
     *  9 => 2 341
     *  10 => 2 413
     *  11 => 2 431
     *  
     *  
     *  3th Bucket
     *  Each Bucket Size = 6
     *  12 => 3 124
     *  13 => 3 142
     *  14 => 3 214
     *  15 => 3 241
     *  16 => 3 412
     *  17 => 3 421
     *  
     */

    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            /*Factorial Array*/
            int[] dpFactorial = new int[n + 1];
            dpFactorial[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                dpFactorial[i] = i * dpFactorial[i - 1];
            }

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }


            int kIndex = k - 1;

            string ans = "";
            while (numbers.Count > 0)
            {
                int bucketSize = dpFactorial[numbers.Count - 1];
                int bucketIndex = kIndex / bucketSize;

                int currentNumber = numbers[bucketIndex];
                ans = ans + currentNumber.ToString();

                numbers.RemoveAt(bucketIndex);
                kIndex = kIndex % bucketSize;
            }
            return ans;
        }
    }
}

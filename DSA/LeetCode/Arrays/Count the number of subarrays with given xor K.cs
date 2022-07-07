using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.Count_the_number_of_subarrays_with_given_xor_K
{
    public class Solution
    {
        public int Solve(int[] A, int B)
        {
            return BruteForce(A, B);
        }

        private int BruteForce(int[] nums, int B)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int currXor = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    currXor ^= nums[j];

                    if (currXor == B) { count++; }
                }
            }
            return count;
        }

        /*Prefix xor and map

        Intuition: The main idea is to observe the prefix xor of the array. Prefix Xor is just another array, where each index contains XOR of all elements of the original array starting from index 0 up to that index. In other words
        prefix_xor[i] = XOR(a[0], a[1], a[2],……,a[I])

        Once we have made the prefix xor array, we observe a fact:

        P = xor(a[0], a[1], a[2],……, a[q], a[q+1],….., a[p])
        Q = xor(a[0], a[1], a[2],……, a[q])

        Therefore,
        P^Q = xor(a[q+1],….., a[p]) = M                                
        So, now we understand that from the prefix xor array when we XOR two elements at different indices we get the xor of the elements (in the original array) that were between those indices.
        Let’s say we did XOR(P, B) and we got Q (B is the integer given in question). What does this mean?
        This means that the subarray between q and p is having xor = B. To understand this we just use simple equations:
        P^B = Q
        => P^B^P = Q^P
        => B = Q^P  

        And we already know by fact 1 that Q^P will give xor of all elements between q and p. Therefore, the subarray between q and p has xor = B.
        Suppose we did XOR(P, B) and we got Q (B is the integer given in question). But there is more than one Q before p.

        In this case, there are two subarrays that have XOR = B. Subarrays between q1 to p and q2 to p. 

        IMP NOTE: although we talk about prefix xor “array”, it should be noted that at a time we need only one element of this array. Hence, we can just use a variable to maintain the prefix xor. 

        Approach: We need to traverse the array while we maintain variables for current_perfix_xor, counter, and also a map to keep track of visited xors. 
        This map will maintain the frequency count of all previous visited current_prefix_xor values.
        If for any index current_prefix_xor is equal to B, we increment the counter. 
        If for any index we find that Z is present in the visited map, we increment the counter by visited[Z] (Z=current_prefi_xor^B). 
        At every index, we insert the current_prefix_xor into the visited map with its frequency.*/
        private int PrefixXorDictApproach(int[] nums, int B)
        {
            int count = 0;

            Dictionary<int, int> prefixXorCountMap = new Dictionary<int, int>();
            int prefixXor = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                prefixXor ^= nums[i];

                if (prefixXor == B) { count++; }

                if (prefixXorCountMap.ContainsKey(prefixXor ^ B))
                {
                    count += prefixXorCountMap[prefixXor ^ B];
                }

                if (prefixXorCountMap.ContainsKey(prefixXor))
                {
                    prefixXorCountMap[prefixXor] = prefixXorCountMap[prefixXor] + 1;
                }
                else
                {
                    prefixXorCountMap.Add(prefixXor, 1);
                }

            }
            return count;
        }
    }
}

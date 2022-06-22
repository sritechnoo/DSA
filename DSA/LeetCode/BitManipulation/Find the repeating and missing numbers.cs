using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.BitManipulation.Find_the_repeating_and_missing_numbers
{
    /*
    Example 1:
    Input Format:  array[] = {3,1,2,5,3}

    Result: {3,4)

    Explanation: A = 3 , B = 4 
    Since 3 is appearing twice and 4 is missing

    Example 2:

    Input Format: array[] = {3,1,2,5,4,6,7,5}

    Result: {5,8)

    Explanation: A = 5 , B = 8 
    Since 5 is appearing twice and 8 is missing
    */
    public class Solution
    {
        public int[] Find_missing_repeating_BitManipulation(int[] arr, int n)
        {
            /* Will hold xor of all elements
           and numbers from 1 to n  */
            int xorResult;

            /* Will have only single set bit of xor1 */
            int set_bit_no;


            int x, y;
            x = 0;
            y = 0;

            xorResult = arr[0];

            /* Get the xor of all array elements  */
            for (int i = 1; i < n; i++)
                xorResult = xorResult ^ arr[i];

            /* XOR the previous result with numbers from
           1 to n*/
            for (int i = 1; i <= n; i++)
                xorResult = xorResult ^ i;

            /* Get the rightmost set bit in set_bit_no */
            set_bit_no = xorResult & ~(xorResult - 1);

            /* Now divide elements into two sets by comparing
        rightmost set bit of xor1 with the bit at the same
        position in each element. Also, get XORs of two
        sets. The two XORs are the output elements. The
        following two for loops serve the purpose */
            for (int i = 0; i < n; i++)
            {
                if ((arr[i] & set_bit_no) != 0)
                    /* arr[i] belongs to first set */
                    x = x ^ arr[i];

                else
                    /* arr[i] belongs to second set*/
                    y = y ^ arr[i];
            }
            for (int i = 1; i <= n; i++)
            {
                if ((i & set_bit_no) != 0)
                    /* i belongs to first set */
                    x = x ^ i;

                else
                    /* i belongs to second set*/
                    y = y ^ i;
            }

            // at last do a linear check which amont x and y is missing or repeating 

            /* *x and *y hold the desired output elements */
            return new int[] { x, y };
        }



        public int[] FindMissing_Repeating_XOR(int[] nums)
        {
            int missing_xor_repeating = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                missing_xor_repeating = missing_xor_repeating ^ nums[i];
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                missing_xor_repeating = missing_xor_repeating ^ nums[i];
            }

            int set_bit_no = FindNumberTheLeastSignificantBitThatIsSet(missing_xor_repeating);

            int set1 = 0;
            int set2 = 0;

            /*Dividing into two set based on set_bit_no set value*/
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & set_bit_no) != 0)
                    /* arr[i] belongs to first set */
                    set1 = set1 ^ nums[i];

                else
                    /* arr[i] belongs to second set*/
                    set2 = set2 ^ nums[i];
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                if ((i & set_bit_no) != 0)
                    /* i belongs to first set */
                    set1 = set1 ^ i;

                else
                    /* i belongs to second set*/
                    set2 = set2 ^ i;
            }
            return new int[] { set1, set2 };
        }

        private int FindNumberTheLeastSignificantBitThatIsSet(int num)
        {
            for (int i = 1; i <= 32; i++)
            {
                if ((num & (1 << (i - 1))) > 0) { return i; }
            }
            return -1;
        }
    }
}

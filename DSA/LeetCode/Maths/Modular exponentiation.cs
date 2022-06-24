using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Maths.Modular_Exponentiation
{
    /*Given three numbers a, b and c, we need to find (ab) % c
    Now why do “% c” after exponentiation, because ab will be really large even for relatively small values of a, b and that is a problem because the data type of the language that we try to code the problem, will most probably not let us store such a large number.
    Examples: 


    Input : a = 2312 b = 3434 c = 6789
    Output : 6343

    Input : a = -3 b = 5 c = 89 
    Output : 24

    Auxiliary Space: O(1)

    Recommended: Please try your approach on {IDE} first, before moving on to the solution.

    The idea is based on below properties.
    
    Property 1: 
    (m * n) % p has a very interesting property: 
   
    (m * n) % p =((m % p) * (n % p)) % p
   
    Property 2: 
    if b is even: 
         (a ^ b) % c = ((a ^ b/2) * (a ^ b/2)) % c 
    if b is odd: 
         (a ^ b) % c = (a * (a ^( b-1))%c
    
    Property 3: 
    If we have to return the mod of a negative number x whose absolute value is less than y: 
    then (x + y) % y will do the trick
    
    
    Note: 
    Also as the product of (a ^ b/2) * (a ^ b/2) and a * (a ^( b-1) may cause overflow, hence we must be careful about those scenarios */

    public class Solution
    {
        public int ExponentPower_ForLoop(int a, int b)
        {
            // we need to compute a^b            
            int answer = 1;

            // the for loop iterates b times
            for (int i = 1; i <= b; i++)
            {
                answer = answer * a;
            }

            return answer;
        }

        public int ExponentPower_Recursive(int a, int b)
        {
            //TC - O(b)
            //
            // base case, when b = 0
            if (b == 0)
            {
                // any number raised to 0 is always 1
                return 1;
            }

            //else we recurse for b-1 after multiplying the answer with a and return the answer

            // now answer stores a^b
            int answer = a * ExponentPower_Recursive(a, b - 1);

            return answer;
        }

        public int ExponentPower_RecursiveOptimized(int a, int b)
        {
            /*
             a^b = a^c ∗ a^d ,if  b=c+d

             (a^b)^c = a^(b∗c)
             */

            //TC - O(log(b))

            // base case, when b = 0

            if (b == 0) { return 1; }


            if (b % 2 == 1)
            {
                int either = a * ExponentPower_RecursiveOptimized(a, (b - 1));
                int or = a
                    * ExponentPower_RecursiveOptimized(a, (b - 1) / 2)
                    * ExponentPower_RecursiveOptimized(a, (b - 1) / 2);

                return either * or;
            }
            else
            {
                return ExponentPower_RecursiveOptimized(a, b / 2)
                    * ExponentPower_RecursiveOptimized(a, b / 2);
            }
        }

        public int ModularExponentian_Recursive(int m, int n, int p)
        {
            /*
               (m * n) % p has a very interesting property: 
   
               (m * n) % p = ((m % p) * (n % p)) % p
             */

            if (n == 0) { return 1; }


            if (n % 2 == 1)
            {
                return (m
                        *
                        ModularExponentian_Recursive(m, n - 1, p)) % p;
            }
            else
            {
                return (ModularExponentian_Recursive(m, n / 2, p)
                        *
                        ModularExponentian_Recursive(m, n / 2, p)) % p;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.PrimeNumbers
{
    class Factors
    {
        /*
        * 36
        * i * n/i
        * 1 * 36
        * 2 * 18
        * 3 * 12
        * 4 * 9
        * 6 * 6
        * 9 * 4
        * 12 * 3
        * 18 * 2
        * 36 * 1
        */
        void PrintSumOfFactors(int number)
        {
            int sum = 0;
            for (int i = 1; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    sum += i; /* for First Factor: i + n/i */

                    /*if first and second factor is not same then add it twise*/
                    if (number / i != i)
                    {
                        sum += (number / i);  /* for Second Factor:  n/i + i */
                    }
                }
            }
        }

        /*
         * a*b*c = Number
         * a != -1, b!= -1, c != -1
         * c = number/(a*b)
         * 
         * number = 64;
         * a = 2 - smallest factor of 64
         * number = 64/2 = 32
         * 2 is smallest factor of 32, but 2 is already assigned for a
         * b = 4 so next smallest factor of 32 is 4
         * c = 64/(a*b)     
        */
        void FindABC(int number)
        {
            int a = 1;
            int b = 1;
            int c = 1;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    a = i;
                    break;
                }
            }

            number = number / a;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    if (i != a)
                    {
                        b = Math.Min(b, i);
                    }

                    if ((number / i) != i)
                    {
                        if ((number / i) != a)
                        {
                            b = Math.Min(b, number / i);
                        }
                    }
                }
            }

            c = number / b;

            if (a != -1 && b != -1 && c != -1)
            {
                Console.WriteLine("Yes");
            }

        }
    }

}

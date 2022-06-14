using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.PrimeNumbers
{
    /*
     * Time Taken for 10^8 Operations = 1 Seconds
     * 
     * Two is only even prime numbers
     * Every prime no can be written as 6b+1 or 6n-1 except 2 and 3, where n is a natural number.
     * 2 and 3 are consecutive prime numbers
     * 
     * Wilson's Therom (p-1)!(factorial) = (p-1) mod p
     * p=5  => (5-1)! = (5-1)mod5 => 4=4  
     * 
     * Divisible by 1 and itself and number of factors is 2 
     */
    public class PrimeNo1
    {
        bool IsPrimeNumber1(int number)
        {
            int count = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }
            return count == 2;
        }

        bool IsPrimeNumber2(int number)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }
            return count == 2;
        }

        bool IsPrimeNumber3(int number)
        {
            int count = 0;
            for (int i = 1; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }
            return count == 2;
        }


        bool[] GetSieveArray(int N = 10 ^ 6)
        {
            bool[] sieveArray = new bool[N + 1];
            Array.Fill(sieveArray, true);

            for (int i = 2; i <= N; i++)
            {
                if (sieveArray[i] == true)
                {
                    for (int j = 2 * i; j <= N; j += i)
                    {
                        sieveArray[j] = false;
                    }
                }
            }
            return sieveArray;
        }

        public static void SieveOfEratosthenes(int n)
        {

            // Create a boolean array
            // "prime[0..n]" and
            // initialize all entries
            // it as true. A value in
            // prime[i] will finally be
            // false if i is Not a
            // prime, else true.

            bool[] prime = new bool[n + 1];

            for (int i = 0; i <= n; i++)
                prime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {
                // If prime[p] is not changed,
                // then it is a prime
                if (prime[p] == true)
                {
                    // Update all multiples of p
                    for (int i = p * p; i <= n; i += p)
                        prime[i] = false;
                }
            }

            // Print all prime numbers
            for (int i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                    Console.Write(i + " ");
            }
        }


    }

    public class GFG
    {

        static int[] Primes = new int[500001];

        static void SieveOfEratosthenes(int n)
        {
            Primes[0] = 1;
            for (int i = 3; i * i <= n; i += 2)
            {
                if (Primes[i / 2] == 0)
                {
                    for (int j = 3 * i; j <= n; j += 2 * i)
                        Primes[j / 2] = 1;
                }
            }
        }

        // Driver Code
        public static void Mains(String[] args)
        {

            int n = 100;
            SieveOfEratosthenes(n);
            for (int i = 1; i <= n; i++)
            {
                if (i == 2)
                    Console.Write(i + " ");
                else if (i % 2 == 1 && Primes[i / 2] == 0)
                    Console.Write(i + " ");
            }
        }
    }
}

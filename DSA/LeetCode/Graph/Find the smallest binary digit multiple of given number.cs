using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph
{
    using System;
    using System.Collections.Generic;
    class Find_the_smallest_binary_digit_multiple_of_given_number
    {
        // Method return t % N,
        // where t is stored as
        // a string
        public static int mod(String t, int N)
        {
            int r = 0;
            for (int i = 0; i < t.Length; i++)
            {
                r = r * 10 + (t[i] - '0');
                r %= N;
            }
            return r;
        }

        // method returns smallest
        // multiple which has
        // binary digits
        public static String getMinimumMultipleOfBinaryDigit(int N)
        {
            Queue<String> q = new Queue<String>();
            HashSet<int> visit = new HashSet<int>();

            String t = "1";

            // In starting push 1
            // into our queue
            q.Enqueue(t);

            // loop until queue
            // is not empty
            while (q.Count != 0)
            {
                // Take the front number
                // from queue.
                t = q.Dequeue();

                // Find remainder of t
                // with respect to N.
                int rem = mod(t, N);

                // If remainder is 0 then
                // we have found our solution
                if (rem == 0)
                    return t;

                // If this remainder is not
                // previously seen, then push
                // t0 and t1 in our queue
                else if (!visit.Contains(rem))
                {
                    visit.Add(rem);
                    q.Enqueue(t + "0");
                    q.Enqueue(t + "1");
                }
            }
            return "";
        }

        // Driver code
        public static void Mains(String[] args)
        {
            int N = 12;
            Console.WriteLine(getMinimumMultipleOfBinaryDigit(N));
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.Arrays.Count_Inversions_in_an_array
{
    /*Inversion Count for an array indicates – how far (or close) the array is from being sorted. If the array is already sorted, then the inversion count is 0, but if the array is sorted in the reverse order, the inversion count is the maximum. 

    Formally speaking, two elements a[i] and a[j] form an inversion if a[i] > a[j] and i < j

    Example: 

    Input: arr[] = {8, 4, 2, 1}
    Output: 6

    Explanation: Given array has six inversions:
    (8, 4), (4, 2), (8, 2), (8, 1), (4, 1), (2, 1).


    Input: arr[] = {3, 1, 2}
    Output: 2

    Explanation: Given array has two inversions:
    (3, 1), (3, 2) */

   public class Solution
    {
        public int GetInvCount(int[] arr, int n)
        {
            int pairsCount = 0;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j]) { pairsCount++; }

            return pairsCount;
        }
    }

    public class Test
    {

        /* This method sorts the input array and returns the
           number of inversions in the array */
        static int mergeSort(int[] arr, int array_size)
        {
            int[] temp = new int[array_size];
            return _mergeSort(arr, temp, 0, array_size - 1);
        }

        /* An auxiliary recursive method that sorts the input
          array and returns the number of inversions in the
          array. */
        static int _mergeSort(int[] arr, int[] temp, int left,
                              int right)
        {
            int mid, inv_count = 0;
            if (right > left)
            {
                /* Divide the array into two parts and call
               _mergeSortAndCountInv() for each of the parts */
                mid = (right + left) / 2;

                /* Inversion count will be the sum of inversions
              in left-part, right-part
              and number of inversions in merging */
                inv_count += _mergeSort(arr, temp, left, mid);
                inv_count
                    += _mergeSort(arr, temp, mid + 1, right);

                /*Merge the two parts*/
                inv_count
                    += merge(arr, temp, left, mid + 1, right);
            }
            return inv_count;
        }

        /* This method merges two sorted arrays and returns
           inversion count in the arrays.*/
        static int merge(int[] arr, int[] temp, int left,
                         int mid, int right)
        {
            int i, j, k;
            int inv_count = 0;

            i = left; /* i is index for left subarray*/
            j = mid; /* j is index for right subarray*/
            k = left; /* k is index for resultant merged
                     subarray*/
            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];

                    /*this is tricky -- see above
                     * explanation/diagram for merge()*/
                    inv_count = inv_count + (mid - i);
                }
            }

            /* Copy the remaining elements of left subarray
           (if there are any) to temp*/
            while (i <= mid - 1)
                temp[k++] = arr[i++];

            /* Copy the remaining elements of right subarray
           (if there are any) to temp*/
            while (j <= right)
                temp[k++] = arr[j++];

            /*Copy back the merged elements to original array*/
            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return inv_count;
        }


    }
}
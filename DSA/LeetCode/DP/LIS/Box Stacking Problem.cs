using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LeetCode.DP.LIS.Box_Stacking_Problem
{
    /*You are given a set of n types of rectangular 3-D boxes, where the i^th box has height h(i), width w(i) and depth d(i) (all real numbers). You want to create a stack of boxes which is as tall as possible, but you can only stack a box on top of another box if the dimensions of the 2-D base of the lower box are each strictly larger than those of the 2-D base of the higher box. Of course, you can rotate a box so that any side functions as its base. It is also allowable to use multiple instances of the same type of box. 
    Source: http://people.csail.mit.edu/bdean/6.046/dp/. The link also has a video for an explanation of the solution.



    Recommended Practice
    Box Stacking
    Try It!

    The Box Stacking problem is a variation of LIS problem. We need to build a maximum height stack. 
    Following are the key points to note in the problem statement: 
    1) A box can be placed on top of another box only if both width and depth of the upper placed box are smaller than width and depth of the lower box respectively. 
    2) We can rotate boxes such that width is smaller than depth. For example, if there is a box with dimensions {1x2x3} where 1 is height, 2×3 is base, then there can be three possibilities, {1x2x3}, {2x1x3} and {3x1x2} 
    3) We can use multiple instances of boxes. What it means is, we can have two different rotations of a box as part of our maximum height stack.
    Following is the solution based on DP solution of LIS problem.
    Advertisement

    Method 1 : dynamic programming using tabulation

    1) Generate all 3 rotations of all boxes. The size of rotation array becomes 3 times the size of the original array. For simplicity, we consider width as always smaller than or equal to depth. 
    2) Sort the above generated 3n boxes in decreasing order of base area.
    3) After sorting the boxes, the problem is same as LIS with following optimal substructure property. 
    MSH(i) = Maximum possible Stack Height with box i at top of stack 
    MSH(i) = { Max ( MSH(j) ) + height(i) } where j < i and width(j) > width(i) and depth(j) > depth(i). 
    If there is no such j then MSH(i) = height(i)
    4) To get overall maximum height, we return max(MSH(i)) where 0 < i < n*/

    /*https://medium.com/@dhruvihl369/box-stacking-problem-using-dynamic-programming-a246128dcf25*/
    public class GFG
    {

        class Box : IComparable<Box>
        {

            public int h, w, d, area;

            public Box(int h, int w, int d)
            {
                this.h = h;
                this.w = w;
                this.d = d;
            }

            public int CompareTo(Box other)
            {
                return other.area - this.area;
            }
        }

        static int maxStackHeight(Box[] arr, int n)
        {

            Box[] rot = new Box[n * 3];

            /* New Array of boxes is created -
            considering all 3 possible rotations,
            with width always greater than equal
            to width */
            for (int i = 0; i < n; i++)
            {
                Box box = arr[i];

                /* Original Box*/
                rot[3 * i] = new Box(box.h, Math.Max(box.w, box.d), Math.Min(box.w, box.d));

                /* First rotation of box*/
                rot[3 * i + 1] = new Box(box.w, Math.Max(box.h, box.d), Math.Min(box.h, box.d));

                /* Second rotation of box*/
                rot[3 * i + 2] = new Box(box.d, Math.Max(box.w, box.h), Math.Min(box.w, box.h));
            }

            /* Calculating base area of
            each of the boxes.*/
            for (int i = 0; i < rot.Length; i++)
                rot[i].area = rot[i].w * rot[i].d;

            /* Sorting the Boxes on the bases
            of Area in non Increasing order.*/
            Array.Sort(rot);

            int count = 3 * n;

            /* Initialize msh values for all
            msh[i] --> Maximum possible Stack Height with box i on top */
            int[] msh = new int[count];
            for (int i = 0; i < count; i++) { msh[i] = rot[i].h; }

            /* Computing optimized msh[] values in bottom up manner */


            for (int i = 1; i < n; i++)
                for (int j = 0; j < i; j++)
                    if (rot[i].w < rot[j].w && rot[i].d < rot[j].d
                        && msh[i] < msh[j] + rot[i].h
                       )
                    {
                        msh[i] = msh[j] + rot[i].h;
                    }


            /* Pick maximum of all msh values */
            int max = -1;
            for (int i = 0; i < n; i++)
                if (max < msh[i])
                    max = msh[i];

            return max;
        }

        /* Driver program to test above function */
        public void Main(String[] args)
        {

            Box[] arr = new Box[4];
            arr[0] = new Box(4, 6, 7);
            arr[1] = new Box(1, 2, 3);
            arr[2] = new Box(4, 5, 6);
            arr[3] = new Box(10, 12, 32);


        }
    }
}

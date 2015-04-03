using System;
using System.Linq;

namespace MySort
{
    /**
    * Median of Two Sorted Arrays 
    **/
    public class FindMedianSortedArrays
    {
        public double FindMedianSortedArrays(int[] A, int[] B)
        {
            int m = A.Length, n = B.Length;
            int total = m + n;
            if ((total & 0x1) == 1)
                return FindKth(A, m, B, n, total / 2 + 1);
            else
                return (FindKth(A, m, B, n, total / 2)
                        + FindKth(A, m, B, n, total / 2 + 1)) / 2.0;

        }

        private int FindKth(int[] A, int m, int[] B, int n, int k)
        {
            if (m > n) return FindKth(B, n, A, m, k);
            if (m == 0) return B[k - 1];
            if (k == 1) return Math.Min(A[0], B[0]);

            int ia = Math.Min(k / 2, m);
            int ib = k - ia;

            if (A[ia - 1] < B[ib - 1])
                return FindKth(A.Skip(ia).ToArray(), m - ia, B, n, k - ia);
            else if (A[ia - 1] > B[ib - 1])
                return FindKth(A, m, B.Skip(ib).ToArray(), n - ib, k - ib);
            else
                return A[ia - 1];
        }


        void main()
        {

            int[] ar1 = { 1, 12, 15, 26, 38 };
            int[] ar2 = { 2, 13, 17, 30, 45, 50 };

            int[] ar11 = { 1, 12, 15, 26, 38 };
            int[] ar21 = { 2, 13, 17, 30, 45 };

            int[] a10 = { 1, 2, 5, 6, 8, 9, 10 };
            int[] a20 = { 13, 17, 30, 45, 50 };

            int[] a12 = { 1, 2, 5, 6, 8 };
            int[] a22 = { 11, 13, 17, 30, 45, 50 };

            int[] b1 = { 1 };
            int[] b2 = { 2, 3, 4 };

            var s = new FindMedianSortedArrays();
            Console.WriteLine("Median is 17 = {0}", s.FindMedianSortedArrays(ar1, ar2));
            Console.WriteLine("Median is 16 = {0}", s.FindMedianSortedArrays(ar11, ar21));
            Console.WriteLine("Median is 9.5 = {0}", s.FindMedianSortedArrays(a10, a20));
            Console.WriteLine("Median is 11 = {0}", s.FindMedianSortedArrays(a12, a22));
            Console.WriteLine("Median is 2.5 = {0}", s.FindMedianSortedArrays(b1, b2));
            Console.ReadKey();
        }
    }
}

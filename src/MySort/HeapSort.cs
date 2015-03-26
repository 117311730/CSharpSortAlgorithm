using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class HeapSort
    {
        /**
 * Heapsort 
 * @param array array to be sorted
 * @param ascending @true if the array should be sorted in ascending order, @false descending order
 */
        public static void Heapsort(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                RepairTop(array, array.Length - 1, i);
            }
            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(array, 0, i);
                RepairTop(array, i - 1, 0);
            }
        }

        /**
         * Move the top of the heap to the correct place
         * @param array array to be sorted
         * @param bottom last index that can be touched
         * @param topIndex index of the top of the heap
         * @param order 1 == ascending order, -1 descending order
         */
        private static void RepairTop(int[] array, int bottom, int topIndex)
        {
            int tmp = array[topIndex];
            int succ = topIndex * 2 + 1;
            if (succ < bottom && array[succ] > array[succ + 1]) succ++;

            while (succ <= bottom && tmp > array[succ])
            {
                array[topIndex] = array[succ];
                topIndex = succ;
                succ = succ * 2 + 1;
                if (succ < bottom && array[succ] > array[succ + 1]) succ++;
            }
            array[topIndex] = tmp;
        }

        /**
         * Swaps two elements of the heap
         * @param array array
         * @param left index of the first element
         * @param right index of the second element
         */
        private static void Swap(int[] array, int left, int right)
        {
            int tmp = array[right];
            array[right] = array[left];
            array[left] = tmp;
        }
    }




    public class HeapSortClass
    {
        public static void HeapSort<T>(T[] array)
        {
            HeapSort<T>(array, 0, array.Length, Comparer<T>.Default);
        }

        public static void HeapSort<T>(T[] array, int offset, int length, IComparer<T> comparer)
        {
            HeapSort<T>(array, offset, length, comparer.Compare);
        }

        public static void HeapSort<T>(T[] array, int offset, int length, Comparison<T> comparison)
        {
            // build binary heap from all items
            for (int i = 0; i < length; i++)
            {
                int index = i;
                T item = array[offset + i]; // use next item

                // and move it on top, if greater than parent
                while (index > 0 &&
                    comparison(array[offset + (index - 1) / 2], item) < 0)
                {
                    int top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }

            for (int i = length - 1; i > 0; i--)
            {
                // delete max and place it as last
                T last = array[offset + i];
                array[offset + i] = array[offset];

                int index = 0;
                // the last one positioned in the heap
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;

                    if (right < i && comparison(array[offset + left], array[offset + right]) < 0)
                    {
                        if (comparison(last, array[offset + right]) > 0) break;

                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (comparison(last, array[offset + left]) > 0) break;

                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
        }

        static void Main()
        {
            // usage
            byte[] r = { 5, 4, 1, 2 };
            HeapSort(r);

            string[] s = { "-", "D", "a", "33" };
            HeapSort(s, 0, s.Length, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}

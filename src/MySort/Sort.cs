using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    public static class Sort
    {
        public static void Bubble(this int[] arr)
        {
            int i, j;
            int l = arr.Length;
            for (i = 0; i < l; i++)
            {
                for (j = l - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static void Selection(this int[] arr)
        {
            int i, j;
            int l = arr.Length;
            for (i = 0; i < l; i++)
            {
                int min = i;
                for (j = i + 1; j <= l - 1; j++)
                {
                    if (arr[min] > arr[j]) min = j;
                }
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void Insertion(this int[] arr)
        {
            int i;
            for (i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }
            }
            for (i = 2; i < arr.Length; i++)
            {
                int j = i;
                int temp = arr[i];
                while (temp < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }

    }
}

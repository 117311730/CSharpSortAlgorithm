using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class MergeSort
    {
        public static List<int> sort(List<int> lst)
        {
            if (lst.Count <= 1)
            {
                return lst;
            }
            int mid = lst.Count / 2;
            List<int> left = new List<int>();//定义左侧List
            List<int> right = new List<int>();//定义右侧List

            //以下兩個循環把lst分為左右兩個List
            for (int i = 0; i < mid; i++)
            {
                left.Add(lst[i]);
            }
            for (int j = mid; j < lst.Count; j++)
            {
                right.Add(lst[j]);
            }
            left = sort(left);
            right = sort(right);
            return merge(left, right);
        }
        /// <summary>
        /// 合併兩個已經排好序的List
        /// </summary>
        /// <param name="left">左側List</param>
        /// <param name="right">右側List</param>
        /// <returns></returns>
        static List<int> merge(List<int> left, List<int> right)
        {
            List<int> temp = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                {
                    temp.Add(left[i]);
                }
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                {
                    temp.Add(right[i]);
                }
            }
            return temp;
        }
    }
}

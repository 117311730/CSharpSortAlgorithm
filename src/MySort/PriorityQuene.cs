using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace MySort
{
    public class PriorityQueue<T>
    {
        /// <summary>
        /// 定义一个数组来存放节点
        /// </summary>
        private List<HeapNode> nodeList = new List<HeapNode>();

        #region 堆节点定义
        /// <summary>
        /// 堆节点定义
        /// </summary>
        public class HeapNode
        {
            /// <summary>
            /// 实体数据
            /// </summary>
            public T t { get; set; }

            /// <summary>
            /// 优先级别 1-10个级别 (优先级别递增)
            /// </summary>
            public int level { get; set; }

            public HeapNode(T t, int level)
            {
                this.t = t;
                this.level = level;
            }

            public HeapNode() { }
        }
        #endregion

        #region  添加操作
        /// <summary>
        /// 添加操作
        /// </summary>
        public void Eequeue(T t, int level = 1)
        {
            //将当前节点追加到堆尾
            nodeList.Add(new HeapNode(t, level));

            //如果只有一个节点，则不需要进行筛操作
            if (nodeList.Count == 1)
                return;

            //获取最后一个非叶子节点
            int parent = nodeList.Count / 2 - 1;

            //堆调整
            UpHeapAdjust(nodeList, parent);
        }
        #endregion

        #region 对堆进行上滤操作，使得满足堆性质
        /// <summary>
        /// 对堆进行上滤操作，使得满足堆性质
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="index">非叶子节点的之后指针（这里要注意：我们
        /// 的筛操作时针对非叶节点的）
        /// </param>
        public void UpHeapAdjust(List<HeapNode> nodeList, int parent)
        {
            while (parent >= 0)
            {
                //当前index节点的左孩子
                var left = 2 * parent + 1;

                //当前index节点的右孩子
                var right = left + 1;

                //parent子节点中最大的孩子节点，方便于parent进行比较
                //默认为left节点
                var min = left;

                //判断当前节点是否有右孩子
                if (right < nodeList.Count)
                {
                    //判断parent要比较的最大子节点
                    min = nodeList[left].level < nodeList[right].level ? left : right;
                }

                //如果parent节点大于它的某个子节点的话，此时筛操作
                if (nodeList[parent].level > nodeList[min].level)
                {
                    //子节点和父节点进行交换操作
                    var temp = nodeList[parent];
                    nodeList[parent] = nodeList[min];
                    nodeList[min] = temp;

                    //继续进行更上一层的过滤
                    parent = (int)Math.Ceiling(parent / 2d) - 1;
                }
                else
                {
                    break;
                }
            }
        }
        #endregion

        #region 优先队列的出队操作
        /// <summary>
        /// 优先队列的出队操作
        /// </summary>
        /// <returns></returns>
        public HeapNode Dequeue()
        {
            if (nodeList.Count == 0)
                return null;

            //出队列操作，弹出数据头元素
            var pop = nodeList[0];

            //用尾元素填充头元素
            nodeList[0] = nodeList[nodeList.Count - 1];

            //删除尾节点
            nodeList.RemoveAt(nodeList.Count - 1);

            //然后从根节点下滤堆
            DownHeapAdjust(nodeList, 0);

            return pop;
        }
        #endregion

        #region  对堆进行下滤操作，使得满足堆性质
        /// <summary>
        /// 对堆进行下滤操作，使得满足堆性质
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="index">非叶子节点的之后指针（这里要注意：我们
        /// 的筛操作时针对非叶节点的）
        /// </param>
        public void DownHeapAdjust(List<HeapNode> nodeList, int parent)
        {
            while (2 * parent + 1 < nodeList.Count)
            {
                //当前index节点的左孩子
                var left = 2 * parent + 1;

                //当前index节点的右孩子
                var right = left + 1;

                //parent子节点中最大的孩子节点，方便于parent进行比较
                //默认为left节点
                var min = left;

                //判断当前节点是否有右孩子
                if (right < nodeList.Count)
                {
                    //判断parent要比较的最大子节点
                    min = nodeList[left].level < nodeList[right].level ? left : right;
                }

                //如果parent节点小于它的某个子节点的话，此时筛操作
                if (nodeList[parent].level > nodeList[min].level)
                {
                    //子节点和父节点进行交换操作
                    var temp = nodeList[parent];
                    nodeList[parent] = nodeList[min];
                    nodeList[min] = temp;

                    //继续进行更下一层的过滤
                    parent = min;
                }
                else
                {
                    break;
                }
            }
        }
        #endregion

        #region 获取元素并下降到指定的level级别
        /// <summary>
        /// 获取元素并下降到指定的level级别
        /// </summary>
        /// <returns></returns>
        public HeapNode GetAndDownPriority(int level)
        {
            if (nodeList.Count == 0)
                return null;

            //获取头元素
            var pop = nodeList[0];

            //设置指定优先级（如果为 MinValue 则为 -- 操作）
            nodeList[0].level = level == int.MinValue ? --nodeList[0].level : level;

            //下滤堆
            DownHeapAdjust(nodeList, 0);

            return nodeList[0];
        }
        #endregion

        #region 获取元素并下降优先级
        /// <summary>
        /// 获取元素并下降优先级
        /// </summary>
        /// <returns></returns>
        public HeapNode GetAndDownPriority()
        {
            //下降一个优先级
            return GetAndDownPriority(int.MinValue);
        }
        #endregion

        #region 返回当前优先队列中的元素个数
        /// <summary>
        /// 返回当前优先队列中的元素个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return nodeList.Count;
        }
        #endregion
    }
}
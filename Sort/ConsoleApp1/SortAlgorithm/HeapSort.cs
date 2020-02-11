using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【选择排序--堆排序】
    /// 堆排序是指利用堆这种数据结构所设计的一种排序算法。
    /// 堆是一个近似完全二叉树的结构，并同时满足堆积的性质：即子结点的键值或索引总是小于（或者大于）它的父节点。
    /// 不稳定  时间复杂度 O(nlogn)  空间复杂度 O(1)
    /// </summary> 
    public class BubbleSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int count = nums.Count;
            //这里元素的索引是从0开始的,所以最后一个非叶子结点array.length/2 - 1
            for (int i = count / 2 - 1; i >= 0; i--)
            {
                AdjustHeap(nums, i, count); // 调整堆
            }

            // 上述逻辑，建堆结束
            // 下面，开始排序逻辑
            for (int j = count - 1; j > 0; j--)
            {
                // 元素交换,作用是去掉大顶堆
                // 把大顶堆的根元素，放到数组的最后；换句话说，就是每一次的堆调整之后，都会有一个元素到达自己的最终位置
                Swap(nums, 0, j);
                // 元素交换之后，毫无疑问，最后一个元素无需再考虑排序问题了。
                // 接下来我们需要排序的，就是已经去掉了部分元素的堆了，这也是为什么此方法放在循环里的原因
                // 而这里，实质上是自上而下，自左向右进行调整的
                AdjustHeap(nums, 0, j);
            }
        }

        /// <summary>
        /// 整个堆排序最关键的地方
        /// </summary>
        /// <param name="nums">待组堆</param>
        /// <param name="rootIndex">起始结点</param>
        private void AdjustHeap(List<int> nums, int rootIndex, int length)
        {
            // 先把当前元素取出来，因为当前元素可能要一直移动
            int rootValue = nums[rootIndex];
            for (int k = 2 * rootIndex + 1; k < length; k = 2 * k + 1)
            {  //2*i+1为左子树i的左子树(因为i是从0开始的),2*k+1为k的左子树
               // 让k先指向子节点中最大的节点
                if (k + 1 < length && nums[k] < nums[k + 1])
                {  //如果有右子树,并且右子树小于左子树
                    k++;
                }
                //如果发现结点(左右子结点)大于根结点，则进行值的交换
                if (nums[k] > rootValue)
                {
                    Swap(nums, k, rootIndex);
                    // 如果子节点更换了，那么，以子节点为根的子树会受到影响,所以，循环对子节点所在的树继续进行判断
                    rootIndex = k;
                }
                else
                {  //不用交换，直接终止循环
                    break;
                }
            }
        }

        private void Swap(List<int> nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}

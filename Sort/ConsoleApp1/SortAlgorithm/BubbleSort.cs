using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【交换排序--冒泡排序】
    /// 在要排序的一组数中，对当前还未排好序的范围内的全部数，自上而下对相邻的两个数依次进行比较和调整，让较大的数往下沉，较小的往上冒。
    /// 即：每当两相邻的数比较后发现它们的排序与排序要求相反时，就将它们互换。
    /// 稳定  时间复杂度 O (n^2)   空间复杂度 O(1)
    /// </summary> 
    public class HeapSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int count = nums.Count;
            for(int i = 0; i < count - 1; i++)
            {
                for(int j = 0; j < count - i - 1; j++)
                {
                    if(nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 冒泡排序的改进
        /// 设置一标志性变量pos,用于记录每趟排序中最后一次进行交换的位置。
        /// 由于pos位置之后的记录均已交换到位,故在进行下一趟排序时只要扫描到pos位置即可。
        /// </summary>
        void Bubble_1(List<int> nums)
        {
            int n = nums.Count;
            int i = n - 1;  //初始时,最后位置保持不变
            while (i > 0)
            {
                int pos = 0; //每趟开始时,无记录交换
                for (int j = 0; j < i; j++)
                    if (nums[j] > nums[j + 1])
                    {
                        pos = j; //记录交换的位置 
                        int tmp = nums[j]; nums[j] = nums[j + 1]; nums[j + 1] = tmp;
                    }
                i = pos; //为下一趟排序作准备
            }
        }

    }
}

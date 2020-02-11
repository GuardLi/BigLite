using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【交换排序--快速排序】
    /// 通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，
    /// 然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
    /// 稳定  时间复杂度 O(nlogn)   空间复杂度 O(nlogn)
    /// </summary> 
    public class QuickSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            DoQuickSort(nums, 0, nums.Count - 1);
        }

        private void DoQuickSort(List<int> nums, int low, int high)
        {
            if (low >= high)
                return;
            /*完成一次单元排序*/
            int index = SortUnit(nums, low, high);
            /*对左边单元进行排序*/
            DoQuickSort(nums, low, index - 1);
            /*对右边单元进行排序*/
            DoQuickSort(nums, index + 1, high);
        }

        private int SortUnit(List<int> nums, int low, int high)
        {
            int key = nums[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (nums[high] >= key && high > low)
                    --high;
                /*比key小的放左边*/
                nums[low] = nums[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (nums[low] <= key && high > low)
                    ++low;
                /*比key大的放右边*/
                nums[high] = nums[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            nums[low] = key;

            return high;
        }

    }
}

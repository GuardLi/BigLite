using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【插入排序--希尔排序】
    /// 希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；
    /// 随着增量逐渐减少，每组包含的关键词越来越多，当增量减至1时，整个文件恰被分成一组，算法便终止。
    /// 不稳定  时间复杂度 O(n^（1.3—2）)  空间复杂度 O(1)
    /// </summary> 
    public class ShellSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int count = nums.Count;
            for (int dk = count / 2; dk >= 1; dk /= 2)
            {
                // 增量为dk时，需要对dk个分组进行直接插入排序。
                for(int groupIndex = 0; groupIndex < dk; groupIndex++) 
                    ShellInsertSort(nums, dk, groupIndex);
            }
        }

        // 使用直接插入排序做分组的排序
        private void ShellInsertSort(List<int> nums, int dk, int groupIndex)
        {
            int count = nums.Count;
            for(int i = groupIndex + dk; i < count; i += dk)
            {
                if(nums[i] < nums[i - dk])
                {
                    int temp = nums[i];
                    int j = i - dk;
                    while(j >= 0 && nums[j] > temp)
                    {
                        nums[j + dk] = nums[j];
                        j -= dk;
                    }
                    nums[j + dk] = temp;
                }
            }
        }
    }
}

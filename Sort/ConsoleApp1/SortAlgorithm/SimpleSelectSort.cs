using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【选择排序--简单选择排序】
    /// 在要排序的一组数中，选出最小（或者最大）的一个数与第1个位置的数交换；然后在剩下的数当中再找最小（或者最大）的与第2个位置的数交换，
    /// 依次类推，直到第n-1个元素（倒数第二个数）和第n个元素（最后一个数）比较为止。
    /// 不稳定  时间复杂度 O (n^2)  空间复杂度 O(1)
    /// </summary> 
    public class SimpleSelectSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int count = nums.Count;
            int minValueIndex = 0;
            for (int i = 0; i < count; i++)
            {
                minValueIndex = i;
                for (int j = i + 1; j < count; j++)
                {
                    if(nums[j] < nums[minValueIndex])
                        minValueIndex = j;
                }

                if(minValueIndex != i)
                {
                    int temp = nums[i];
                    nums[i] = nums[minValueIndex];
                    nums[minValueIndex] = temp;

                }
            }
        }
    }
}

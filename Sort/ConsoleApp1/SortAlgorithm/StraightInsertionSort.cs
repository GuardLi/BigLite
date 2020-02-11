using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【插入排序--直接插入排序】
    /// 将一个记录插入到已排序好的有序表中，从而得到一个新，记录数增1的有序表。
    /// 即：先将序列的第1个记录看成是一个有序的子序列，然后从第2个记录逐个进行插入，直至整个序列有序为止。
    /// 时间复杂度 O(n^2)    空间复杂度 O(1)
    /// </summary> 
    public class StraightInsertionSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int count = nums.Count;
            for(int i = 1; i < count; i++)
            {
                if(nums[i] < nums[i-1])
                {
                    int temp = nums[i];
                    int j = i - 1;
                    while(j >= 0 && nums[j] > temp)
                    {
                        nums[j + 1] = nums[j];
                        j--;
                    }
                    nums[j + 1] = temp;
                }
            }
        }
    }
}

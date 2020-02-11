using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【归并排序】
    /// 归并（Merge）排序法是将两个（或两个以上）有序表合并成一个新的有序表，即把待排序序列分为若干个子序列，
    /// 每个子序列是有序的。然后再把有序子序列合并为整体有序序列。
    /// 稳定  时间复杂度 O(nlogn)   空间复杂度 O(n)
    /// </summary> 
    public class MergeSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            Sort(nums, 0, nums.Count - 1);
        }

        public void Sort(List<int> nums, int f, int e)
        {
            if (f < e)
            {
                int mid = (f + e) / 2;
                Sort(nums, f, mid);
                Sort(nums, mid + 1, e);
                MergeMethod(nums, f, mid, e);
            }
        }
        private void MergeMethod(List<int> nums, int f, int mid, int e)
        {
            int[] t = new int[e - f + 1];
            int m = f, n = mid + 1, k = 0;
            while (n <= e && m <= mid)
            {
                if (nums[m] > nums[n]) t[k++] = nums[n++];
                else t[k++] = nums[m++];
            }
            while (n < e + 1) t[k++] = nums[n++];
            while (m < mid + 1) t[k++] = nums[m++];
            for (k = 0, m = f; m < e + 1; k++, m++) nums[m] = t[k];
        }

    }
}

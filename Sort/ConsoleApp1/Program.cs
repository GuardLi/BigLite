using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            SortBase sortBase;
            //sortBase = new StraightInsertionSort(); // 直接插入排序
            //sortBase = new ShellSort(); // 希尔排序
            //sortBase = new SimpleSelectSort(); // 简单选择排序
            //sortBase = new HeapSort(); // 堆排序
            //sortBase = new BubbleSort(); // 冒泡排序
            //sortBase = new QuickSort(); // 快速排序
            //sortBase = new MergeSort(); // 归并排序
            sortBase = new RadixSort(); // 基数排序

            List<int> nums = new List<int> { 3, 1, 5, 7, 2, 4, 9, 6 };
            sortBase.Sort(nums);
            foreach (int n in nums)
                Console.Write(n + " ");

            Console.ReadLine();
        }
    }
}

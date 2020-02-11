using System.Collections.Generic;

namespace SortAlgorithm
{
    /// <summary>
    /// 【基数排序】
    /// 是将阵列分到有限数量的桶子里。每个桶子再个别排序（有可能再使用别的排序算法或是以递回方式继续使用桶排序进行排序）。
    /// 稳定  O (nlog(r)m)，其中r为所采取的基数，而m为堆数
    /// </summary> 
    public class RadixSort : SortBase
    {
        public override void Sort(List<int> nums)
        {
            int iMaxLength = GetMaxLength(nums);
            DoRadixSort(nums, iMaxLength);
        }

        //排序
        private void DoRadixSort(List<int> nums, int iMaxLength)
        {
            List<int> list = new List<int>(); //存放每次排序后的元素
            List<int>[] listArr = new List<int>[10]; //十个桶
            char currnetChar;//存放当前的字符比如说某个元素123中的2
            string currentItem;//存放当前的元素比如说某个元素123
            for (int i = 0; i < listArr.Length; i++) //给十个桶分配内存初始化。
                listArr[i] = new List<int>();
            for (int i = 0; i < iMaxLength; i++) //一共执行iMaxLength次，iMaxLength是元素的最大位数。
            {
                foreach (int number in nums)//分桶
                {
                    currentItem = number.ToString(); //将当前元素转化成字符串
                    try
                    {
                        currnetChar = currentItem[currentItem.Length - i - 1];   //从个位向高位开始分桶
                    }
                    catch
                    {
                        listArr[0].Add(number);    //如果发生异常，则将该数压入listArr[0]。比如说5是没有十位数的，执行上面的操作肯定会发生越界异常的，这正是期望的行为，我们认为5的十位数是0，所以将它压入listArr[0]的桶里。
                        continue;
                    }
                    switch (currnetChar)//通过currnetChar的值，确定它压人哪个桶中。
                    {
                        case '0':
                            listArr[0].Add(number);
                            break;
                        case '1':
                            listArr[1].Add(number);
                            break;
                        case '2':
                            listArr[2].Add(number);
                            break;
                        case '3':
                            listArr[3].Add(number);
                            break;
                        case '4':
                            listArr[4].Add(number);
                            break;
                        case '5':
                            listArr[5].Add(number);
                            break;
                        case '6':
                            listArr[6].Add(number);
                            break;
                        case '7':
                            listArr[7].Add(number);
                            break;
                        case '8':
                            listArr[8].Add(number);
                            break;
                        case '9':
                            listArr[9].Add(number);
                            break;
                        default:
                            throw new System.Exception("unknowerror");
                    }
                }
                for (int j = 0; j < listArr.Length; j++) //将十个桶里的数据重新排列，压入list
                    for (int k = 0; k < listArr[j].Count; k++)
                    {
                        list.Add(listArr[j][k]);
                        listArr[j].Clear();//清空每个桶
                    }
                nums.Clear(); 
                nums.AddRange(list);
                list.Clear();//清空list
            }
        }
        //得到最大元素的位数
        private static int GetMaxLength(List<int> nums)
        {
            int iMaxNumber = System.Int32.MinValue;
            foreach (int i in nums)//遍历得到最大值
            {
                if (i > iMaxNumber)
                    iMaxNumber = i;
            }
            return iMaxNumber.ToString().Length;//这样获得最大元素的位数是不是有点投机取巧了...
        }

    }
}

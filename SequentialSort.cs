using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    public class SequentialSort : BaseSorter
    {
        public override void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);
                Merge(array, leftIndex, middleIndex, rightIndex);
            }
        }
    }
}

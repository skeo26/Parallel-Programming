using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    public class CorrectParallelSorter : BaseSorter
    {

        public override void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            const int threshold = 65000;

            if (leftIndex < rightIndex)
            {
                if ((rightIndex - leftIndex) < threshold)
                {
                    
                    new SequentialSort().MergeSort(array, leftIndex, rightIndex);
                }
                else
                {
                    var middleIndex = (leftIndex + rightIndex) / 2;
                    Parallel.Invoke(
                        () => MergeSort(array, leftIndex, middleIndex),
                        () => MergeSort(array, middleIndex + 1, rightIndex)
                    );
                    Merge(array, leftIndex, middleIndex, rightIndex);
                }
            }
        }

    }
}

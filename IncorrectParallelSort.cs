using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    public class IncorrectParallelSort : BaseSorter
    {
        public override void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;

                Parallel.Invoke(
                    () => MergeSort(array, leftIndex, middleIndex),
                    () => MergeSort(array, middleIndex + 1, rightIndex)
                );

                IncorrectParallelMerge(array, leftIndex, middleIndex, rightIndex);
            }
        }

        private static void IncorrectParallelMerge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            int[] tempArr = new int[rightIndex - leftIndex + 1];
            int leftStart = leftIndex;
            int rightStart = middleIndex + 1;

            Parallel.For(leftIndex, rightIndex + 1, i =>
            {
                if (leftStart <= middleIndex && (rightStart > rightIndex || array[leftStart] <= array[rightStart]))
                {
                    tempArr[i - leftIndex] = array[leftStart];
                    leftStart++;
                }
                else
                {
                    tempArr[i - leftIndex] = array[rightStart];
                    rightStart++;
                }
            });

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                array[i] = tempArr[i - leftIndex];
            }
        }
    }
}

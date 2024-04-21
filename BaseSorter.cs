using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    public abstract class BaseSorter
    {
        public abstract void MergeSort(int[] array, int leftIndex, int rightIndex);

        protected void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            int leftPointer = leftIndex;
            int rightPointer = middleIndex + 1;
            int[] tempArr = new int[rightIndex - leftIndex + 1];
            var i = 0;

            while ((leftPointer <= middleIndex) && (rightPointer <= rightIndex))
            {
                if (array[leftPointer] < array[rightPointer])
                {
                    tempArr[i] = array[leftPointer];
                    leftPointer++;
                }
                else
                {
                    tempArr[i] = array[rightPointer];
                    rightPointer++;
                }
                i++;
            }

            for (int j = leftPointer; j <= middleIndex; j++)
            {
                tempArr[i] = array[j];
                i++;
            }

            for (int j = rightPointer; j <= rightIndex; j++)
            {
                tempArr[i] = array[j];
                i++;
            }

            for (int j = 0; j < tempArr.Length; j++)
            {
                array[leftIndex + j] = tempArr[j];
            }
        }

        public void Sort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }
    }
}

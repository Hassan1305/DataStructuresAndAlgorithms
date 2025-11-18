using System;

namespace DataStructuresAndAlgorithms
{
    public class BlockSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            int n = a.Length;
            int blockSize = (int)Math.Sqrt(n);
            
            // Sort blocks of size sqrt(n)
            for (int i = 0; i < n; i += blockSize)
            {
                int end = Math.Min(i + blockSize - 1, n - 1);
                InsertionSort(a, i, end);
            }

            // Merge sorted blocks
            for (int size = blockSize; size < n; size *= 2)
            {
                for (int start = 0; start < n; start += 2 * size)
                {
                    int mid = Math.Min(start + size - 1, n - 1);
                    int end = Math.Min(start + 2 * size - 1, n - 1);
                    
                    if (mid < end)
                    {
                        Merge(a, start, mid, end);
                    }
                }
            }
        }

        private void InsertionSort(int[] arr, int start, int end)
        {
            for (int i = start + 1; i <= end; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= start && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= mid)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (i = 0; i < temp.Length; i++)
                arr[left + i] = temp[i];
        }
    }
}
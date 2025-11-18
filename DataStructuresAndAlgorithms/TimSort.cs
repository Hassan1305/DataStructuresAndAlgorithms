using System;

namespace DataStructuresAndAlgorithms
{
    public class TimSort : AbstractSort
    {
        private const int MIN_MERGE = 32;

        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            int n = a.Length;
            int minRun = GetMinRunLength(n);

            // Sort individual runs of size minRun using insertion sort
            for (int i = 0; i < n; i += minRun)
            {
                int end = Math.Min(i + minRun - 1, n - 1);
                InsertionSort(a, i, end);
            }

            // Start merging from size minRun
            for (int size = minRun; size < n; size = 2 * size)
            {
                // Pick starting point of left sub array
                for (int start = 0; start < n; start += 2 * size)
                {
                    // Calculate mid and end points
                    int mid = Math.Min(start + size - 1, n - 1);
                    int end = Math.Min(start + 2 * size - 1, n - 1);

                    // Merge subarrays if mid < end
                    if (mid < end)
                        Merge(a, start, mid, end);
                }
            }
        }

        private int GetMinRunLength(int n)
        {
            int r = 0;
            while (n >= MIN_MERGE)
            {
                r |= (n & 1);
                n >>= 1;
            }
            return n + r;
        }

        private void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private void Merge(int[] arr, int left, int mid, int right)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;
            int[] leftArr = new int[len1];
            int[] rightArr = new int[len2];

            Array.Copy(arr, left, leftArr, 0, len1);
            Array.Copy(arr, mid + 1, rightArr, 0, len2);

            int i = 0, j = 0, k = left;

            while (i < len1 && j < len2)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < len1)
            {
                arr[k] = leftArr[i];
                k++;
                i++;
            }

            while (j < len2)
            {
                arr[k] = rightArr[j];
                k++;
                j++;
            }
        }
    }
}
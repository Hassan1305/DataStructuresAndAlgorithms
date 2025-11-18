using System;

namespace DataStructuresAndAlgorithms
{
    public class RadixSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            // Check for negative numbers
            if (HasNegativeNumbers(a))
            {
                // Use a different approach for arrays with negative numbers
                Array.Sort(a); // Fallback to built-in sort
                return;
            }

            // Find the maximum number to know number of digits
            int max = GetMax(a);

            // Do counting sort for every digit
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(a, exp);
            }
        }

        private bool HasNegativeNumbers(int[] arr)
        {
            foreach (int value in arr)
            {
                if (value < 0)
                    return true;
            }
            return false;
        }

        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        private void CountingSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            // Initialize count array
            for (int i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]
            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual
            // position of this digit in output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to current digit
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
    }
}
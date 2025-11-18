using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class BucketSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            int max = GetMax(a);
            int min = GetMin(a);
            int bucketCount = a.Length;
            
            List<int>[] buckets = new List<int>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribute elements into buckets
            for (int i = 0; i < a.Length; i++)
            {
                int bucketIndex = (int)((double)(a[i] - min) / (max - min + 1) * bucketCount);
                if (bucketIndex >= bucketCount) bucketIndex = bucketCount - 1;
                buckets[bucketIndex].Add(a[i]);
            }

            // Sort individual buckets and concatenate
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                if (buckets[i].Count > 0)
                {
                    buckets[i].Sort();
                    foreach (int value in buckets[i])
                    {
                        a[index++] = value;
                    }
                }
            }
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

        private int GetMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
    }
}
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class CubeSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            int n = a.Length;
            int max = GetMax(a);
            int min = GetMin(a);
            int range = max - min + 1;

            // Create cube buckets
            int cubeSize = (int)Math.Ceiling(Math.Pow(n, 1.0 / 3.0));
            List<int>[,,] cube = new List<int>[cubeSize, cubeSize, cubeSize];

            // Initialize cube
            for (int i = 0; i < cubeSize; i++)
            {
                for (int j = 0; j < cubeSize; j++)
                {
                    for (int k = 0; k < cubeSize; k++)
                    {
                        cube[i, j, k] = new List<int>();
                    }
                }
            }

            // Distribute elements into cube buckets
            foreach (int value in a)
            {
                int normalizedValue = value - min;
                int x = (int)((double)normalizedValue / range * cubeSize);
                int y = (int)((double)normalizedValue / range * cubeSize);
                int z = (int)((double)normalizedValue / range * cubeSize);

                if (x >= cubeSize) x = cubeSize - 1;
                if (y >= cubeSize) y = cubeSize - 1;
                if (z >= cubeSize) z = cubeSize - 1;

                cube[x, y, z].Add(value);
            }

            // Sort each bucket and collect results
            int index = 0;
            for (int i = 0; i < cubeSize; i++)
            {
                for (int j = 0; j < cubeSize; j++)
                {
                    for (int k = 0; k < cubeSize; k++)
                    {
                        if (cube[i, j, k].Count > 0)
                        {
                            cube[i, j, k].Sort();
                            foreach (int value in cube[i, j, k])
                            {
                                a[index++] = value;
                            }
                        }
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
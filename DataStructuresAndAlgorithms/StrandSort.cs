using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class StrandSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            List<int> input = new List<int>(a);
            List<int> output = new List<int>();

            while (input.Count > 0)
            {
                List<int> strand = new List<int>();
                strand.Add(input[0]);
                input.RemoveAt(0);

                // Extract increasing subsequence (strand)
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] >= strand[strand.Count - 1])
                    {
                        strand.Add(input[i]);
                        input.RemoveAt(i);
                        i--; // Adjust index after removal
                    }
                }

                // Merge strand with output
                output = MergeStrands(output, strand);
            }

            // Copy result back to original array
            for (int i = 0; i < output.Count; i++)
            {
                a[i] = output[i];
            }
        }

        private List<int> MergeStrands(List<int> list1, List<int> list2)
        {
            List<int> merged = new List<int>();
            int i = 0, j = 0;

            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] <= list2[j])
                {
                    merged.Add(list1[i]);
                    i++;
                }
                else
                {
                    merged.Add(list2[j]);
                    j++;
                }
            }

            while (i < list1.Count)
            {
                merged.Add(list1[i]);
                i++;
            }

            while (j < list2.Count)
            {
                merged.Add(list2[j]);
                j++;
            }

            return merged;
        }
    }
}
namespace DataStructuresAndAlgorithms
{
    public class CycleSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return;

            int n = a.Length;

            for (int cycle_start = 0; cycle_start < n - 1; cycle_start++)
            {
                int item = a[cycle_start];
                int pos = cycle_start;

                // Find position where we put the item
                for (int i = cycle_start + 1; i < n; i++)
                {
                    if (a[i] < item)
                        pos++;
                }

                // If item is already in correct position
                if (pos == cycle_start)
                    continue;

                // Skip duplicates
                while (item == a[pos])
                    pos += 1;

                // Put the item to its correct position
                if (pos != cycle_start)
                {
                    int temp = item;
                    item = a[pos];
                    a[pos] = temp;
                }

                // Rotate rest of the cycle
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element
                    for (int i = cycle_start + 1; i < n; i++)
                    {
                        if (a[i] < item)
                            pos += 1;
                    }

                    // Skip duplicates
                    while (item == a[pos])
                        pos += 1;

                    // Put the item to its correct position
                    if (item != a[pos])
                    {
                        int temp = item;
                        item = a[pos];
                        a[pos] = temp;
                    }
                }
            }
        }
    }
}
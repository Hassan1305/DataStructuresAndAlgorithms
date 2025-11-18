using DataStructuresAndAlgorithms;
using System.Diagnostics;

List<AbstractSort> algorithms = new()
{
    //new SelectionSort(),
    //new InsertionSort(),
    //new BubbleSort(),
    //new MergeSort(),
    //new ShellSort(),
    new QuickSort(),
    //new HeapSort(),
    //new BlockSort(),
    //new BucketSort(),
    //new CubeSort(),
    //new CycleSort(),
    new RadixSort(),
    //new StrandSort(),
    //new TreeSort(),
    new TimSort()
};

for (int n = 0; n <= 10000000; n += 1000000)
{
    Console.WriteLine($"\nRunning tests for n = {n}:");
    List<(Type Type, long Ms)> milliseconds = [];
    for (int i = 0; i < 5; i++)
    {
        int[] array = GetRandomArray(n);
        int[] input = new int[n];
        foreach (AbstractSort algorithm in algorithms)
        {
            array.CopyTo(input, 0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            algorithm.Sort(input);
            stopwatch.Stop();
            Type type = algorithm.GetType();
            long ms = stopwatch.ElapsedMilliseconds;
            milliseconds.Add((type, ms));
        }
    }
    List<(Type, double)> results = milliseconds
        .GroupBy(r => r.Type)
        .Select(r => (r.Key, r.Average(t => t.Ms)))
        .ToList();
    foreach ((Type type, double avg) in results)
    {
        Console.WriteLine($"{type.Name}: {avg} ms");
    }
}

static int[] GetRandomArray(long length)
{
    Random random = new();
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = random.Next(-100000, 100000);
    }
    return array;
}

static int[] GetWorstArray(long length)
{
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = Int32.MaxValue - i;
    }
    return array;
}
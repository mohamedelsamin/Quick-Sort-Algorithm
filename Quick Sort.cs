using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };

        ParallelQuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array: " + string.Join(", ", arr));
    }

    static void ParallelQuickSort(int[] arr, int low, int high, int threshold = 1000)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            // Only parallelize if size is above threshold
            if ((high - low) > threshold)
            {
                Parallel.Invoke(
                    () => ParallelQuickSort(arr, low, pi - 1, threshold),
                    () => ParallelQuickSort(arr, pi + 1, high, threshold)
                );
            }
            else
            {
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        if (i == j) return;
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

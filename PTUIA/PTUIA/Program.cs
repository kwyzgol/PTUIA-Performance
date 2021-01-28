using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace PTUIA
{
    public static class Sorting
    {
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if(arr[j] > arr[j+1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }
    }

    [MemoryDiagnoser]
    [NativeMemoryProfiler]
    public class SortingBenchmark
    {
        private int size = 100000;
        private int[] arr1;
        private int[] arr2;

        public SortingBenchmark()
       {
            Random rand = new Random();
            arr1 = new int[size];
            arr2 = new int[size];

            for (int i = 0; i < size; i++)
            {
                int tmp = rand.Next();
                arr1[i] = tmp;
                arr2[i] = tmp;
            }
        }

        [Benchmark]
        public void QuickSortBenchmark()
        {
            Sorting.QuickSort(arr1, 0, arr1.Length - 1);     
        }

        [Benchmark]
        public void BubbleSortBenchmark()
        {
            Sorting.BubbleSort(arr2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* BenchmarkDotNet */
            //var summary = BenchmarkRunner.Run<SortingBenchmark>();

            /* Narzędzia diagnostycznie */
            SortingBenchmark sortingBenchmark = new SortingBenchmark();
            sortingBenchmark.QuickSortBenchmark();
            sortingBenchmark.BubbleSortBenchmark();
        }
    }
}

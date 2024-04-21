using Merge;
using System.Diagnostics;

internal class Program
{
    private static int[] GenerateRandomData(int size)
    {
        int[] resultArr = new int[size];

        Random rnd = new Random();

        for (int i = 0; i < resultArr.Length; i++)
        {
            resultArr[i] = rnd.Next(0, 1000);
        }

        return resultArr;
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" " + array[i]);
        }
    }

    private static void Main(string[] args)
    {
        int[] nums = GenerateRandomData(1000000);

        Stopwatch seqWatch = new Stopwatch();
        Stopwatch incorrectWatch = new Stopwatch();
        Stopwatch correctWatch = new Stopwatch();


        Console.WriteLine("Последовательный алгоритм");
        BaseSorter sorter = new SequentialSort();
        int[] numsForSequentialSort = (int[])nums.Clone();
        seqWatch.Start();
        sorter.Sort(numsForSequentialSort);
        seqWatch.Stop();
        //PrintArray(numsForSequentialSort);
        Console.WriteLine($"\nSequential: time elapsed = {seqWatch.Elapsed}");

        Console.WriteLine("\nНеправильный алгоритм");
        sorter = new IncorrectParallelSort();
        int[] numsForIncorrectParallelSort = (int[])nums.Clone();
        incorrectWatch.Start();
        sorter.Sort(numsForIncorrectParallelSort);
        incorrectWatch.Stop();
       // PrintArray(numsForIncorrectParallelSort);
        Console.WriteLine($"\nIncorrect: time elapsed = {incorrectWatch.Elapsed}");


        Console.WriteLine("\nПравильный алгоритм");
        sorter = new CorrectParallelSorter();
        int[] numsForCorrectParallelSort = (int[])nums.Clone();
        correctWatch.Start();
        sorter.Sort(numsForCorrectParallelSort);
        correctWatch.Stop();
       // PrintArray(numsForCorrectParallelSort);
        Console.WriteLine($"\nCorrect: time elapsed = {correctWatch.Elapsed}");

        Console.ReadLine();
    }
}
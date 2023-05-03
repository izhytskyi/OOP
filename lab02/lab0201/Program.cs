using System;

public static class ArrayExtensions
{
    public static void PrintReversed(this int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.Write("Масив numbers: ");
        foreach (int n in numbers)
        {
            Console.Write($"{n} ");
        }
        Console.WriteLine();

        Console.Write("Масив numbers в зворотньому порядку: ");
        numbers.PrintReversed();

        Console.ReadKey();
    }
}

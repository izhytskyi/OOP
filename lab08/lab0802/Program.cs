using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        double epsilon = 0.01; // введіть значення для ε
        string filename = "E:\\h.txt"; // ім'я файлу для запису послідовності

        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int i = 1; ; i++)
            {
                double xi = (i - 0.1) / (Math.Pow(i, 3) + Math.Abs(Math.Tan(2 * i)));
                writer.WriteLine(xi);

                if (Math.Abs(xi) < epsilon)
                {
                    break;
                }
            }
        }

        Console.WriteLine($"Перший елемент, для якого виконується |x_i| < ε: {epsilon}");
    }
}

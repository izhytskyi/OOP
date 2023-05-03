using System;

class Computer
{
    public string Processor { get; set; }
    public int Frequency { get; set; }
    public int RAM { get; set; }
    public string Type { get; set; }

    private static int count = 0;

    public Computer(string processor, int frequency, int ram, string type)
    {
        Processor = processor;
        Frequency = frequency;
        RAM = ram;
        Type = type;
        count++;
    }

    public static int Count
    {
        get { return count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Computer[] computers = new Computer[10];

        computers[0] = new Computer("Pentium-III", 233, 256, "C");
        computers[1] = new Computer("AMD-K6", 166, 128, "C");
        computers[2] = new Computer("PowerPC-620", 2000, 512, "R");
        computers[3] = new Computer("Pentium-IV", 2400, 1024, "D");
        computers[4] = new Computer("AMD Athlon 64 X2", 2600, 2048, "D");
        computers[5] = new Computer("Intel Core i3", 3000, 4096, "L");
        computers[6] = new Computer("Intel Core i5", 3400, 8192, "L");
        computers[7] = new Computer("Intel Core i7", 3700, 16384, "L");
        computers[8] = new Computer("AMD Ryzen 5", 3500, 16384, "D");
        computers[9] = new Computer("AMD Ryzen 9", 3900, 32768, "D");

        Console.WriteLine("Computers with RAM greater than 8 GB:");
        for (int i = 0; i < computers.Length; i++)
        {
            if (computers[i].RAM > 8192)
            {
                Console.WriteLine($"Processor: {computers[i].Processor}, RAM: {computers[i].RAM} MB");
            }
        }

        Console.WriteLine("Number of computers created: " + Computer.Count);

        const int limit1 = 20;
        const int limit2 = 5;

        if (Computer.Count > limit1)
        {
            Console.WriteLine("Warning: number of computers exceeds limit 1");
        }
        else if (Computer.Count < limit2)
        {
            Console.WriteLine("Warning: number of computers is less than limit 2");
        }
    }
}

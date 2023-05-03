using System;

class Processor
{
    private string type;
    private int frequency;
    private int ram;

    // Конструктори
    public Processor() : this("Unknown", 0, 0) { }

    public Processor(string type, int frequency, int ram)
    {
        this.type = type;
        this.frequency = frequency;
        this.ram = ram;
    }

    public Processor(Processor other)
    {
        this.type = other.type;
        this.frequency = other.frequency;
        this.ram = other.ram;
    }

    // Аксесори та мутатори
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Frequency
    {
        get { return frequency; }
        set
        {
            if (value > 0)
                frequency = value;
            else
                Console.WriteLine("Frequency must be a positive integer.");
        }
    }

    public int Ram
    {
        get { return ram; }
        set
        {
            if (value > 0)
                ram = value;
            else
                Console.WriteLine("RAM must be a positive integer.");
        }
    }

    // Деструктор
    ~Processor()
    {
        Console.WriteLine("Processor object destroyed.");
    }
}

class Program
{
    static void Main()
    {
        Processor p1 = new Processor();
        Processor p2 = new Processor("Pentium-III", 233, 256);
        Processor p3 = new Processor(p2);

        p1.Type = "AMD-K6";
        p1.Frequency = 166;
        p1.Ram = 128;

        Console.WriteLine("Processor 1: {0} {1}Mgz {2}Mb", p1.Type, p1.Frequency, p1.Ram);
        Console.WriteLine("Processor 2: {0} {1}Mgz {2}Mb", p2.Type, p2.Frequency, p2.Ram);
        Console.WriteLine("Processor 3: {0} {1}Mgz {2}Mb", p3.Type, p3.Frequency, p3.Ram);
    }
}

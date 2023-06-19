using System;

interface Lamp
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int Power { get; set; }
    string LightType { get; set; }
    int LightCount { get; set; }

    void PrintDetails();
    void ChangePower(int newPower);
}

interface Camera
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int LensSensitivity { get; set; }

    void PrintDetails();
    void ChangeLensSensitivity(int newSensitivity);
}

class PhotoStudio : Lamp, Camera
{
    public string Type { get; set; }
    public string Manufacturer { get; set; }
    public int Power { get; set; }
    public string LightType { get; set; }
    public int LightCount { get; set; }
    public int LensSensitivity { get; set; }

    public void PrintDetails()
    {
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Manufacturer: {Manufacturer}");
        Console.WriteLine($"Power: {Power} lumens");
        Console.WriteLine($"Light Type: {LightType}");
        Console.WriteLine($"Light Count: {LightCount}");
        Console.WriteLine($"Lens Sensitivity: {LensSensitivity}");
        Console.WriteLine();
    }

    public void ChangePower(int newPower)
    {
        Power = newPower;
    }

    public void ChangeLensSensitivity(int newSensitivity)
    {
        LensSensitivity = newSensitivity;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PhotoStudio studio1 = new PhotoStudio()
        {
            Type = "Studio",
            Manufacturer = "ABC Company",
            Power = 2000,
            LightType = "LED",
            LightCount = 4,
            LensSensitivity = 100
        };

        PhotoStudio studio2 = new PhotoStudio()
        {
            Type = "Portable",
            Manufacturer = "XYZ Corporation",
            Power = 1000,
            LightType = "Halogen",
            LightCount = 2,
            LensSensitivity = 200
        };

        studio1.PrintDetails();
        studio2.PrintDetails();

        studio1.ChangeLensSensitivity(150);

        Console.WriteLine("Updated studio1 details:");
        studio1.PrintDetails();
    }
}

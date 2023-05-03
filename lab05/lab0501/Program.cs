using System;

// Опис інтерфейсу IShape
public interface IShape
{
    void PrintType();
    void PrintArea();
    double Length { get; set; }
}

// Опис інтерфейсу IColoredShape, який успадковується від IShape
public interface IColoredShape : IShape
{
    string Color { get; set; }
    void PrintColor();
}

// Реалізація класу Circle, який реалізує інтерфейс IShape
public class Circle : IShape
{
    public Circle(double radius)
    {
        Length = radius;
    }

    public void PrintType()
    {
        Console.WriteLine("Це коло.");
    }

    public void PrintArea()
    {
        Console.WriteLine($"Площа кола: {Math.PI * Length * Length}");
    }

    public double Length { get; set; }
}

// Реалізація класу ColoredCircle, який успадковує від Circle та реалізує інтерфейс IColoredShape
public class ColoredCircle : Circle, IColoredShape
{
    public ColoredCircle(double radius, string color) : base(radius)
    {
        Color = color;
    }

    public string Color { get; set; }

    public void PrintColor()
    {
        Console.WriteLine($"Колiр кола: {Color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення трьох екземплярів кожного класу та формування з них масиву
        IShape[] shapes = new IShape[6];
        shapes[0] = new Circle(5);
        shapes[1] = new Circle(7);
        shapes[2] = new Circle(3);
        shapes[3] = new ColoredCircle(4, "червоний");
        shapes[4] = new ColoredCircle(2, "синiй");
        shapes[5] = new ColoredCircle(6, "зелений");

        // Метод, що виконує методи кожного елемента масиву в залежності від інтерфейсу, що реалізується класом об’єкта
        foreach (IShape shape in shapes)
        {
            shape.PrintType();
            shape.PrintArea();

            if (shape is IColoredShape)
            {
                ((IColoredShape)shape).PrintColor();
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

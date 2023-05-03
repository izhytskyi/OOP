using System;

interface Printable
{
    void print();
}

class Book : Printable
{
    private string title;

    public Book(string title)
    {
        this.title = title;
    }

    public void print()
    {
        Console.WriteLine("Book: " + title);
    }
}

class Magazine : Printable
{
    private string title;

    public Magazine(string title)
    {
        this.title = title;
    }

    public void print()
    {
        Console.WriteLine("Magazine: " + title);
    }

    public static void printMagazines(Printable[] printable)
    {
        foreach (Printable p in printable)
        {
            if (p is Magazine)
            {
                p.print();
            }
        }
    }
}

class BookPrinter
{
    public static void printBooks(Printable[] printable)
    {
        foreach (Printable p in printable)
        {
            if (p is Book)
            {
                p.print();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Printable[] printable = new Printable[4];
        printable[0] = new Book("C# Programming");
        printable[1] = new Magazine("Time");
        printable[2] = new Book("The Catcher in the Rye");
        printable[3] = new Magazine("National Geographic");

        foreach (Printable p in printable)
        {
            p.print();
        }

        Magazine.printMagazines(printable);
        BookPrinter.printBooks(printable);
    }
}

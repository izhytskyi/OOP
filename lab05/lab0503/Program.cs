using System.Drawing;

class Shop
{
    private string[] sizes = { "XXS", "XS", "S", "M", "L" };
    private int euroSize;

    public Shop(int euroSize)
    {
        this.euroSize = euroSize;
    }

    public string getDescription()
    {
        if (euroSize == 32 || sizes.Contains("XXS"))
        {
            return "Дитячий розмір";
        }
        else
        {
            return "Дорослий розмір";
        }
    }
}

public interface IManClothes
{
    void DressMan();
}

public interface IWomanClothes
{
    void DressWoman();
}

public abstract class Clothes
{
    public int Size { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
}

public class TShirt : Clothes, IManClothes, IWomanClothes
{
    public void DressMan()
    {
        Console.WriteLine("The man is wearing a T-shirt");
    }

    public void DressWoman()
    {
        Console.WriteLine("The woman is wearing a T-shirt");
    }
}

public class Pants : Clothes, IManClothes
{
    public void DressMan()
    {
        Console.WriteLine("The man is wearing pants");
    }
}

public class Skirt : Clothes, IWomanClothes
{
    public void DressWoman()
    {
        Console.WriteLine("The woman is wearing a skirt");
    }
}

public class Tie : Clothes, IManClothes
{
    public void DressMan()
    {
        Console.WriteLine("The man is wearing a tie");
    }
}

public class Atelier
{
    public void DressWoman(IWomanClothes[] clothes)
    {
        foreach (var item in clothes)
        {
            item.DressWoman();
        }
    }

    public void DressMan(IManClothes[] clothes)
    {
        foreach (var item in clothes)
        {
            item.DressMan();
        }
    }
}

partial class Program
{
    static void Main(string[] args)
    {
        // Створюємо масив з кожним класом одягу
        Clothes[] clothingTypes = new Clothes[] {
    new TShirt(),
    new Pants(),
    new Skirt(),
    new Tie()
};

        // Створюємо масив, що містить усі екземпляри класів
        Clothes[] allClothing = new Clothes[clothingTypes.Length];
        for (int i = 0; i < clothingTypes.Length; i++)
        {
            allClothing[i] = clothingTypes[i];
        }

        var clothes = new Clothes[]
        {
            new TShirt() { Size = 42, Price = 20.50m, Color = "White" },
            new Pants() { Size = 34, Price = 50.00m, Color = "Black" },
            new Skirt() { Size = 38, Price = 40.00m, Color = "Blue" },
            new Tie() { Size = 39, Price = 10.00m, Color = "Red" }
        };

        var atelier = new Atelier();
        atelier.DressWoman(Array.FindAll(clothes, x => x is IWomanClothes).Cast<IWomanClothes>().ToArray());
        atelier.DressMan(Array.FindAll(clothes, x => x is IManClothes).Cast<IManClothes>().ToArray());
    }
}
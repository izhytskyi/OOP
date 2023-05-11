using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо масив об'єктів CollectionType
        var collections = new CollectionType[]
        {
            new CollectionType("Collection1", new Dictionary<int, string> {{1, "A"}, {2, "B"}, {3, "C"}}),
            new CollectionType("Collection2", new Dictionary<int, string> {{1, "D"}, {2, "E"}}),
            new CollectionType("Collection3", new Dictionary<int, string> {{1, "A"}, {2, "B"}}),
            new CollectionType("Collection4", new Dictionary<int, string> {{1, "E"}, {2, "F"}, {3, "G"}, {4, "H"}}),
        };

        // Знаходимо кількість колекцій, що містять вказаний елемент
        string elementToFind = "B";
        int collectionsContainingElementCount = collections.Count(c => c.Collection.ContainsKey(c.Collection.FirstOrDefault(kv => kv.Value == elementToFind).Key));
        Console.WriteLine($"Кiлькiсть колекцiй, що мiстять елемент {elementToFind}: {collectionsContainingElementCount}");

        // Знаходимо максимальну колекцію, що містить вказаний елемент
        var maxCollectionContainingElement = collections
            .Where(c => c.Collection.ContainsKey(c.Collection.FirstOrDefault(kv => kv.Value == elementToFind).Key))
            .OrderByDescending(c => c.Collection.Count)
            .FirstOrDefault();
        Console.WriteLine($"Назва максимальної колекцiї, що мiстить елемент {elementToFind}: {maxCollectionContainingElement?.Name ?? "Немає"}");
    }
}

// Клас, що представляє колекцію з назвою та словником
class CollectionType
{
    public string Name { get; set; }
    public Dictionary<int, string> Collection { get; set; }

    public CollectionType(string name, Dictionary<int, string> collection)
    {
        Name = name;
        Collection = collection;
    }
}

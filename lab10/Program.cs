using System;
using System.Collections.Generic;

namespace OOP_lab10
{
    public class CharSet
    {
        private HashSet<char> elements;

        // Конструктор за замовчуванням створює порожню множину
        public CharSet()
        {
            elements = new HashSet<char>();
        }

        // Конструктор, який створює множину з вказаних символів
        public CharSet(params char[] chars)
        {
            elements = new HashSet<char>(chars);
        }

        // Оператор об'єднання множин
        public static CharSet operator +(CharSet set1, CharSet set2)
        {
            CharSet result = new CharSet();
            foreach (char element in set1.elements)
            {
                result.Add(element);
            }
            foreach (char element in set2.elements)
            {
                result.Add(element);
            }
            return result;
        }

        // Оператор порівняння множин
        public static bool operator <=(CharSet set1, CharSet set2)
        {
            return set2.elements.IsSupersetOf(set1.elements);
        }

        public static bool operator >=(CharSet set1, CharSet set2)
        {
            return set2 <= set1;
        }


        // Додавання елемента до множини
        public void Add(char element)
        {
            elements.Add(element);
        }

        // Видалення елемента з множини
        public void Remove(char element)
        {
            elements.Remove(element);
        }

        // Перевірка чи є елемент у множині
        public bool Contains(char element)
        {
            return elements.Contains(element);
        }

        // Отримання кількості елементів у множині
        public int Count()
        {
            return elements.Count;
        }

        // Перетворення множини у рядок
        public override string ToString()
        {
            return "{" + string.Join(", ", elements) + "}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharSet set1 = new CharSet('a', 'b', 'c');
            CharSet set2 = new CharSet('b', 'c', 'd');

            // Додавання елементу до множини
            set1.Add('d');

            // Видалення елементу з множини
            set2.Remove('d');

            // Перевірка чи є елемент у множині
            Console.WriteLine(set1.Contains('a')); // Виведе "True"
            Console.WriteLine(set2.Contains('d')); // Виведе "False"

            // Отримання кількості елементів у множині
            Console.WriteLine(set1.Count()); // Виведе "4"

            // Оператор об'єднання множин
            CharSet set3 = set1 + set2;
            Console.WriteLine(set3.ToString()); // Виведе "{a, b, c}"

            // Оператор порівняння множин
            Console.WriteLine(set1 <= set3); // Виведе "True"
            Console.WriteLine(set2 <= set1); // Виведе "False"
        }
    }
}

using System;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "01010101110001101";
            int position = 3; // задана позиція, з якої починається заміна
            char[] charArray = input.ToCharArray(); // перетворення рядка в масив символів

            for (int i = position; i < input.Length; i++)
            {
                if (charArray[i] == '0')
                {
                    charArray[i] = '1';
                }
                else if (charArray[i] == '1')
                {
                    charArray[i] = '0';
                }
            }

            string result = new string(charArray); // перетворення масиву символів назад в рядок
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}

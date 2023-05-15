using System;

namespace DateCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.Write("Введiть дату у форматi дд.мм.рррр: ");
            string input = Console.ReadLine();
            DateTime targetDate = DateTime.ParseExact(input, "dd.MM.yyyy", null);

            TimeSpan difference = targetDate - today;

            if (difference.Days < 0)
            {
                Console.WriteLine("Вказана дата вже минула.");
            }
            else
            {
                Console.WriteLine("Кiлькiсть днiв до вказаної дати: {0}", difference.Days);
            }

            Console.ReadKey();
        }
    }
}

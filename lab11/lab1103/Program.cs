using System;

namespace DateProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "01,01,2000,15,05,1995,31,12,2010";
            string[] dates = input.Split(',');

            int minYear = int.MaxValue;
            DateTime latestDate = DateTime.MinValue;
            for (int i = 0; i < dates.Length; i += 3)
            {
                int day = int.Parse(dates[i]);
                int month = int.Parse(dates[i + 1]);
                int year = int.Parse(dates[i + 2]);

                if (year < minYear)
                {
                    minYear = year;
                }

                DateTime date = new DateTime(year, month, day);
                if (date > latestDate)
                {
                    latestDate = date;
                }

                if (month >= 3 && month <= 5)
                {
                    Console.WriteLine("{0}.{1}.{2} є весняною датою.", day, month, year);
                }
            }

            Console.WriteLine("Рiк з найменшим номером: {0}", minYear);
            Console.WriteLine("Найпiзнiша дата: {0}.{1}.{2}", latestDate.Day, latestDate.Month, latestDate.Year);
            Console.ReadKey();
        }
    }
}

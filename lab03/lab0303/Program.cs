using System;

class Time
{
    public int hours;
    public int minutes;
    public int seconds;

    public Time()
    {
        hours = 0;
        minutes = 0;
        seconds = 0;
    }

    public Time(int h, int m, int s)
    {
        hours = h;
        minutes = m;
        seconds = s;
    }

    public int GetMinutes()
    {
        return hours * 60 + minutes;
    }

    public void DecreaseTime()
    {
        int totalMinutes = GetMinutes() - 10;
        hours = totalMinutes / 60;
        minutes = totalMinutes % 60;
    }

    public string GetInfo()
    {
        return $"{hours:00}:{minutes:00}:{seconds:00}";
    }
}

class MobileTime : Time
{
    public string lastName;
    public string operatorName;

    public MobileTime()
    {
        lastName = "";
        operatorName = "";
    }

    public MobileTime(int h, int m, int s, string ln, string op) : base(h, m, s)
    {
        lastName = ln;
        operatorName = op;
    }

    public bool IsDiscountTime()
    {
        return hours < 8;
    }

    public new string GetInfo()
    {
        return $"Last Name: {lastName}\nOperator: {operatorName}\nTime: {hours:00}:{minutes:00}:{seconds:00}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Time time1 = new Time(10, 25, 30);
        Console.WriteLine($"Time: {time1.GetInfo()}");
        Console.WriteLine($"Minutes: {time1.GetMinutes()}");
        time1.DecreaseTime();
        Console.WriteLine($"Time after decreasing by 10 minutes: {time1.GetInfo()}");
        Console.WriteLine();

        MobileTime mobileTime1 = new MobileTime(6, 45, 0, "Ivanov", "Kyivstar");
        Console.WriteLine($"Mobile Time: {mobileTime1.GetInfo()}");
        Console.WriteLine($"Is Discount Time: {mobileTime1.IsDiscountTime()}");
    }
}

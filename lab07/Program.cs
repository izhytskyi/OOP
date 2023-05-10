using System;

class Company
{
    public string Name { get; set; }
    public int SubscriberCount { get; set; }
}

class Tariff
{
    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NazvaException();
            }
            name = value;
        }
    }

    public int SubscriberCount { get; set; }

    public double CalculateCostPerSecond { get; set; }

    public double CalculateCostPerMinute { get; set; }
}

class Subscriber
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public double Balance { get; set; }
}

class KilkistSekundException : Exception
{
    public KilkistSekundException(string message) : base(message) { }
}

class NazvaException : Exception
{
    public NazvaException() : base("Неможливо створити тариф – не вказано назву") { }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var perSecondTariff = new Tariff
            {
                Name = "Per Second Tariff",
                SubscriberCount = 100,
                CalculateCostPerSecond = 0.05,
                CalculateCostPerMinute = 3
            };

            var perMinuteTariff = new Tariff
            {
                Name = "Per Minute Tariff",
                SubscriberCount = 50,
                CalculateCostPerSecond = 0.002,
                CalculateCostPerMinute = 1
            };

            var subscriber = new Subscriber
            {
                FullName = "John Doe",
                PhoneNumber = "555-1234",
                Balance = 10
            };

            var callSeconds = 100;
            Console.WriteLine($"Call cost for {callSeconds} seconds using per second tariff is {CalculateCallCost(perSecondTariff, callSeconds)}");
            Console.WriteLine($"Call cost for {callSeconds} seconds using per minute tariff is {CalculateCallCost(perMinuteTariff, callSeconds)}");

            callSeconds = -10; // trying to make an invalid call with negative duration
            Console.WriteLine($"Call cost for {callSeconds} seconds using per second tariff is {CalculateCallCost(perSecondTariff, callSeconds)}");
        }
        catch (KilkistSekundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NazvaException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static double CalculateCallCost(Tariff tariff, int callSeconds)
    {
        if (callSeconds < 0)
        {
            throw new KilkistSekundException("Duration cannot be negative");
        }

        if (callSeconds < 60)
        {
            return tariff.CalculateCostPerSecond * callSeconds;
        }
        else
        {
            var minutes = callSeconds / 60;
            var seconds = callSeconds % 60;
            return tariff.CalculateCostPerMinute * minutes + tariff.CalculateCostPerSecond * seconds;
        }
    }
}

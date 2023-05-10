using System;

public delegate void PrintDelegate(string message);

public class ChordMethod
{
    private Func<double, double> f; // поле для функції
    private Func<double, double> df; // поле для похідної функції
    private PrintDelegate print; // поле для делегату виведення результату

    public ChordMethod(Func<double, double> f, Func<double, double> df, PrintDelegate print)
    {
        this.f = f;
        this.df = df;
        this.print = print;
    }

    public double FindRoot(double a, double b, double eps)
    {
        Func<double, double> func = this.f;
        Func<double, double> derivFunc = this.df;
        Func<double, double> fdf = x => func(x) / derivFunc(x);

        fdf += x => -1; // додаємо константу -1 до fdf, щоб забезпечити збіжність

        double fa = func(a);
        double fb = func(b);
        double x = a - fa * (b - a) / (fb - fa);

        while (Math.Abs(func(x)) > eps)
        {
            x = x - fdf(x) * func(x);
        }

        print("Root: " + x);

        return x;
    }
}


class Program
{
    static void Main(string[] args)
    {
        // створюємо екземпляр класу ChordMethod з використанням делегату для виведення результату
        ChordMethod cm = new ChordMethod(
            x => Math.Cos(x) - x,
            x => -Math.Sin(x),
            Console.WriteLine);

        // знаходимо корінь рівняння методом хорд та виводимо результат з використанням делегату
        cm.FindRoot(0, Math.PI / 2, 0.0001);
    }
}

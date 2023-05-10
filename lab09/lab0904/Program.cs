using System;

public class ChordMethod
{
    private Func<double, double> f; // поле для функції
    private Func<double, double> df; // поле для похідної функції

    public ChordMethod(Func<double, double> f, Func<double, double> df)
    {
        this.f = f;
        this.df = df;
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

        return x;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // створюємо екземпляр класу ChordMethod з використанням Object Methods
        ChordMethod cm = new ChordMethod(
            x => Math.Cos(x) - x,
            x => -Math.Sin(x));

        // знаходимо корінь рівняння методом хорд
        double root = cm.FindRoot(0, Math.PI / 2, 0.0001);

        Console.WriteLine("Root: " + root);
    }
}

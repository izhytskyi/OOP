using System;

public delegate double Function(double x); // делегат для функції
public delegate double DerivativeFunction(double x); // делегат для похідної функції

public class ChordMethod
{
    private Func<double, double> f; // поле для функції
    private Func<double, double> df; // поле для похідної функції

    public ChordMethod(Function f, DerivativeFunction df)
    {
        this.f = new Func<double, double>(f.Invoke);
        this.df = new Func<double, double>(df.Invoke);
    }

    public double FindRoot(double a, double b, double eps)
    {
        Func<double, double> func = new Func<double, double>(f.Invoke);
        Func<double, double> derivFunc = new Func<double, double>(df.Invoke);
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
        // створюємо екземпляр класу ChordMethod з використанням multicast делегатів та операцій зделегуваного об'єкта
        ChordMethod cm = new ChordMethod(
            new Function(x => Math.Cos(x) - x),
            new DerivativeFunction(x => -Math.Sin(x)));

        // знаходимо корінь рівняння методом хорд
        double root = cm.FindRoot(0, Math.PI / 2, 0.0001);

        Console.WriteLine("Root: " + root);
    }
}

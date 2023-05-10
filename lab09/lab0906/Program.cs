using System;

public delegate void RootFoundEventHandler(double root);


public class ChordMethod
{
    private Func<double, double> f; // поле для функції
    private Func<double, double> df; // поле для похідної функції
    private double eps; // поле для точності
    public event RootFoundEventHandler RootFoundEvent; // подія, яка сповіщає про знайдений корінь

    public ChordMethod(Func<double, double> f, Func<double, double> df, double eps)
    {
        this.f = f;
        this.df = df;
        this.eps = eps;
    }

    public void FindRoot(double a, double b)
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

        // сповіщаємо про знайдений корінь
        RootFoundEvent?.Invoke(x);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // створюємо екземпляр класу ChordMethod з використанням Event Handling
        ChordMethod cm = new ChordMethod(
            x => Math.Cos(x) - x,
            x => -Math.Sin(x),
            0.0001);

        // підписуємося на подію RootFoundEvent
        cm.RootFoundEvent += root =>
        {
            Console.WriteLine("Root: " + root);
        };

        // знаходимо корінь рівняння методом хорд
        cm.FindRoot(0, Math.PI / 2);
    }
}

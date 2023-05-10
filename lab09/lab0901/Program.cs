public delegate double Function(double x); // делегат для функції
public delegate double DerivativeFunction(double x); // делегат для похідної функції

public class ChordMethod
{
    public double FindRoot(Function f, DerivativeFunction df, double a, double b, double eps)
    {
        double fa = f(a);
        double fb = f(b);
        double x = a - fa * (b - a) / (fb - fa);

        while (Math.Abs(f(x)) > eps)
        {
            x = x - f(x) * (b - x) / (f(b) - f(x));
            if (Math.Abs(f(x)) < eps)
            {
                break;
            }
            x = x - f(x) * (x - a) / (f(x) - f(a));
        }

        return x;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // створюємо екземпляр класу ChordMethod
        ChordMethod cm = new ChordMethod();

        // передаємо функцію та її похідну як лямбда-вирази
        Function f = x => Math.Cos(x) - x;
        DerivativeFunction df = x => -Math.Sin(x) - 1;

        // знаходимо корінь рівняння за допомогою методу хорд
        double root = cm.FindRoot(f, df, 0, Math.PI / 2, 0.0001);

        // виводимо результат
        Console.WriteLine("Корiнь рiвняння Cos(x) - x = 0 на вiдрiзку [0, pi/2]: {0}", root);
    }
}

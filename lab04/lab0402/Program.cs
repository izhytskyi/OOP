using System;

namespace Quadrangles
{
    class TQuadrangle
    {
        protected double a, b, c, d;

        public TQuadrangle(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public virtual double CalculateArea()
        {
            return 0;
        }

        public virtual double CalculatePerimeter()
        {
            return 0;
        }

        public virtual void Display()
        {
            Console.WriteLine("Quadrangle: a={0}, b={1}, c={2}, d={3}", a, b, c, d);
        }
    }

    class Rectangle : TQuadrangle
    {
        public Rectangle(double a, double b) : base(a, b, a, b)
        {
        }

        public override double CalculateArea()
        {
            return a * b;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (a + b);
        }

        public override void Display()
        {
            Console.WriteLine("Rectangle: a={0}, b={1}", a, b);
        }
    }

    class Square : Rectangle
    {
        public Square(double a) : base(a, a)
        {
        }

        public override void Display()
        {
            Console.WriteLine("Square: a={0}", a);
        }
    }

    class Parallelogram : TQuadrangle
    {
        private double h;

        public Parallelogram(double a, double b, double h) : base(a, b, a, b)
        {
            this.h = h;
        }

        public override double CalculateArea()
        {
            return a * h;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (a + b);
        }

        public override void Display()
        {
            Console.WriteLine("Parallelogram: a={0}, b={1}, h={2}", a, b, h);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = 10;
            TQuadrangle[] quadrangles = new TQuadrangle[n];

            // Create n quadrangles: 4 rectangles, 4 squares, and 2 parallelograms
            for (int i = 0; i < n; i++)
            {
                switch (random.Next(3))
                {
                    case 0:
                        quadrangles[i] = new Rectangle(random.Next(1, 11), random.Next(1, 11));
                        break;
                    case 1:
                        quadrangles[i] = new Square(random.Next(1, 11));
                        break;
                    case 2:
                        quadrangles[i] = new Parallelogram(random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));
                        break;
                }
            }

            double totalRectangleArea = 0;
            double totalSquareArea = 0;
            double totalParallelogramPerimeter = 0;

            foreach (TQuadrangle quadrangle in quadrangles)
            {
                quadrangle.Display();
                if (quadrangle is Rectangle)
                {
                    totalRectangleArea += quadrangle.CalculateArea();
                }
                else if (quadrangle is Square)
                {
                    totalSquareArea += quadrangle.CalculateArea();
                }
                else if (quadrangle is Parallelogram)
                {
                    totalParallelogramPerimeter += quadrangle.CalculatePerimeter();
                }
            }

            Console.WriteLine("Total area of rectangles: {0}", totalRectangleArea);
            Console.WriteLine("Total area of squares: {0}", totalSquareArea);
            Console.WriteLine("Total perimeter of parallelograms: {0}", totalParallelogramPerimeter);

            Console.ReadLine();
        }
    }
}


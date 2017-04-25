using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Triangle: Figure
    {
        public double A { get; }

        public double B { get; }

        public double C { get; }


        public Triangle(double a, double b, double c)
        {
            if (!isTriangle(a, b, c))
                throw new ArgumentOutOfRangeException();
            A = a;
            B = b;
            C = c;
        }

        public override double Area()
        {
            double semiPerimeter = (A + B + C) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
        }

        public override double Perimeter()
        {
            return A + B + C;   
        }

        private bool isTriangle(double a, double b, double c)
        {
            return a < b + c && (b < a + c) && (c < a + b);
        }
    }
}

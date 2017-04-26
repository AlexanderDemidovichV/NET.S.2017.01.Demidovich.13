using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents behavior of Rectangle
    /// </summary>
    /// <seealso cref="Task3.Figure" />
    public class Rectangle: Figure
    {
        public double A { get; }

        public double B { get; }

        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentOutOfRangeException();

            A = a;
            B = b;
        }

        public override double Area()
        {
            return A * B;
        }

        public override double Perimeter()
        {
            return 2 * (A + B);
        }
    }
}

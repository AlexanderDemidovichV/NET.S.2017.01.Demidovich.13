using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Square: Figure
    {
        public double A { get; }

        public Square(double a)
        {
            if (a <= 0)
                throw new ArgumentOutOfRangeException();

            A = a;
        }

        public override double Area()
        {
            return A * A;
        }

        public override double Perimeter()
        {
            return 4 * A;
        }
    }
}

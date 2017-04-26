using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    public class PerimeterTests
    {
        [TestCase(1, ExpectedResult = Math.PI * 2)]
        [TestCase(2, ExpectedResult = Math.PI * 4)]
        [TestCase(3, ExpectedResult = Math.PI * 6)]
        public double Perimeter_CirclePerimeter(double radius) => (new Circle(radius)).Perimeter();

        [TestCase(1, ExpectedResult = 4)]
        [TestCase(2, ExpectedResult = 8)]
        [TestCase(3, ExpectedResult = 12)]
        public double Perimeter_SquarePerimeter(double side) => (new Square(side)).Perimeter();

        [TestCase(1, 2, ExpectedResult = 6)]
        [TestCase(3, 2, ExpectedResult = 10)]
        public double Perimeter_RectanglePerimeter(double length, double width) => (new Rectangle(length, width)).Perimeter();

        [TestCase(5, 4, 3, ExpectedResult = 12)]
        public double Perimeter_TrianglePerimeter(double a, double b, double c) => (new Triangle(a, b, c)).Perimeter();
    }
}

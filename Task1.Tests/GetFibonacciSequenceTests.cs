using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class GetFibonacciSequenceTests
    {
        [Test]
        public static void GetFibonacciSequence()
        {
            var expected = new List<long>() {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            var actual = new List<long>();
            int count = 0;
            foreach (var number in FibonacciNumber.GetFibonacciSequence())
            {
                actual.Add(number);
                if (++count == 10)
                    break;
            }
            Assert.AreEqual(expected,actual);
        }

    }
}

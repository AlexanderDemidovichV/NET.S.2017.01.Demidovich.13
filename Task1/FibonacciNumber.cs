using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class FibonacciNumber
    {
        public static IEnumerable<long> GetFibonacciSequence()
        {
            yield return 1;
            yield return 1;
            long a = 1;
            long b = 1;
            while (true)
            {
                long c;

                try
                {
                    c = unchecked(a + b);
                }
                catch (OverflowException ex)
                {
                    yield break;
                }
                a = b;
                b = c;
                yield return c;
            }
        }
    }
}

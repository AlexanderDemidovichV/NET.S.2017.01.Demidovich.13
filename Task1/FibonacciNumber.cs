using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    /// <summary>
    /// Provides methods to work with Fibonacci Numbers
    /// </summary>
    public static class FibonacciNumber
    {

        /// <summary>
        /// Gets the Fibonacci Numbers sequence.
        /// </summary>
        /// <returns>An IEnumerable whose elements are the Fibonacci Numbers.</returns>
        public static IEnumerable<long> GetFibonacciSequence()
        {
            yield return 1;
            yield return 1;
            long previous = 1;
            long current = 1;
            while (true)
            {
                long next;

                try
                {
                    next = unchecked(previous + current);
                }
                catch (OverflowException ex)
                {
                    yield break;
                }

                yield return next;
                previous = current;
                current = next;
            }
        }
    }
}

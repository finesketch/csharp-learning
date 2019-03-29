using System;
using System.Collections.Generic;

namespace csharp_learning.Dynamicprogrammingandrecursion
{
    public class Fibber
    {
        private Dictionary<int, int> _memo = new Dictionary<int, int>();

        public int Fib(int n)
        {
            // Edge case
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n),
                    "Index was negative. No such thing as a negative index in a series.");
            }

            // Base cases
            if (n == 0 || n == 1)
            {
                return n;
            }

            // See if we've already calculated this
            if (_memo.ContainsKey(n))
            {
                Console.WriteLine($"Grabbing _memo[{n}]");
                return _memo[n];
            }

            Console.WriteLine($"Computing Fib({n})");
            int result = Fib(n - 1) + Fib(n - 2);

            // Memoize
            _memo[n] = result;

            return result;
        }
    }
}

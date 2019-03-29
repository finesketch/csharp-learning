using System;
using Xunit;

namespace csharp_learning.Dynamicprogrammingandrecursion
{
    public partial class Solution
    {
        public static int Fib(int n)
        {
            // Edge cases:
            if (n < 0)
            {
                throw new ArgumentException("Index was negative. No such thing as a negative index in a series.");
            }

            if (n == 0 || n == 1)
            {
                return n;
            }

            // We'll be building the fibonacci series from the bottom up.
            // So we'll need to track the previous 2 numbers at each step.
            int prevPrev = 0;  // 0th fibonacci
            int prev = 1;      // 1st fibonacci
            int current = 0;   // Declare and initialize current

            for (int i = 1; i < n; i++)
            {
                // Iteration 1: current = 2nd fibonacci
                // Iteration 2: current = 3rd fibonacci
                // Iteration 3: current = 4th fibonacci
                // To get nth fibonacci ... do n-1 iterations.
                current = prev + prevPrev;
                prevPrev = prev;
                prev = current;
            }

            return current;
        }

        public static int Fib1(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return Fib1(n - 1) + Fib1(n - 2);
        }

        // Tests

        [Fact]
        public void BottonUpFib_ZerothFibonacciTest()
        {
            var actual = Fib(0);
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_FirstFibonacciTest()
        {
            var actual = Fib(1);
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_SecondFibonacciTest()
        {
            var actual = Fib(2);
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_ThirdFibonacciTest()
        {
            var actual = Fib(3);
            var expected = 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_FifthFibonacciTest()
        {
            var actual = Fib(5);
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_TenthFibonacciTest()
        {
            var actual = Fib(10);
            var expected = 55;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BottonUpFib_NegativeFibonacciTest()
        {
            Assert.Throws<ArgumentException>(() => Fib(-1));
        }
    }
}

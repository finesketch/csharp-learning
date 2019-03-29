using System;
using Xunit;
using System.Diagnostics;

namespace csharp_learning.Combinatoricsprobabilityandothermath
{
    public partial class Solution
    {
        static Random _rand = new Random();

        static int Rand5()
        {
            return _rand.Next(5) + 1;
        }

        public static int Rand7()
        {
            while (true)
            {
                // Do our die rolls
                int roll1 = Rand5();
                int roll2 = Rand5();

                int outcomeNumber = (roll1 - 1) * 5 + (roll2 - 1) + 1;

                // If we hit an extraneous
                // outcome we just re-roll
                if (outcomeNumber > 21)
                {
                    continue;
                }

                // Our outcome was fine. Return it!
                return outcomeNumber % 7 + 1;
            }
        }

        public static int Rand7Version2()
        {
            while (true)
            {
                // Do our die rolls
                int roll1 = Rand5();
                int roll2 = Rand5();
                int roll3 = Rand5();
                int roll4 = Rand5();
                int roll5 = Rand5();
                int roll6 = Rand5();
                int roll7 = Rand5();

                int outcomeNumber = roll1 + roll2 + roll3 + roll4 + roll5 + roll6 + roll7;

                return outcomeNumber % 7 + 1;
            }
        }

        [Fact]
        public void Rand7_Test()
        {
            string results = "";

            for (int i = 0; i < 100; i++)
            {
                int test = Rand7();
                results += test;

                Debug.WriteLine($"{test} ");
            }
            Assert.Contains("1", results);
            Assert.Contains("2", results);
            Assert.Contains("3", results);
            Assert.Contains("4", results);
            Assert.Contains("5", results);
            Assert.Contains("6", results);
            Assert.Contains("7", results);
        }

        [Fact]
        public void Rand7Version2_Test()
        {
            string results = "";

            for (int i = 0; i < 100; i++)
            {
                int test = Rand7Version2();
                results += test;

                Debug.WriteLine($"{test} ");
            }
            Assert.Contains("1", results);
            Assert.Contains("2", results);
            Assert.Contains("3", results);
            Assert.Contains("4", results);
            Assert.Contains("5", results);
            Assert.Contains("6", results);
            Assert.Contains("7", results);
        }
    }
}
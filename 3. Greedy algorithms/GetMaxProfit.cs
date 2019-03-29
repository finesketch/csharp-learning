using System;
using Xunit;

namespace csharp_learning.Greedyalgorithms
{
    public partial class Solution
    {
        public static int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices.Length < 2)
            {
                throw new ArgumentException("Getting a profit requires at least 2 prices",
                    nameof(stockPrices));
            }

            // We'll greedily update minPrice and maxProfit, so we initialize
            // them to the first price and the first possible profit
            int minPrice = stockPrices[0];
            int maxProfit = stockPrices[1] - stockPrices[0];

            // Start at the second (index 1) time.
            // We can't sell at the first time, since we must buy first,
            // and we can't buy and sell at the same time!
            // If we started at index 0, we'd try to buy *and* sell at time 0.
            // This would give a profit of 0, which is a problem if our
            // maxProfit is supposed to be *negative*--we'd return 0.
            for (int i = 1; i < stockPrices.Length; i++)
            {
                int currentPrice = stockPrices[i];

                // See what our profit would be if we bought at the
                // min price and sold at the current price
                int potentialProfit = currentPrice - minPrice;

                // Update maxProfit if we can do better
                maxProfit = Math.Max(maxProfit, potentialProfit);

                // Update minPrice so it's always
                // the lowest price we've seen so far
                minPrice = Math.Min(minPrice, currentPrice);
            }

            return maxProfit;
        }



        // Tests

        [Fact]
        public void GetMaxProfit_PriceGoesUpThenDownTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 5, 3, 2 });
            var expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMaxProfit_PriceGoesDownThenUpTest()
        {
            var actual = GetMaxProfit(new int[] { 7, 2, 8, 9 });
            var expected = 7;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMaxProfit_PriceGoesUpAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 6, 7, 9 });
            var expected = 8;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMaxProfit_PriceGoesDownAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 9, 7, 4, 1 });
            var expected = -2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMaxProfit_PriceStaysTheSameAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 1, 1, 1 });
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMaxProfit_ExceptionWithOnePriceTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { 5 }));
        }

        [Fact]
        public void GetMaxProfit_ExceptionWithEmptyPricesTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { }));
        }
    }
}

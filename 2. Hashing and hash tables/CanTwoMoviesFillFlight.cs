using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Hashingandhashtables
{
    public partial class Solution
    {
        public static bool CanTwoMoviesFillFlight(int[] movieLengths, int flightLength)
        {
            // Movie lengths we've seen so far
            var movieLengthsSeen = new HashSet<int>();

            foreach (var firstMovieLength in movieLengths)
            {
                int matchingSecondMovieLength = flightLength - firstMovieLength;
                if (movieLengthsSeen.Contains(matchingSecondMovieLength))
                {
                    return true;
                }

                movieLengthsSeen.Add(firstMovieLength);
            }

            // We never found a match, so return false
            return false;
        }


        // Tests

        [Fact]
        public void CanTwoMoviesFillFlight_ShortFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 1);
            Assert.False(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_LongFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 6);
            Assert.True(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_OnlyOneMovieHalfFlightLenghtTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8 }, 6);
            Assert.False(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_TwoMoviesHalfFlightLengthTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8, 3 }, 6);
            Assert.True(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_LotsOfPossiblePairsTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 1, 2, 3, 4, 5, 6 }, 7);
            Assert.True(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_NotUsingFirstMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 4, 3, 2 }, 5);
            Assert.True(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_OneMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 6 }, 6);
            Assert.False(result);
        }

        [Fact]
        public void CanTwoMoviesFillFlight_NoMoviesTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { }, 6);
            Assert.False(result);
        }
    }
}
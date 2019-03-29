using System;
using Xunit;

namespace csharp_learning.Arrayandstringmanipulation
{
    public partial class Solution
    {
        public static bool IsSingleRiffle(int[] half1, int[] half2, int[] shuffledDeck)
        {
            int half1Index = 0;
            int half2Index = 0;

            foreach (var card in shuffledDeck)
            {
                if (half1Index < half1.Length && card == half1[half1Index])
                {
                    // If we still have cards in half1 and the "top" card in half1 is the same
                    // as the top card in shuffledDeck
                    half1Index++;
                }
                else if (half2Index < half2.Length && card == half2[half2Index])
                {
                    // If we still have cards in half2 and the "top" card in half2 is the same
                    // as the top card in shuffledDeck
                    half2Index++;
                }
                else
                {
                    // If the top card in shuffledDeck doesn't match the top
                    // card in half1 or half2, this isn't a single riffle.
                    return false;
                }
            }

            // All cards in shuffledDeck have been accounted for.
            // So this is a single riffle!
            return true;
        }



        // Tests

        [Fact]
        public void IsSingleRiffle_BothHalvesAreTheSameLengthTest()
        {
            var half1 = new int[] { 1, 4, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 3, 4, 5, 6 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.True(result);
        }

        [Fact]
        public void IsSingleRiffle_HalvesAreDifferentLengthsTest()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 6, 3, 5 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }

        [Fact]
        public void IsSingleRiffle_OneHalfIsEmptyTest()
        {
            var half1 = new int[] { };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 2, 3, 6 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.True(result);
        }

        [Fact]
        public void IsSingleRiffle_ShuffledDeckIsMissingCardsTest()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 6, 3, 5 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }

        [Fact]
        public void IsSingleRiffle_ShuffledDeckHasExtraCards()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 3, 5, 6, 8 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }
    }
}
using System;
using Xunit;

namespace csharp_learning.Sortingsearchingandlogarithms
{
    public partial class Solution
    {
        public static int FindRotationPoint(string[] words)
        {
            string firstWord = words[0];

            int floorIndex = 0;
            int ceilingIndex = words.Length - 1;

            while (floorIndex < ceilingIndex)
            {
                // Guess a point halfway between floor and ceiling
                int guessIndex = floorIndex + ((ceilingIndex - floorIndex) / 2);

                // If guess comes after first word or is the first word
                if (string.Compare(words[guessIndex], firstWord, StringComparison.Ordinal) >= 0)
                {
                    // Go right
                    floorIndex = guessIndex;
                }
                else
                {
                    // Go left
                    ceilingIndex = guessIndex;
                }

                // If floor and ceiling have converged
                if (floorIndex + 1 == ceilingIndex)
                {
                    // Between floor and ceiling is where we flipped to the beginning,
                    // so ceiling is alphabetically first
                    break;
                }
            }

            return ceilingIndex;
        }


        // Tests

        [Fact]
        public void SmallArrayTest()
        {
            var actual = FindRotationPoint(new string[] { "cape", "cake" });
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MediumArrayTest()
        {
            var actual = FindRotationPoint(new string[] { "grape", "orange", "plum", "radish",
            "apple" });
            var expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LargeArrayTest()
        {
            var actual = FindRotationPoint(
                new string[] { "ptolemaic", "retrograde", "supplant", "undulate", "xenoepist",
            "asymptote", "babka", "banoffee", "engender", "karpatka", "othellolagkage" });
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PossiblyMissingEdgeCaseTest()
        {
            var actual = FindRotationPoint(
                new string[] { "k","v","a","b","c","d","e","g","i" });
            var expected = 2;
            Assert.Equal(expected, actual);
        }
    }
}

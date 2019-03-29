using System;
using Xunit;

namespace csharp_learning.Hashingandhashtables
{
    public partial class Solution
    {
        public static int[] SortScores(int[] unorderedScores, int highestPossibleScore)
        {
            // Array of 0s at indices 0..highestPossibleScore
            int[] scoreCounts = new int[highestPossibleScore + 1];

            // Populate scoreCounts
            foreach (var score in unorderedScores)
            {
                scoreCounts[score]++;
            }

            // Populate the final sorted array
            int[] sortedScores = new int[unorderedScores.Length];
            int currentSortedIndex = 0;

            // For each item in scoreCounts
            for (int score = highestPossibleScore; score >= 0; score--)
            {
                int count = scoreCounts[score];

                // For the number of times the item occurs
                for (int occurrence = 0; occurrence < count; occurrence++)
                {
                    // Add it to the sorted array
                    sortedScores[currentSortedIndex] = score;
                    currentSortedIndex++;
                }
            }

            return sortedScores;
        }


        // Tests

        [Fact]
        public void SortScores_NoScoresTest()
        {
            var scores = new int[] { };
            var expected = new int[] { };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortScores_OneScoreTest()
        {
            var scores = new int[] { 55 };
            var expected = new int[] { 55 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortScores_TwoScoresTest()
        {
            var scores = new int[] { 30, 60 };
            var expected = new int[] { 60, 30 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortScores_ManyScoresTest()
        {
            var scores = new int[] { 37, 89, 41, 65, 91, 53 };
            var expected = new int[] { 91, 89, 65, 53, 41, 37 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortScores_RepeatedScoresTest()
        {
            var scores = new int[] { 20, 10, 30, 30, 10, 20 };
            var expected = new int[] { 30, 30, 20, 20, 10, 10 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }
    }
}

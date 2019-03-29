using System;
using System.Linq;
using Xunit;

namespace csharp_learning.Greedyalgorithms
{
    public partial class Solution
    {
        public static int HighestProductOf3(int[] arrayOfInts)
        {
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Less than 3 items!", nameof(arrayOfInts));
            }

            // We're going to start at the 3rd item (at index 2)
            // so pre-populate highests and lowests based on the first 2 items.
            // We could also start these as null and check below if they're set
            // but this is arguably cleaner
            int highest = Math.Max(arrayOfInts[0], arrayOfInts[1]);
            int lowest = Math.Min(arrayOfInts[0], arrayOfInts[1]);

            int highestProductOf2 = arrayOfInts[0] * arrayOfInts[1];
            int lowestProductOf2 = arrayOfInts[0] * arrayOfInts[1];

            // Except this one--we pre-populate it for the first *3* items.
            // This means in our first pass it'll check against itself, which is fine.
            int highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];

            // Walk through items, starting at index 2
            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                int current = arrayOfInts[i];

                // Do we have a new highest product of 3?
                // It's either the current highest,
                // or the current times the highest product of two
                // or the current times the lowest product of two
                highestProductOf3 = Math.Max(Math.Max(
                    highestProductOf3,
                    current * highestProductOf2),
                    current * lowestProductOf2);

                // Do we have a new highest product of two?
                highestProductOf2 = Math.Max(Math.Max(
                    highestProductOf2,
                    current * highest),
                    current * lowest);

                // Do we have a new lowest product of two?
                lowestProductOf2 = Math.Min(Math.Min(
                    lowestProductOf2,
                    current * highest),
                    current * lowest);

                // Do we have a new highest?
                highest = Math.Max(highest, current);

                // Do we have a new lowest?
                lowest = Math.Min(lowest, current);
            }

            return highestProductOf3;
        }

        public static int HighestProductOf3Version2(int[] arrayOfInts)
        {
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Less than 3 items!", nameof(arrayOfInts));
            }

            var highest3Descending = arrayOfInts.ToList().OrderByDescending(m => m).Take(3);
            int highestProductOf3Descending = 1;

            foreach (var item in highest3Descending)
            {
                highestProductOf3Descending *= item;
            }

            var highest3Ascending = arrayOfInts.ToList().OrderBy(m => m).Take(3);
            int highestProductOf3Ascending = 1;

            foreach (var item in highest3Ascending)
            {
                highestProductOf3Ascending *= item;
            }

            return Math.Max(highestProductOf3Descending, highestProductOf3Ascending);
        }



        // Tests

        [Fact]
        public void HighestProductOf3_ShortArrayTest()
        {
            var actual = HighestProductOf3(new int[] { 1, 2, 3, 4 });
            var expected = 24;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3_LongerArrayTest()
        {
            var actual = HighestProductOf3(new int[] { 6, 1, 3, 5, 7, 8, 2 });
            var expected = 336;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3_ArrayHasOneNegativeTest()
        {
            var actual = HighestProductOf3(new int[] { -5, 4, 8, 2, 3 });
            var expected = 96;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3_ArrayHasTwoNegativesTest()
        {
            var actual = HighestProductOf3(new int[] { -10, 1, 3, 2, -10 });
            var expected = 300;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3_ArrayHasAllNegativesTest()
        {
            var actual = HighestProductOf3(new int[] { -5, -1, -3, -2 });
            var expected = -6;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3_ExceptionWithEmptyArrayTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { }));
        }

        [Fact]
        public void HighestProductOf3_ExceptionWithOneNumberTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { 1 }));
        }

        [Fact]
        public void HighestProductOf3_ExceptionWithTwoNumbersTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { 1, 1 }));
        }

        // Version2

        [Fact]
        public void HighestProductOf3Version2_ShortArrayTestVersion2()
        {
            var actual = HighestProductOf3Version2(new int[] { 1, 2, 3, 4 });
            var expected = 24;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3Version2_LongerArrayTestVersion2()
        {
            var actual = HighestProductOf3Version2(new int[] { 6, 1, 3, 5, 7, 8, 2 });
            var expected = 336;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3Version2_ArrayHasOneNegativeTestVersion2()
        {
            var actual = HighestProductOf3Version2(new int[] { -5, 4, 8, 2, 3 });
            var expected = 96;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3Version2_ArrayHasTwoNegativesTestVersion2()
        {
            var actual = HighestProductOf3Version2(new int[] { -10, 1, 3, 2, -10 });
            var expected = 300;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestProductOf3Version2_ArrayHasAllNegativesTestVersion2()
        {
            var actual = HighestProductOf3Version2(new int[] { -5, -1, -3, -2 });
            var expected = -6;
            Assert.Equal(expected, actual);
        }
    }
}

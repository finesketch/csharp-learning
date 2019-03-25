using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharp_learning.Sortingsearchingandlogarithms
{
    public partial class Solution
    {
        public static int FindRepeat(int[] numbers)
        {
            var numbersSeen = new HashSet<int>();

            foreach (int number in numbers)
            {
                if (numbersSeen.Contains(number))
                {
                    return number;
                }
                else
                {
                    numbersSeen.Add(number);
                }
            }

            // Whoops--no duplicate
            throw new InvalidOperationException("no duplicate!");
        }

        public static int FindRepeat2(int[] numbers)
        {
            for (int needle = 1; needle < numbers.Length; needle++)
            {
                bool hasBeenSeen = false;
                foreach (int number in numbers)
                {
                    if (number == needle)
                    {
                        if (hasBeenSeen)
                        {
                            return number;
                        }
                        else
                        {
                            hasBeenSeen = true;
                        }
                    }
                }
            }

            // Whoops--no duplicate
            throw new InvalidOperationException("no duplicate!");
        }

        public static int FindRepeat3(int[] numbers)
        {
            var duplicates = numbers.GroupBy(x => x).FirstOrDefault(g => g.Count() > 1);

            // Whoops--no duplicate
            if (duplicates == null)
            {
                throw new InvalidOperationException("no duplicate!");
            }
            else
            {
                return duplicates.First();
            }

        }

        public static int FindRepeat4(int[] items)
        {
            int floor = 1;
            int ceiling = items.Length - 1;

            while (floor < ceiling)
            {
                // Divide our range 1..n into an upper range and lower range
                // (such that they don't overlap)
                // Lower range is floor..midpoint
                // Upper range is midpoint+1..ceiling
                int midpoint = floor + (ceiling - floor) / 2;
                int lowerRangeFloor = floor;
                int lowerRangeCeiling = midpoint;
                int upperRangeFloor = midpoint + 1;
                int upperRangeCeiling = ceiling;

                // Count number of items in lower range
                int itemsInLowerRange = items.Count(item => item >= lowerRangeFloor && item <= lowerRangeCeiling);

                int distinctPossibleIntegersInLowerRange = lowerRangeCeiling - lowerRangeFloor + 1;

                if (itemsInLowerRange > distinctPossibleIntegersInLowerRange)
                {
                    // There must be a duplicate in the lower range
                    // so use the same approach iteratively on that range
                    floor = lowerRangeFloor;
                    ceiling = lowerRangeCeiling;
                }
                else
                {
                    // There must be a duplicate in the upper range
                    // so use the same approach iteratively on that range
                    floor = upperRangeFloor;
                    ceiling = upperRangeCeiling;
                }
            }

            // Floor and ceiling have converged
            // We found a number that repeats!
            return floor;
        }

        // Tests

        [Fact]
        public void FindRepeat_number_Test()
        {
            var actual = FindRepeat(new int[] { 1,2,3,4,5,6,7,8,9,0,5 });
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindRepeat2_number_Test()
        {
            var actual = FindRepeat2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 5 });
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindRepeat3_number_Test()
        {
            var actual = FindRepeat3(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 5 });
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindRepeat4_number_Test()
        {
            var actual = FindRepeat4(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 5, 2 });
            var expected = 2;
            Assert.Equal(expected, actual);
        }
    }
}

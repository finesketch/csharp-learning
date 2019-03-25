using System;
using Xunit;

namespace csharp_learning.Sortingsearchingandlogarithms
{
    public partial class Solution
    {
        public static bool BinarySearch(int target, int[] nums)
        {
            // See if target appears in nums

            // We think of floorIndex and ceilingIndex as "walls" around
            // the possible positions of our target, so by -1 below we mean
            // to start our wall "to the left" of the 0th index
            // (we *don't* mean "the last index").
            int floorIndex = -1;
            int ceilingIndex = nums.Length;

            // If there isn't at least 1 index between floor and ceiling,
            // we've run out of guesses and the number must not be present
            while (floorIndex + 1 < ceilingIndex)
            {
                // Find the index ~halfway between the floor and ceiling
                // We use integer division, so we'll never get a "half index"
                int distance = ceilingIndex - floorIndex;
                int halfDistance = distance / 2;

                int guessIndex = floorIndex + halfDistance;
                int guessValue = nums[guessIndex];

                if (guessValue == target)
                {
                    return true;
                }

                if (guessValue > target)
                {
                    // Target is to the left, so move ceiling to the left
                    ceilingIndex = guessIndex;
                }
                else
                {
                    // Target is to the right, so move floor to the right
                    floorIndex = guessIndex;
                }
            }

            return false;
        }

        // Tests

        [Fact]
        public void BinarySearch_Found()
        {
            var array = new int[] { 8, 2, 9, 22, 4, 5, 6, 7, 1, 3, 15 };
            var found = BinarySearch(15, array);
            Assert.True(found);
        }

        [Fact]
        public void BinarySearch_NotFound()
        {
            var array = new int[] { 8, 2, 9, 22, 4, 5, 6, 7, 1, 3, 15 };
            var found = BinarySearch(100, array);
            Assert.False(found);
        }
    }
}

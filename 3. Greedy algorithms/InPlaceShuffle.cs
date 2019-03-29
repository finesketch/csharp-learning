using System;
using Xunit;

namespace csharp_learning.Greedyalgorithms
{
    public partial class Solution
    {
        static Random _rand1 = new Random();

        static int GetRandom1(int floor, int ceiling)
        {
            return _rand1.Next(floor, ceiling + 1);
        }

        public static void InPlaceShuffle(int[] theArray)
        {
            // For each index in the array
            for (int firstIndex = 0; firstIndex < theArray.Length; firstIndex++)
            {
                // Grab a random other index
                int secondIndex = GetRandom1(0, theArray.Length - 1);

                // And swap the values
                if (secondIndex != firstIndex)
                {
                    int temp = theArray[firstIndex];
                    theArray[firstIndex] = theArray[secondIndex];
                    theArray[secondIndex] = temp;
                }
            }
        }

        [Fact]
        public void InPlaceShuffle_BothHalvesAreTheSameLengthTest()
        {
            var initial = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var shuffled = (int[])initial.Clone();
            InPlaceShuffle(shuffled);
            Assert.NotEqual(initial, shuffled);
        }
    }
}
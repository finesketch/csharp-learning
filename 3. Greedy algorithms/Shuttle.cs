using System;
using Xunit;

namespace csharp_learning.Greedyalgorithms
{
    public partial class Solution
    {
        static Random _rand = new Random();

        static int GetRandom(int floor, int ceiling)
        {
            return _rand.Next(floor, ceiling + 1);
        }

        public static void Shuffle(int[] theArray)
        {
            // If it's 1 or 0 items, just return
            if (theArray.Length <= 1)
            {
                return;
            }

            // Walk through from beginning to end
            for (int indexWeAreChoosingFor = 0;
                    indexWeAreChoosingFor < theArray.Length - 1; indexWeAreChoosingFor++)
            {
                // Choose a random not-yet-placed item to place there
                // (could also be the item currently in that spot).
                // Must be an item AFTER the current item, because the stuff
                // before has all already been placed
                int randomChoiceIndex = GetRandom(indexWeAreChoosingFor, theArray.Length - 1);

                // Place our random choice in the spot by swapping
                if (randomChoiceIndex != indexWeAreChoosingFor)
                {
                    int valueAtIndexWeChoseFor = theArray[indexWeAreChoosingFor];
                    theArray[indexWeAreChoosingFor] = theArray[randomChoiceIndex];
                    theArray[randomChoiceIndex] = valueAtIndexWeChoseFor;
                }
            }
        }

        // Tests

        [Fact]
        public void Shuffle_Testt()
        {
            var initial = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var shuffled = (int[])initial.Clone();
            Shuffle(shuffled);
            Console.WriteLine($"Initial array: [{string.Join(", ", initial)}]");
            Console.WriteLine($"Shuffled array: [{string.Join(", ", shuffled)}]");

            for (int i = 0; i < initial.Length - 1; i++)
            {
                Assert.NotEqual(initial[i], shuffled[i]);
            }
        }
    }
}

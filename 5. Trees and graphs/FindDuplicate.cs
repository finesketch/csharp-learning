﻿using System;
using Xunit;

namespace csharp_learning.Treesandgraphs
{
    public partial class Solution
    {
        public static int FindDuplicate(int[] intArray)
        {
            int n = intArray.Length - 1;

            // STEP 1: GET INSIDE A CYCLE
            // Start at position n + 1 and walk n steps to find a position guaranteed to be in a cycle
            int positionInCycle = n + 1;
            for (int i = 0; i < n; i++)
            {
                // We subtract 1 from the current position to step ahead:
                // the 2nd *position* in an array is *index* 1
                positionInCycle = intArray[positionInCycle - 1];
            }

            // STEP 2: FIND THE LENGTH OF THE CYCLE
            // Find the length of the cycle by remembering a position in the cycle
            // and counting the steps it takes to get back to that position
            int rememberedPositionInCycle = positionInCycle;
            int currentPositionInCycle = intArray[positionInCycle - 1];  // 1 step ahead
            int cycleStepCount = 1;

            while (currentPositionInCycle != rememberedPositionInCycle)
            {
                currentPositionInCycle = intArray[currentPositionInCycle - 1];
                cycleStepCount++;
            }

            // STEP 3: FIND THE FIRST NODE OF THE CYCLE
            // Start two pointers
            //   (1) at position n + 1
            //   (2) ahead of position n + 1 as many steps as the cycle's length
            int pointerStart = n + 1;
            int pointerAhead = n + 1;
            for (int i = 0; i < cycleStepCount; i++)
            {
                pointerAhead = intArray[pointerAhead - 1];
            }

            // Advance until the pointers are in the same position, which is the first node in the cycle
            while (pointerStart != pointerAhead)
            {
                pointerStart = intArray[pointerStart - 1];
                pointerAhead = intArray[pointerAhead - 1];
            }

            // Since there are multiple values pointing to the first node in the cycle,
            // its position is a duplicate in our array
            return pointerStart;
        }


        // Tests

        [Fact]
        public void FindDuplicate_JustTheRepeatedNumberTest()
        {
            var numbers = new int[] { 1, 1 };
            var expected = 1;
            var actual = FindDuplicate(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindDuplicate_ShortArrayTest()
        {
            var numbers = new int[] { 1, 2, 3, 2 };
            var expected = 2;
            var actual = FindDuplicate(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindDuplicate_MediumArrayTest()
        {
            var numbers = new int[] { 1, 2, 5, 5, 5, 5 };
            var expected = 5;
            var actual = FindDuplicate(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindDuplicate_LongArrayTest()
        {
            var numbers = new int[] { 4, 1, 4, 8, 3, 2, 7, 6, 5 };
            var expected = 4;
            var actual = FindDuplicate(numbers);
            Assert.Equal(expected, actual);
        }
    }
}
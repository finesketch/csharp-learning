using System;
using Xunit;

namespace csharp_learning.Arrayandstringmanipulation
{
    public partial class Solution
    {
        public static int[] MergeArrays(int[] myArray, int[] alicesArray)
        {
            var mergedArray = new int[myArray.Length + alicesArray.Length];

            int currentIndexAlices = 0;
            int currentIndexMine = 0;
            int currentIndexMerged = 0;

            while (currentIndexMerged < mergedArray.Length)
            {
                bool isMyArrayExhausted = currentIndexMine >= myArray.Length;
                bool isAlicesArrayExhausted = currentIndexAlices >= alicesArray.Length;

                // Case: next comes from my array
                // my array must not be exhausted, and EITHER
                // 1) ALice's array is exhausted, or
                // 2) the current element in my array is less then the current element in ALice's array
                if (!isMyArrayExhausted && (isAlicesArrayExhausted
                        || (myArray[currentIndexMine] < alicesArray[currentIndexAlices])))
                {
                    mergedArray[currentIndexMerged] = myArray[currentIndexMine];
                    currentIndexMine++;
                }
                else
                {
                    mergedArray[currentIndexMerged] = alicesArray[currentIndexAlices];
                    currentIndexAlices++;
                }

                currentIndexMerged++;
            }

            return mergedArray;
        }

        public static int[] MergeArrays1(int[] myArray, int[] alicesArray)
        {
            var mergedArray = new int[myArray.Length + alicesArray.Length];

            int currentIndexAlices = 0;
            int currentIndexMine = 0;
            int currentIndexMerged = 0;

            while (currentIndexMerged < mergedArray.Length)
            {
                if (currentIndexMine >= myArray.Length)
                {
                    // Case: my array is exhausted
                    mergedArray[currentIndexMerged] = alicesArray[currentIndexAlices];
                    currentIndexAlices++;
                }
                else if (currentIndexAlices >= alicesArray.Length)
                {
                    // Case: Alice's array is exhausted
                    mergedArray[currentIndexMerged] = myArray[currentIndexMine];
                    currentIndexMine++;
                }
                else if (myArray[currentIndexMine] < alicesArray[currentIndexAlices])
                {
                    // Case: my item is next
                    mergedArray[currentIndexMerged] = myArray[currentIndexMine];
                    currentIndexMine++;
                }
                else
                {
                    // Case: Alice's item is next
                    mergedArray[currentIndexMerged] = alicesArray[currentIndexAlices];
                    currentIndexAlices++;
                }

                currentIndexMerged++;
            }

            return mergedArray;
        }

        public int[] MergeSortedArrays(int[] myArray, int[] alicesArray)
        {
            var mergedArray = new int[myArray.Length + alicesArray.Length];
            myArray.CopyTo(mergedArray, 0);
            alicesArray.CopyTo(mergedArray, myArray.Length);
            Array.Sort(mergedArray);
            return mergedArray;
        }


        // Tests

        [Fact]
        public void MergeArrays_BothArraysAreEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { };
            var expected = new int[] { };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeArrays_FirstArrayIsEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { 1, 2, 3 };
            var expected = new int[] { 1, 2, 3 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeArrays_SecondArrayIsEmptyTest()
        {
            var myArray = new int[] { 5, 6, 7 };
            var alicesArray = new int[] { };
            var expected = new int[] { 5, 6, 7 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeArrays_BothArraysHaveSomeNumbersTest()
        {
            var myArray = new int[] { 2, 4, 6 };
            var alicesArray = new int[] { 1, 3, 7 };
            var expected = new int[] { 1, 2, 3, 4, 6, 7 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeArrays_ArraysAreDifferentLengthsTest()
        {
            var myArray = new int[] { 2, 4, 6, 8 };
            var alicesArray = new int[] { 1, 7 };
            var expected = new int[] { 1, 2, 4, 6, 7, 8 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }
    }
}
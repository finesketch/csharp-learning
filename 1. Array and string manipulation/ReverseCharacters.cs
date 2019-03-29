using System;
using Xunit;

namespace csharp_learning.Arrayandstringmanipulation
{
    public partial class Solution
    {

        public static void ReverseCharacters(char[] arrayOfChars)
        {
            int leftIndex = 0;
            int rightIndex = arrayOfChars.Length - 1;

            while (leftIndex < rightIndex)
            {
                // Swap characters
                char temp = arrayOfChars[leftIndex];
                arrayOfChars[leftIndex] = arrayOfChars[rightIndex];
                arrayOfChars[rightIndex] = temp;

                // Move towards middle
                leftIndex++;
                rightIndex--;
            }
        }



        // Tests

        [Fact]
        public void ReverseCharacters_EmptyStringTest()
        {
            var expected = "".ToCharArray();
            var actual = "".ToCharArray();
            ReverseCharacters(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseCharacters_SingleCharacterStringTest()
        {
            var expected = "A".ToCharArray();
            var actual = "A".ToCharArray();
            ReverseCharacters(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseCharacters_LongerStringTest()
        {
            var expected = "EDCBA".ToCharArray();
            var actual = "ABCDE".ToCharArray();
            ReverseCharacters(actual);
            Assert.Equal(expected, actual);
        }
    }
}

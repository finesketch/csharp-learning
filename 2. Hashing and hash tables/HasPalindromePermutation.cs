using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Hashingandhashtables
{
    public partial class Solution
    {
        public static bool HasPalindromePermutation(string theString)
        {
            // Track characters we've seen an odd number of times
            var unpairedCharacters = new HashSet<char>();

            foreach (char c in theString)
            {
                if (unpairedCharacters.Contains(c))
                {
                    unpairedCharacters.Remove(c);
                }
                else
                {
                    unpairedCharacters.Add(c);
                }
            }

            // The string has a palindrome permutation if it
            // has one or zero characters without a pair
            return unpairedCharacters.Count <= 1;
        }


        // Tests

        [Fact]
        public void HasPalindromePermutation_PermutationWithOddNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabcbcd");
            Assert.True(result);
        }

        [Fact]
        public void HasPalindromePermutation_PermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabccbdd");
            Assert.True(result);
        }

        [Fact]
        public void HasPalindromePermutation_NoPermutationWithOddNumberOfChars()
        {
            var result = HasPalindromePermutation("aabcd");
            Assert.False(result);
        }

        [Fact]
        public void HasPalindromePermutation_NoPermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabbcd");
            Assert.False(result);
        }

        [Fact]
        public void HasPalindromePermutation_EmptyStringTest()
        {
            var result = HasPalindromePermutation("");
            Assert.True(result);
        }

        [Fact]
        public void HasPalindromePermutation_OneCharacterStringTest()
        {
            var result = HasPalindromePermutation("a");
            Assert.True(result);
        }
    }
}
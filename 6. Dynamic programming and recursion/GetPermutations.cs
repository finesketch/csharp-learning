using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharp_learning.Dynamicprogrammingandrecursion
{
    public partial class Solution
    {
        public static ISet<string> GetPermutations(string inputString)
        {
            // Base case
            if (inputString.Length <= 1)
            {
                return new HashSet<string>() { inputString };
            }

            var allCharsExceptLast = inputString.Substring(0, inputString.Length - 1);
            char lastChar = inputString[inputString.Length - 1];

            // Recursive call: get all possible permutations for all chars except last
            var permutationsOfAllCharsExceptLast = GetPermutations(allCharsExceptLast);

            // Put the last char in all possible positions for each of the above permutations
            var permutations = new HashSet<string>();
            foreach (var permutationOfAllCharsExceptLast in permutationsOfAllCharsExceptLast)
            {
                for (int position = 0; position <= allCharsExceptLast.Length; position++)
                {
                    var permutation = permutationOfAllCharsExceptLast.Substring(0, position)
                        + lastChar + permutationOfAllCharsExceptLast.Substring(position);
                    permutations.Add(permutation);
                }
            }

            return permutations;
        }


        // Tests

        [Fact]
        public void EmptyStringTest()
        {
            var expected = new HashSet<string>() { "" };
            var actual = GetPermutations("");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneCharacterStringTest()
        {
            var expected = new HashSet<string>() { "a" };
            var actual = GetPermutations("a");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoCharacterStringTest()
        {
            var expected = new HashSet<string>() { "ab", "ba" };
            var actual = GetPermutations("ab");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeCharacterStringTest()
        {
            var expected = new HashSet<string>() { "abc", "acb", "bac", "bca", "cab", "cba" };
            var actual = GetPermutations("abc");
            Assert.Equal(expected, actual);
        }
    }
}

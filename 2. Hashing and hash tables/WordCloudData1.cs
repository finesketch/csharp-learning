using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Hashingandhashtables
{
    public partial class Solution
    {
        public class WordCloudData1
        {
            private Dictionary<string, int> _wordsToCounts = new Dictionary<string, int>();

            public IDictionary<string, int> WordsToCounts
            {
                get { return _wordsToCounts; }
            }

            public WordCloudData1(string inputString)
            {
                PopulateWordsToCounts(inputString);
            }

            private void PopulateWordsToCounts(string inputString)
            {
                // Count the frequency of each word
                int wordStartIndex = 0;
                int wordLength = 0;

                for (int i = 0; i < inputString.Length; i++)
                {
                    var character = inputString[i];

                    if (char.IsLetter(character))
                    {
                        if (wordLength == 0)
                        {
                            wordStartIndex = i;
                        }
                        wordLength++;
                    }
                    else if (character == ' ')
                    {
                        var word = AddWord(inputString, wordStartIndex, wordLength);
                        AddWordToDictionary(word);
                        wordLength = 0;
                    }

                    if (i == inputString.Length - 1)
                    {
                        var word = AddWord(inputString, wordStartIndex, wordLength);
                        AddWordToDictionary(word);
                    }
                }

            }

            public string AddWord(string inputString, int startIndex, int length)
            {
                return inputString.Substring(startIndex, length);
            }

            public void AddWordToDictionary(string word)
            {
                int count = 0;

                if (!string.IsNullOrEmpty(word))
                {
                    if (_wordsToCounts.TryGetValue(word.ToLower(), out count))
                    {
                        _wordsToCounts[word] = count++;
                    }
                    else
                    {
                        _wordsToCounts.Add(word, 1);
                    }
                }
            }
        }



        // Tests

        // There are lots of valid solutions for this one. You
        // might have to edit some of these tests if you made
        // different design decisions in your solution.

        [Fact]
        public void WordCloudData1_SimpleSentenceTest()
        {
            var text = "I like cake";
            var expected = new Dictionary<string, int>() { { "I", 1 }, { "like", 1 }, { "cake", 1 } };
            var actual = new WordCloudData1(text);
            Assert.Equal(expected, actual.WordsToCounts);
        }

    }
}

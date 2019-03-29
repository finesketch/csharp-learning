using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Systemdesign
{
    public partial class Solution
    {
        // Implement a trie and use it to efficiently store string
        public class TrieNode
        {
            private Dictionary<char, TrieNode> _nodeChildren = new Dictionary<char, TrieNode>();

            public bool HasChildNode(char character)
            {
                return _nodeChildren.ContainsKey(character);
            }

            public void MakeChildNode(char character)
            {
                _nodeChildren[character] = new TrieNode();
            }

            public TrieNode GetChildNode(char character)
            {
                return _nodeChildren[character];
            }
        }

        public class Trie
        {
            private const char EndOfWordMarker = '\0';

            private TrieNode _rootNode = new TrieNode();

            public bool AddWord(string word)
            {
                var currentNode = _rootNode;
                bool isNewWord = false;

                // Work downwards through the trie, adding nodes
                // as needed, and keeping track of whether we add
                // any nodes.
                foreach (var character in word)
                {
                    if (!currentNode.HasChildNode(character))
                    {
                        isNewWord = true;
                        currentNode.MakeChildNode(character);
                    }

                    currentNode = currentNode.GetChildNode(character);
                }

                // Explicitly mark the end of a word.
                // Otherwise, we might say a word is
                // present if it is a prefix of a different,
                // longer word that was added earlier.
                if (!currentNode.HasChildNode(EndOfWordMarker))
                {
                    isNewWord = true;
                    currentNode.MakeChildNode(EndOfWordMarker);
                }

                return isNewWord;
            }
        }


        // Tests

        [Fact]
        public void TrieTest()
        {
            var trie = new Trie();

            var result = trie.AddWord("catch");
            Assert.True(result);

            result = trie.AddWord("cakes");
            Assert.True(result);

            result = trie.AddWord("cake");
            Assert.True(result);

            result = trie.AddWord("cake");
            Assert.False(result);

            result = trie.AddWord("caked");
            Assert.True(result);

            result = trie.AddWord("catch");
            Assert.False(result);

            result = trie.AddWord("");
            Assert.True(result);

            result = trie.AddWord("");
            Assert.False(result);
        }
    }
}
using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Treesandgraphs
{
    public partial class Solution
    {
        private static string[] ReconstructPath(Dictionary<string, string> howWeReachedNodes,
                                        string startNode, string endNode)
        {
            var reversedShortestPath = new List<string>();

            // Start from the end of the path and work backwards
            var currentNode = endNode;

            while (currentNode != null)
            {
                reversedShortestPath.Add(currentNode);
                currentNode = howWeReachedNodes[currentNode];
            }

            // Reverse our path to get the right order
            // by flipping it around, in place
            reversedShortestPath.Reverse();
            return reversedShortestPath.ToArray();
        }

        public static string[] BfsGetPath(Dictionary<string, string[]> graph,
                                          string startNode, string endNode)
        {
            if (!graph.ContainsKey(startNode))
            {
                throw new ArgumentException("Start node not in graph", nameof(startNode));
            }
            if (!graph.ContainsKey(endNode))
            {
                throw new ArgumentException("End node not in graph", nameof(endNode));
            }

            var nodesToVisit = new Queue<string>();
            nodesToVisit.Enqueue(startNode);

            // Keep track of how we got to each node.
            // We'll use this to reconstruct the shortest path at the end.
            // We'll ALSO use this to keep track of which nodes we've already visited.
            var howWeReachedNodes = new Dictionary<string, string>();
            howWeReachedNodes.Add(startNode, null);

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Dequeue();

                // Stop when we reach the end node
                if (currentNode == endNode)
                {
                    return ReconstructPath(howWeReachedNodes, startNode, endNode);
                }

                foreach (var neighbor in graph[currentNode])
                {
                    if (!howWeReachedNodes.ContainsKey(neighbor))
                    {
                        nodesToVisit.Enqueue(neighbor);
                        howWeReachedNodes.Add(neighbor, currentNode);
                    }
                }
            }

            // If we get here, then we never found the end node
            // so there's NO path from startNode to endNode
            return null;
        }



        // Tests

        [Fact]
        public void BfsGetPath_TwoHopPath1Test()
        {
            var expected = new string[] { "a", "c", "e" };
            var actual = BfsGetPath(GetNetwork(), "a", "e");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_TwoHopPath2Test()
        {
            var expected = new string[] { "d", "a", "c" };
            var actual = BfsGetPath(GetNetwork(), "d", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_OneHopPath1Test()
        {
            var expected = new string[] { "a", "c" };
            var actual = BfsGetPath(GetNetwork(), "a", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_OneHopPath2Test()
        {
            var expected = new string[] { "f", "g" };
            var actual = BfsGetPath(GetNetwork(), "f", "g");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_OneHopPath3Test()
        {
            var expected = new string[] { "g", "f" };
            var actual = BfsGetPath(GetNetwork(), "g", "f");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_ZeroHopPath()
        {
            var expected = new string[] { "a" };
            var actual = BfsGetPath(GetNetwork(), "a", "a");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BfsGetPath_NoPathTest()
        {
            var actual = BfsGetPath(GetNetwork(), "a", "f");
            Assert.Null(actual);
        }

        [Fact]
        public void BfsGetPath_StartNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => BfsGetPath(GetNetwork(), "h", "a"));
        }

        [Fact]
        public void EndNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => BfsGetPath(GetNetwork(), "a", "h"));
        }

        private static Dictionary<string, string[]> GetNetwork()
        {
            return new Dictionary<string, string[]>()
        {
            { "a", new string[] { "b", "c", "d"} },
            { "b", new string[] { "a", "d" } },
            { "c", new string[] { "a", "e" } },
            { "d", new string[] { "a", "b" } },
            { "e", new string[] { "c" } },
            { "f", new string[] { "g" } },
            { "g", new string[] { "f" } },
        };
        }
    }
}

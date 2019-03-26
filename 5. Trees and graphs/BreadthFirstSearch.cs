using System;
using System.Collections.Generic;

namespace csharp_learning.Treesandgraphs
{
    public partial class solution
    {
        public static void Bfs(Dictionary<string, string[]> graph, string startNode, string endNode)
        {
            var nodesToVisit = new Queue<string>();
            nodesToVisit.Enqueue(startNode);

            // Keep track of what nodes we've already seen so we don't process them twice
            var nodesAlreadySeen = new HashSet<string>();
            nodesAlreadySeen.Add(startNode);

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Dequeue();

                // Stop when we reach the end node
                if (currentNode == endNode)
                {
                    // Found it!
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    if (!nodesAlreadySeen.Contains(neighbor))
                    {
                        nodesAlreadySeen.Add(neighbor);
                        nodesToVisit.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}

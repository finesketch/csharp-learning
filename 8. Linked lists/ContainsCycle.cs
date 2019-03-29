using System;
using Xunit;

namespace csharp_learning.Linkedlists
{
    public partial class Solution
    {
        public class LinkedListNode
        {
            public int Value { get; set; }

            public LinkedListNode Next { get; set; }

            public LinkedListNode(int value)
            {
                Value = value;
            }
        }

        public static bool ContainsCycle(LinkedListNode firstNode)
        {
            // Start both runners at the beginning
            var slowRunner = firstNode;
            var fastRunner = firstNode;

            // Until we hit the end of the list
            while (fastRunner != null && fastRunner.Next != null)
            {
                slowRunner = slowRunner.Next;
                fastRunner = fastRunner.Next.Next;

                // Case: fastRunner is about to "lap" slowRunner
                if (fastRunner == slowRunner)
                {
                    return true;
                }
            }

            // Case: fastRunner hit the end of the list
            return false;
        }







        // Tests

        [Fact]
        public void ContainsCycle_LinkedListWithNoCycleTest()
        {
            var nodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
            var result = ContainsCycle(nodes[0]);
            Assert.False(result);
        }

        [Fact]
        public void ContainsCycle_CycleLoopsToBeginningTest()
        {
            var nodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
            nodes[3].Next = nodes[0];
            var result = ContainsCycle(nodes[0]);
            Assert.True(result);
        }

        [Fact]
        public void ContainsCycle_CycleLoopsToMiddleTest()
        {
            var nodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4, 5 });
            nodes[4].Next = nodes[2];
            var result = ContainsCycle(nodes[0]);
            Assert.True(result);
        }

        [Fact]
        public void ContainsCycle_TwoNodeCycleAtEndTest()
        {
            var nodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4, 5 });
            nodes[4].Next = nodes[3];
            var result = ContainsCycle(nodes[0]);
            Assert.True(result);
        }

        [Fact]
        public void ContainsCycle_EmptyListTest()
        {
            var result = ContainsCycle(null);
            Assert.False(result);
        }

        [Fact]
        public void ContainsCycle_OneElementLinkedListNoCycleTest()
        {
            var node = new LinkedListNode(1);
            var result = ContainsCycle(node);
            Assert.False(result);
        }

        [Fact]
        public void ContainsCycle_OneElementLinkedListCycleTest()
        {
            var node = new LinkedListNode(1);
            node.Next = node;
            var result = ContainsCycle(node);
            Assert.True(result);
        }

        private static LinkedListNode[] ValuesToLinkedListNodes(int[] values)
        {
            var nodes = new LinkedListNode[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                nodes[i] = new LinkedListNode(values[i]);
                if (i > 0)
                {
                    nodes[i - 1].Next = nodes[i];
                }
            }
            return nodes;
        }
    }
}
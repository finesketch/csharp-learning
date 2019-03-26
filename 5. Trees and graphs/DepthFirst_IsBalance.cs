using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Treesandgraphs
{
    public partial class Solution
    {
        public class NodeDepthPair
        {
            public BinaryTreeNode Node { get; }

            public int Depth { get; }

            public NodeDepthPair(BinaryTreeNode node, int depth)
            {
                Node = node;
                Depth = depth;
            }
        }

        public class BinaryTreeNode
        {
            public int Value { get; }
            public BinaryTreeNode Left { get; private set; }
            public BinaryTreeNode Right { get; private set; }

            public BinaryTreeNode(int value)
            {
                Value = value;
            }

            public BinaryTreeNode InsertLeft(int leftValue)
            {
                Left = new BinaryTreeNode(leftValue);
                return Left;
            }

            public BinaryTreeNode InsertRight(int rightValue)
            {
                Right = new BinaryTreeNode(rightValue);
                return Right;
            }
        }

        public static bool IsBalanced(BinaryTreeNode treeRoot)
        {

            // a tree with no nodes is superbalanced, since there are no leaves!
            if (treeRoot == null)
            {
                return true;
            }

            var depths = new List<int>(3);  // We short-circuit as soon as we find more than 2

            // Nodes will store pairs of a node and the node's depth
            var nodes = new Stack<NodeDepthPair>();
            nodes.Push(new NodeDepthPair(treeRoot, 0));

            while (nodes.Count > 0)
            {
                // Pop a node and its depth from the top of our stack
                var nodeDepthPair = nodes.Pop();
                var node = nodeDepthPair.Node;
                var depth = nodeDepthPair.Depth;

                if (node.Left == null && node.Right == null)
                {
                    // Case: we found a leaf

                    // We only care if it's a new depth
                    if (!depths.Contains(depth))
                    {
                        depths.Add(depth);

                        // Two ways we might now have an unbalanced tree:
                        //   1) more than 2 different leaf depths
                        //   2) 2 leaf depths that are more than 1 apart
                        if (depths.Count > 2
                            || (depths.Count == 2 && Math.Abs(depths[0] - depths[1]) > 1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    // Case: this isn't a leaf - keep stepping down

                    if (node.Left != null)
                    {
                        nodes.Push(new NodeDepthPair(node.Left, depth + 1));
                    }

                    if (node.Right != null)
                    {
                        nodes.Push(new NodeDepthPair(node.Right, depth + 1));
                    }
                }
            }

            return true;
        }


        // Tests

        [Fact]
        public void IsBalanced_FullTreeTest()
        {
            var root = new BinaryTreeNode(5);
            var a = root.InsertLeft(8);
            var b = root.InsertRight(6);
            a.InsertLeft(1);
            a.InsertRight(2);
            b.InsertLeft(3);
            b.InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_BothLeavesAtTheSameDepthTest()
        {
            var root = new BinaryTreeNode(3);
            root.InsertLeft(4).InsertLeft(1);
            root.InsertRight(2).InsertRight(9);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_LeafHeightsDifferByOneTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_LeafHeightsDifferByTwoTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7).InsertRight(8);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBalanced_BothSubTreesSuperbalancedTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertLeft(5);
            var b = root.InsertRight(9);
            b.InsertLeft(8).InsertLeft(7);
            b.InsertRight(5);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBalanced_OnlyOneNodeTest()
        {
            var root = new BinaryTreeNode(1);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_TreeIsLinkedListTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertRight(2).InsertRight(3).InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }
    }
}
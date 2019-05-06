using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Treesandgraphs
{
    public partial class Solution
    {
        public class NodeBounds
        {
            public BinaryTreeNode Node { get; }

            public int LowerBound { get; }

            public int UpperBound { get; }

            public NodeBounds(BinaryTreeNode node, int lowerBound, int upperBound)
            {
                Node = node;
                LowerBound = lowerBound;
                UpperBound = upperBound;
            }
        }

        public bool IsBinarySearchTree(BinaryTreeNode root)
        {
            // Start at the root, with an arbitrarily low lower bound
            // and an arbitrarily high upper bound
            var nodeAndBoundsStack = new Stack<NodeBounds>();
            nodeAndBoundsStack.Push(new NodeBounds(root, int.MinValue, int.MaxValue));

            // Depth-first traversal
            while (nodeAndBoundsStack.Count > 0)
            {
                var nb = nodeAndBoundsStack.Pop();
                var node = nb.Node;
                var lowerBound = nb.LowerBound;
                var upperBound = nb.UpperBound;

                // If this node is invalid, we return false right away
                if (node.Value <= lowerBound || node.Value >= upperBound)
                {
                    return false;
                }

                if (node.Left != null)
                {
                    // This node must be less than the current node
                    nodeAndBoundsStack.Push(new NodeBounds(node.Left, lowerBound, node.Value));
                }

                if (node.Right != null)
                {
                    // This node must be greater than the current node
                    nodeAndBoundsStack.Push(new NodeBounds(node.Right, node.Value, upperBound));
                }
            }

            // If none of the nodes were invalid, return true
            // (at this point we have checked all nodes)
            return true;
        }

        public bool IsBinarySearchTree2(BinaryTreeNode root)
        {
            return IsBinarySearchTree2(root, int.MinValue, int.MaxValue);
        }

        public bool IsBinarySearchTree2(BinaryTreeNode root, int lowerBound, int upperBound)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Value >= upperBound || root.Value <= lowerBound)
            {
                return false;
            }

            return IsBinarySearchTree2(root.Left, lowerBound, root.Value)
                   && IsBinarySearchTree2(root.Right, root.Value, upperBound);
        }

        public static bool IsBinarySearchTree3(BinaryTreeNode root)
        {
            // Determine if the tree is a valid binary search tree
            if (root == null)
            {
                return true;
            }

            var stack = new Stack<BinaryTreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var lower = node?.Left?.Value;
                var upper = node?.Right?.Value;

                if (node.Value <= lower || node.Value >= upper)
                {
                    return false;
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
            }


            return true;
        }


        // Tests

        [Fact]
        public void IsBinarySearchTree_ValidFullTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree_BothSubtreesValidTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(20);
            a.InsertRight(60);
            var b = root.InsertRight(80);
            b.InsertLeft(70);
            b.InsertRight(90);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree_DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20).InsertLeft(10);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree_OutOfOrderLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(70).InsertRight(60).InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree_OneNodeTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        // version 2

        [Fact]
        public void IsBinarySearchTree2_ValidFullTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var result = IsBinarySearchTree2(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree2_BothSubtreesValidTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(20);
            a.InsertRight(60);
            var b = root.InsertRight(80);
            b.InsertLeft(70);
            b.InsertRight(90);
            var result = IsBinarySearchTree2(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree2_DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20).InsertLeft(10);
            var result = IsBinarySearchTree2(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree2_OutOfOrderLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(70).InsertRight(60).InsertRight(80);
            var result = IsBinarySearchTree2(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree2_OneNodeTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var result = IsBinarySearchTree2(root);
            Assert.True(result);
        }

        // version 3

        [Fact]
        public void IsBinarySearchTree3_ValidFullTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var result = IsBinarySearchTree3(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree3_BothSubtreesValidTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(20);
            a.InsertRight(60);
            var b = root.InsertRight(80);
            b.InsertLeft(70);
            b.InsertRight(90);
            var result = IsBinarySearchTree3(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree3_DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20).InsertLeft(10);
            var result = IsBinarySearchTree3(root);
            Assert.True(result);
        }

        [Fact]
        public void IsBinarySearchTree3_OutOfOrderLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(70).InsertRight(60).InsertRight(80);
            var result = IsBinarySearchTree3(root);
            Assert.False(result);
        }

        [Fact]
        public void IsBinarySearchTree3_OneNodeTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var result = IsBinarySearchTree3(root);
            Assert.True(result);
        }
    }
}
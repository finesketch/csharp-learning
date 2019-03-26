using System;
using Xunit;

namespace csharp_learning.Treesandgraphs
{
    public partial class Solution
    {
        public int FindLargest(BinaryTreeNode rootNode)
        {
            if (rootNode == null)
            {
                throw new ArgumentNullException(nameof(rootNode), "Tree must have at least 1 node");
            }

            if (rootNode.Right != null)
            {
                return FindLargest(rootNode.Right);
            }

            return rootNode.Value;
        }

        public int FindSecondLargest(BinaryTreeNode rootNode)
        {
            if (rootNode == null
                || (rootNode.Left == null && rootNode.Right == null))
            {
                throw new ArgumentException("Tree must have at least 2 nodes", nameof(rootNode));
            }

            // Case: we're currently at largest, and largest has a left subtree,
            // so 2nd largest is largest in said subtree
            if (rootNode.Left != null && rootNode.Right == null)
            {
                return FindLargest(rootNode.Left);
            }

            // Case: we're at parent of largest, and largest has no left subtree,
            // so 2nd largest must be current node
            if (rootNode.Right != null
                && rootNode.Right.Left == null
                && rootNode.Right.Right == null)
            {
                return rootNode.Value;
            }

            // Otherwise: step right
            return FindSecondLargest(rootNode.Right);
        }




        // Tests

        [Fact]
        public void FindSecondLargest_FindSecondLargestTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var actual = FindSecondLargest(root);
            var expected = 70;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_LargestHasLeftChildTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            root.InsertRight(70).InsertLeft(60);
            var actual = FindSecondLargest(root);
            var expected = 60;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_LargestHasLeftSubtreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70).InsertLeft(60);
            b.InsertLeft(55).InsertRight(58);
            b.InsertRight(65);
            var actual = FindSecondLargest(root);
            var expected = 65;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_SecondLargestIsRootNodeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            root.InsertRight(70);
            var actual = FindSecondLargest(root);
            var expected = 50;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20);
            var actual = FindSecondLargest(root);
            var expected = 40;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_AscendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(60).InsertRight(70).InsertRight(80);
            var actual = FindSecondLargest(root);
            var expected = 70;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindSecondLargest_ExceptionWithTreeThatHasOneNodeTest()
        {
            var root = new BinaryTreeNode(50);
            Assert.Throws<ArgumentException>(() => FindSecondLargest(root));
        }

        [Fact]
        public void FindSecondLargest_ExceptionWithEmptyTreeTest()
        {
            Assert.Throws<ArgumentException>(() => FindSecondLargest(null));
        }
    }
}
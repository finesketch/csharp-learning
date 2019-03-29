using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_learning.Queuesandstacks
{
    public class Solution
    {
        // Fill in the definitions for Enqueue() and Dequeue()


        public class QueueTwoStacks
        {
            private Stack<int> _inStack = new Stack<int>();
            private Stack<int> _outStack = new Stack<int>();

            public void Enqueue(int item)
            {
                _inStack.Push(item);
            }

            public int Dequeue()
            {
                if (_outStack.Count == 0)
                {
                    // Move items from inStack to outStack, reversing order
                    while (_inStack.Count > 0)
                    {
                        int newestInStackItem = _inStack.Pop();
                        _outStack.Push(newestInStackItem);
                    }

                    // If outStack is still empty, raise an error
                    if (_outStack.Count == 0)
                    {
                        throw new InvalidOperationException("Can't dequeue from empty queue!");
                    }
                }

                return _outStack.Pop();
            }
        }



        // Tests

        [Fact]
        public void QueueTwoStacks_BasicQueueOperationsTest()
        {
            var q = new QueueTwoStacks();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Assert.Equal(1, q.Dequeue());
            Assert.Equal(2, q.Dequeue());
            q.Enqueue(4);
            Assert.Equal(3, q.Dequeue());
            Assert.Equal(4, q.Dequeue());
        }

        [Fact]
        public void QueueTwoStacks_ExceptionWhenDequeueFromNewQueueTest()
        {
            var q = new QueueTwoStacks();
            Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        }

        [Fact]
        public void QueueTwoStacks_ExceptionWhenDequeueFromEmptyQueueTest()
        {
            var q = new QueueTwoStacks();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Dequeue();
            q.Dequeue();
            Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        }
    }
}
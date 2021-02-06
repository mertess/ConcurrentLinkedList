using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ConcurrentLinkedListLib;
using Xunit;

namespace ConcurrentLinkedList.Tests
{
    public class ConcurrentLinkedListTests
    {
        [Fact]
        public void AddFirstByItemParamResultNodeHasNoOneNodePrev()
        {
            var list = new ConcurrentLinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(5);
            list.AddFirst(3);
            var node = list.AddFirst(7);

            Assert.NotNull(list._root);
            Assert.Null(node.Prev);
            Assert.NotNull(list.First);
            Assert.Equal(7, list.First.Value);
        }

        [Fact]
        public void AddLastByItemResultNodeHasNoOneNodeNext()
        {
            var list = new ConcurrentLinkedList<int>();

            list.AddLast(10);
            list.AddLast(5);
            list.AddLast(6);
            var node = list.AddLast(11);

            Assert.NotNull(list._root);
            Assert.Null(node.Next);
            Assert.NotNull(list.Last);
            Assert.Equal(11, list.Last.Value);
        }

        [Fact]
        public void AddLastByItemIsNodeResultNodeHasNoOneNodeNext()
        {
            var list = new ConcurrentLinkedList<int>();
            var node = new ConcurrentLinkedListNode<int>() { Value = 10 };

            list.AddLast(node);

            Assert.NotNull(list._root);
            Assert.Null(node.Next);
        }

        [Fact]
        public void AddLastByItemIsNodeResultNodeHasNoOneNodePrev()
        {
            var list = new ConcurrentLinkedList<int>();
            var node = new ConcurrentLinkedListNode<int>() { Value = 10 };

            list.AddFirst(node);

            Assert.NotNull(list._root);
            Assert.Null(node.Prev);
        }

        [Fact]
        public void AddBeforeIsNotContainsNodes()
        {
            var list = new ConcurrentLinkedList<int>();

            Assert.Throws<Exception>(() => list.AddBefore(new ConcurrentLinkedListNode<int>(), 10));
        }

        [Fact]
        public void AddBeforeIsNotContainsTargetNodeThenAddedValueAsNewFirstNode()
        {
            var list = new ConcurrentLinkedList<int>();

            list.AddLast(10);
            var newNode = list.AddBefore(new ConcurrentLinkedListNode<int>(), 35);

            Assert.Equal(newNode, list.First);
        }

        [Fact]
        public void AddBeforeContainsTargetNode()
        {
            var list = new ConcurrentLinkedList<int>();

            var node = list.AddLast(10);
            var addedNode = list.AddBefore(node, 35);

            Assert.Equal(addedNode, node.Prev);
        }

        [Fact]
        public void AddBeforeContainsTargetNodeButHeIsFirst()
        {
            var list = new ConcurrentLinkedList<int>();

            var node = list.AddLast(10);
            var addedNode = list.AddBefore(node, 35);

            Assert.Equal(addedNode, list.First);
        }

        [Fact]
        public void AddAfterIsNotContainsNodes()
        {
            var list = new ConcurrentLinkedList<int>();

            Assert.Throws<Exception>(() => list.AddAfter(new ConcurrentLinkedListNode<int>(), 10));
        }

        [Fact]
        public void AddAfterIsNotContainsTargetNodeThenAddedValueAsNewLastNode()
        {
            var list = new ConcurrentLinkedList<int>();

            list.AddLast(10);
            var newNode = list.AddAfter(new ConcurrentLinkedListNode<int>(), 35);

            Assert.Equal(newNode, list.Last);
        }

        [Fact]
        public void AddAfterContainsTargetNode()
        {
            var list = new ConcurrentLinkedList<int>();

            var node = list.AddLast(10);
            var addedNode = list.AddAfter(node, 35);

            Assert.Equal(addedNode, node.Next);
        }

        [Fact]
        public void AddAfterContainsTargetNodeButHeIsLast()
        {
            var list = new ConcurrentLinkedList<int>();

            var node = list.AddLast(10);
            var addedNode = list.AddAfter(node, 35);

            Assert.Equal(addedNode, list.Last);
        }
    }
}

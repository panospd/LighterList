﻿using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class AddBefore
    {
        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemBeforeMatchingNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddBefore(node => node.Value == 2, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(2, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndWithNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddBefore(node => node.Value == 8, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndWithEmptyList_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>();

            sut.AddBefore(node => node.Value == 1, 10);

            var first = sut.Head;
            Assert.AreEqual(10, first.Value);
            Assert.IsNull(first.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldInsertItemBeforeMatchingNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });
            var first = sut.Head;

            sut.AddBefore(first.Next.Next, 10);

            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndWithNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });
            var node = new ChainedNode<int>(10);

            sut.AddBefore(node, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithHead_ShouldInsertItemAtStart()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddBefore(sut.Head, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(1, second.Value);
            Assert.AreEqual(2, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }
    }
}

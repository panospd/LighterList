﻿using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class RemoveAll
    {
        [Test]
        public void WhenCalledWithSpecificNodes_ShouldRemoveNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveAll(new List<ChainedNode<int>> { sut.Head, sut.Head.Next });

            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(4, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.IsNull(second.Next);
        }

        [Test]
        public void WhenCalledWithSpecificElements_ShouldRemoveFirstMatchingNodesContainingElements()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10, 1, 4 });

            sut.RemoveAll(new List<int> { 1, 4 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(1, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithNonConsecutiveNodes_ShouldRemoveNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveAll(new List<ChainedNode<int>> { sut.Head, sut.Head.Next.Next });

            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.IsNull(second.Next);
        }

        [Test]
        public void WhenCalledWithSpecificNodesAndContainNoMatching_ShouldRemoveOnlyMatchingNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveAll(new List<ChainedNode<int>> { sut.Head, sut.Head.Next.Next, new ChainedNode<int>(2)});

            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.IsNull(second.Next);
        }

        [Test]
        public void WhenCalledWithSpecificNodesAndListEmpty_ShouldRemoveNodes()
        {
            var sut = new ChainedList<int>();

            sut.RemoveAll(new List<ChainedNode<int>> { sut.Head });

            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void WhenCalledWithNoNodes_ShouldRemoveAllNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Clear();

            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void WhenCalledWithElementPredicate_ShouldRemoveAllMatchingNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10, 1, 4 });

            sut.RemoveAll(v => v == 1 || v == 4);

            Assert.AreEqual(2, sut.Count);
            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.IsNull(second.Next);
        }

        [Test]
        public void WhenCalledWithElementPredicateAndMatchingNodesAreConsecutive_ShouldRemoveAllMatchingNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10, 1, 4 });

            sut.RemoveAll(v => v == 1 || v == 2);

            Assert.AreEqual(3, sut.Count);
            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(4, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithElementPredicateAndNoMatch_ShouldNotRemoveAnyElement()
        {
            var sut = new ChainedList<int>(new List<int> { 2, 10 });

            sut.RemoveAll(v => v == 1 || v == 4);

            Assert.AreEqual(2, sut.Count);
            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.IsNull(second.Next);
        }
    }
}

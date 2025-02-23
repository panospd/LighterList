﻿using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class AddAtStart
    {
        [Test]
        public void WhenCalled_ShouldInsertItemAtStart()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddAtStart(10);

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

        [Test]
        public void WhenListIsEmpty_ShouldInsertItemAtStart()
        {
            var sut = new ChainedList<int>();

            sut.AddAtStart(10);

            Assert.AreEqual(10, sut.Head.Value);
            Assert.IsNull(sut.Head.Next);
        }
    }
}

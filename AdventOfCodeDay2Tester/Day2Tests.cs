using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using AdventOfCodeDay2;
using NUnit.Framework.Internal.Execution;
using System.Collections.Generic;

namespace AdventOfCodeDay2Tester
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<int> addKeycode = new List<int>() { 1, 0, 0, 0 };
            Assert.AreEqual(2, Day2.AddValues(addKeycode[1], addKeycode[2], addKeycode));
        }

        [Test]
        public void Test2()
        {
            List<int> multiplyKeycode = new List<int>() { 1, 0, 0, 0 };
            Assert.AreEqual(1, Day2.MultiplyValues(multiplyKeycode[1], multiplyKeycode[2], multiplyKeycode));
        }

        [Test]
        public void Test3()
        {
            List<int> startingKeycode = new List<int>() { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            List<int> endKeycode = new List<int>() { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };
            Assert.AreEqual(endKeycode, Day2.IterateThroughIntcode(startingKeycode));
        }

        [Test]
        public void Test4()
        {
            List<int> startingKeycode = new List<int>() { 1, 0, 0, 0, 99 };
            List<int> endKeycode = new List<int>() { 2, 0, 0, 0, 99 };
            Assert.AreEqual(endKeycode, Day2.IterateThroughIntcode(startingKeycode));
        }

        [Test]
        public void Test5()
        {
            List<int> startingKeycode = new List<int>() { 2, 3, 0, 3, 99 };
            List<int> endKeycode = new List<int>() { 2, 3, 0, 6, 99 };
            Assert.AreEqual(endKeycode, Day2.IterateThroughIntcode(startingKeycode));
        }

        [Test]
        public void Test6()
        {
            List<int> startingKeycode = new List<int>() { 2, 4, 4, 5, 99, 0 };
            List<int> endKeycode = new List<int>() { 2, 4, 4, 5, 99, 9801 };
            Assert.AreEqual(endKeycode, Day2.IterateThroughIntcode(startingKeycode));
        }

        [Test]
        public void Test7()
        {
            List<int> startingKeycode = new List<int>() { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            List<int> endKeycode = new List<int>() { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
            Assert.AreEqual(endKeycode, Day2.IterateThroughIntcode(startingKeycode));
        }
    }
}
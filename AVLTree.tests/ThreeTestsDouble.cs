using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree.tests
{
    class ThreeTestsDouble
    {
        Tree<double> avlTreeInt;
        [SetUp]
        public void Setup()
        {
            avlTreeInt = new Tree<double>();

            avlTreeInt.Add(1.9);
            avlTreeInt.Add(12.2);
            avlTreeInt.Add(11.1);
            avlTreeInt.Add(15.5);
            avlTreeInt.Add(2.6);
            avlTreeInt.Add(18.1);
            avlTreeInt.Add(1.9);
            avlTreeInt.Add(12.3);
            avlTreeInt.Add(2.4);
            avlTreeInt.Add(11.2);
        }

        [TestCase(22, true)]
        [TestCase(2.7, true)]
        [TestCase(0, true)]
        public void AddTest(double value, bool expected)
        {
            avlTreeInt.Add(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(12.2, false)]
        [TestCase(18.1, false)]
        [TestCase(1.9, true)]
        public void RemoveTest(double value, bool expected)
        {
            avlTreeInt.Remove(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(47, false)]

        public void ClearTest(double value, bool expected)
        {
            avlTreeInt.Add(value);
            avlTreeInt.Clear();
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree.tests
{
    class ThreeTestsString
    {
        Tree<string> avlTreeInt;
        [SetUp]
        public void Setup()
        {
            avlTreeInt = new Tree<string>();


            avlTreeInt.Add("Aккк");
            avlTreeInt.Add("B");
            avlTreeInt.Add("E");
            avlTreeInt.Add("R");
            avlTreeInt.Add("P");
            avlTreeInt.Add("Q");
            avlTreeInt.Add("W");
            avlTreeInt.Add("Z");
            avlTreeInt.Add("R");
        }

        [TestCase("C", true)]
        [TestCase("F", true)]
        [TestCase("G", true)]
        public void AddTest(string value, bool expected)
        {
            avlTreeInt.Add(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Aккк", false)]
        [TestCase("W", false)]
        [TestCase("R", true)]
        public void RemoveTest(string value, bool expected)
        {
            avlTreeInt.Remove(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Z", false)]

        public void ClearTest(string value, bool expected)
        {
            avlTreeInt.Add(value);
            avlTreeInt.Clear();
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }
    }
}

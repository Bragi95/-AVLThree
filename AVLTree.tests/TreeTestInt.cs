using NUnit.Framework;

namespace AVLTree.tests
{
    public class TreeTestsInt
    {
        Tree<int> avlTreeInt;
        [SetUp]
        public void Setup()
        {
            avlTreeInt = new Tree<int>();


            avlTreeInt.Add(12);
            avlTreeInt.Add(11);
            avlTreeInt.Add(15);
            avlTreeInt.Add(2);
            avlTreeInt.Add(18);
            avlTreeInt.Add(1);
            avlTreeInt.Add(41);
            avlTreeInt.Add(15);
        }

        [TestCase(22, true)]
        [TestCase(2, true)]
        [TestCase(0, true)]
        public void AddTest(int value, bool expected)
        {
            avlTreeInt.Add(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(22, false)]
        [TestCase(2, false)]
        [TestCase(15, true)]
        public void RemoveTest(int value, bool expected)
        {
            avlTreeInt.Remove(value);
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(47, false)]
        
        public void ClearTest(int value, bool expected)
        {
            avlTreeInt.Add(value);
            avlTreeInt.Clear();
            bool actual = avlTreeInt.Contains(value);

            Assert.AreEqual(expected, actual);
        }
    }
}
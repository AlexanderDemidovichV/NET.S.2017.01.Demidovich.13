using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Tests
{
    class BinaryTreeTests
    {
        public class ComparatorByStringLenght : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x == null)
                    throw new ArgumentNullException(nameof(x));

                if (y == null)
                    throw new ArgumentNullException(nameof(y));

                return x.Length.CompareTo(y.Length);
            }
        }

        [TestCase(TestName = "Int32PreorderTraversal", ExpectedResult = new int[] { 7, 5, 4, 1, 6, 9, 8, 10 })]
        public int[] TestInt32PreorderTraversal()
        {
            var treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };
            return treeInt32.Preorder().ToArray();
        }

        [TestCase(TestName = "Int32InorderTraversal", ExpectedResult = new int[] { 1, 4, 5, 6, 7, 8, 9, 10 })]
        public int[] TestInt32InorderTraversal()
        {
            var treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };
            return treeInt32.Inorder().ToArray();
        }

        [TestCase(TestName = "Int32PostorderTraversal", ExpectedResult = new int[] { 1, 4, 6, 5, 8, 10, 9, 7 })]
        public int[] TestInt32PostorderTraversal()
        {
            var treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };
            return treeInt32.Postorder().ToArray();
        }

        [TestCase(3, TestName = "Insert3ToTree", ExpectedResult = new int[] { 7, 5, 4, 1, 3, 6, 9, 8, 10 })]
        [TestCase(12, TestName = "Insert12ToTree", ExpectedResult = new int[] { 7, 5, 4, 1, 6, 9, 8, 10, 12 })]
        public int[] TestInt32Insertion(int value)
        {
            var treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };
            treeInt32.Add(value);
            return treeInt32.Preorder().ToArray();
        }

        [TestCase(1, TestName = "TreeContains1", ExpectedResult = true)]
        [TestCase(200, TestName = "TreeDoesntContain200", ExpectedResult = false)]
        public bool TestInt32Contains(int value)
        {
            var treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };
            return treeInt32.Contains(value);
        }


        [TestCase(TestName = "StringPreorderTraversal", ExpectedResult = new string[] { "Hello", "Mr", "Jon", "Skeet" })]
        public string[] TestStringPreorderTraversal()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };
            return treeString.Preorder().ToArray();
        }

        [TestCase(TestName = "StringInorderTraversal", ExpectedResult = new string[] { "Hello", "Jon", "Mr", "Skeet" })]
        public string[] TestStringInorderTraversal()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };
            return treeString.Inorder().ToArray();
        }

        [TestCase(TestName = "StringPostorderTraversal", ExpectedResult = new string[] { "Jon", "Skeet", "Mr", "Hello" })]
        public string[] TestStringPostorderTraversal()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };
            return treeString.Postorder().ToArray();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    class DiagonalMatrixTests
    {

        public IEnumerable<TestCaseData> GetEnumerator_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(16);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(9);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 })).Returns(4);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("GetEnumerator_TestData")]
        public static int GetEnumerator_Test(DiagonalMatrix<int> matrix)
        {
            int i = 0;
            foreach (var item in matrix)
            {
                i++;
            }

            return i;
        }

        public IEnumerable<TestCaseData> Size_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(4);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(3);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 })).Returns(2);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("Size_TestData")]
        public static int Size_Test(DiagonalMatrix<int> matrix)
        {
            return matrix.Size;
        }

        public IEnumerable<TestCaseData> Indexer_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 }), 1, 1, 0).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 }), 2, 1, 7).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), 1, 2, 10).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 }), 1, 1, 0).Returns(0);
            }
        }

        [Test, TestCaseSource("Indexer_TestData")]
        public static int Indexer_Test(DiagonalMatrix<int> matrix, int i, int j, int value)
        {
            matrix[i, j] = value;

            return matrix[i, j];
        }

    }
}

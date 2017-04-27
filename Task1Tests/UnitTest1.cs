using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Logic;

namespace Task1Tests
{
    [TestClass]
    public class SummTest
    {
        [TestMethod]
        public void SummTest1()
        {
            int[][] diagonalMatrixInts =
            {
                new int[3] {1, 0, 0},
                new int[3] {0, 5, 0},
                new int[3] {0, 0, 9},
            };
            int[][] rs =
            {
                new int[3] {2, 0, 0},
                new int[3] {0, 10, 0},
                new int[3] {0, 0, 18},
            };
            SquareMatrix<int> mas1 = new SquareMatrix<int>(diagonalMatrixInts);
            SquareMatrix<int> mas2 = new SquareMatrix<int>(diagonalMatrixInts);
            SquareMatrix<int> mas3 = new SquareMatrix<int>(diagonalMatrixInts.Length);
            mas3 = (SquareMatrix<int>)mas1.Add(mas2);
            Assert.IsTrue(mas3.CompareToJaggedArray(rs));
        }
        
    }
}

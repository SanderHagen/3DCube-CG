using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixTransformations;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Identity()
        {
            Matrix id = new Matrix();

            Assert.AreEqual(1, id.mat[0, 0]);
            Assert.AreEqual(1, id.mat[1, 1]);
            Assert.AreEqual(1, id.mat[2, 2]);
            Assert.AreEqual(1, id.mat[3, 3]);
            Assert.AreEqual(0, id.mat[0, 1]);
            Assert.AreEqual(0, id.mat[0, 2]);
            Assert.AreEqual(0, id.mat[0, 3]);
            Assert.AreEqual(0, id.mat[1, 0]);
            Assert.AreEqual(0, id.mat[1, 2]);
            Assert.AreEqual(0, id.mat[1, 3]);
            Assert.AreEqual(0, id.mat[2, 0]);
            Assert.AreEqual(0, id.mat[2, 1]);
            Assert.AreEqual(0, id.mat[2, 3]);
            Assert.AreEqual(0, id.mat[3, 0]);
            Assert.AreEqual(0, id.mat[3, 1]);
            Assert.AreEqual(0, id.mat[3, 2]);
        }

        [TestMethod]
        public void MatrixAddition()
        {
            Matrix m1 = new Matrix(2, 5, 7, 1,
                                2, 3, 8, 15,
                                2, 3, 1, 7,
                                9, 10, 5, 1);

            Matrix m2 = new Matrix(3, 1, 2, 3,
                                   1, 1, 4, 7,
                                   2, 5, 6, 2,
                                   8, 14, 7, 1);

            Matrix result = m1 + m2;

            Assert.AreEqual(5, result.mat[0, 0]);
            Assert.AreEqual(6, result.mat[0, 1]);
            Assert.AreEqual(9, result.mat[0, 2]);
            Assert.AreEqual(4, result.mat[0, 3]);
            Assert.AreEqual(3, result.mat[1, 0]);
            Assert.AreEqual(4, result.mat[1, 1]);
            Assert.AreEqual(12, result.mat[1, 2]);
            Assert.AreEqual(22, result.mat[1, 3]);
            Assert.AreEqual(4, result.mat[2, 0]);
            Assert.AreEqual(8, result.mat[2, 1]);
            Assert.AreEqual(7, result.mat[2, 2]);
            Assert.AreEqual(9, result.mat[2, 3]);
            Assert.AreEqual(17, result.mat[3, 0]);
            Assert.AreEqual(24, result.mat[3, 1]);
            Assert.AreEqual(12, result.mat[3, 2]);
            Assert.AreEqual(2, result.mat[3, 3]);
        }

        [TestMethod]
        public void MatrixSubtraction()
        {
            Matrix m1 = new Matrix(2, 5, 7, 1, 
                                   2, 3, 8, 15, 
                                   2, 3, 1, 7,
                                   9, 10, 5, 1);

            Matrix m2 = new Matrix(3, 1, 2, 3, 
                                   1, 1, 4, 7, 
                                   2, 5, 6, 2, 
                                   8, 14, 7, 1);

            Matrix result = m1 - m2;

            Assert.AreEqual(-1, result.mat[0, 0]);
            Assert.AreEqual(4, result.mat[0, 1]);
            Assert.AreEqual(5, result.mat[0, 2]);
            Assert.AreEqual(-2, result.mat[0, 3]);
            Assert.AreEqual(1, result.mat[1, 0]);
            Assert.AreEqual(2, result.mat[1, 1]);
            Assert.AreEqual(4, result.mat[1, 2]);
            Assert.AreEqual(8, result.mat[1, 3]);
            Assert.AreEqual(0, result.mat[2, 0]);
            Assert.AreEqual(-2, result.mat[2, 1]);
            Assert.AreEqual(-5, result.mat[2, 2]);
            Assert.AreEqual(5, result.mat[2, 3]);
            Assert.AreEqual(1, result.mat[3, 0]);
            Assert.AreEqual(-4, result.mat[3, 1]);
            Assert.AreEqual(-2, result.mat[3, 2]);
            Assert.AreEqual(0, result.mat[3, 3]);
        }

        [TestMethod]
        public void MatrixTimesFloat()
        {
            Matrix m1 = new Matrix(2, 5, 7, 1,
                                   2, 3, 8, 15,
                                   2, -3, 1, 7,
                                   9, 10, 5, 1);

            Matrix result = m1 * 2f;

            Assert.AreEqual(4, result.mat[0, 0]);
            Assert.AreEqual(10, result.mat[0, 1]);
            Assert.AreEqual(14, result.mat[0, 2]);
            Assert.AreEqual(2, result.mat[0, 3]);
            Assert.AreEqual(4, result.mat[1, 0]);
            Assert.AreEqual(6, result.mat[1, 1]);
            Assert.AreEqual(16, result.mat[1, 2]);
            Assert.AreEqual(30, result.mat[1, 3]);
            Assert.AreEqual(4, result.mat[2, 0]);
            Assert.AreEqual(-6, result.mat[2, 1]);
            Assert.AreEqual(2, result.mat[2, 2]);
            Assert.AreEqual(14, result.mat[2, 3]);
            Assert.AreEqual(18, result.mat[3, 0]);
            Assert.AreEqual(20, result.mat[3, 1]);
            Assert.AreEqual(10, result.mat[3, 2]);
            Assert.AreEqual(2, result.mat[3, 3]);
        }

        [TestMethod]
        public void MatrixMultiplication()
        {
            Matrix m1 = new Matrix(2, 5, 7, 1,
                                    2, 3, 8, 15,
                                    2, 3, 1, 7,
                                    9, 10, 5, 1);

            Matrix m2 = new Matrix(3, 1, 2, 3,
                                   1, 1, 4, 7,
                                   2, 5, 6, 2,
                                   8, 14, 7, 1);

            Matrix result = m1 * m2;

            Assert.AreEqual(33, result.mat[0, 0]);
            Assert.AreEqual(56, result.mat[0, 1]);
            Assert.AreEqual(73, result.mat[0, 2]);
            Assert.AreEqual(56, result.mat[0, 3]);
            Assert.AreEqual(145, result.mat[1, 0]);
            Assert.AreEqual(255, result.mat[1, 1]);
            Assert.AreEqual(169, result.mat[1, 2]);
            Assert.AreEqual(58, result.mat[1, 3]);
            Assert.AreEqual(67, result.mat[2, 0]);
            Assert.AreEqual(108, result.mat[2, 1]);
            Assert.AreEqual(71, result.mat[2, 2]);
            Assert.AreEqual(36, result.mat[2, 3]);
            Assert.AreEqual(55, result.mat[3, 0]);
            Assert.AreEqual(58, result.mat[3, 1]);
            Assert.AreEqual(95, result.mat[3, 2]);
            Assert.AreEqual(108, result.mat[3, 3]);
        }


        [TestMethod]
        public void MatrixTimesVector()
        {
            Matrix m1 = new Matrix
                (2, 5, 7, 1, 
                 2, 3, 3, 2, 
                 5, 9, 1, 4, 
                 3, 8, 9, 2);
            Vector v = new Vector(2, 4,5);

            Vector result = m1 * v;

            Assert.AreEqual(60, result.x);
            Assert.AreEqual(33, result.y);
            Assert.AreEqual(1, result.w);
            Assert.AreEqual(55, result.z);

        }


        [TestMethod]
        public void MatrixScale()
        {
            Matrix m1 = new Matrix(2, 5, 7, 1, 2, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix s = Matrix.Scale(2f);
            Matrix result = m1 * s;

            Assert.AreEqual(4, result.mat[0, 0]);
            Assert.AreEqual(10, result.mat[0, 1]);
        }
    }
}

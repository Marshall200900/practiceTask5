using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[][] matrix = new double[3][];
            for(int i = 0; i < matrix.Length; i++)//3*3+3*3+3*3
            {
                matrix[i] = new double[3];
                for(int j = 0; j < matrix.Length; j++)
                {
                    matrix[i][j] = j + 1;
                }
            }
            Assert.AreEqual(27, Program.GetSum(Program.GetMaxValues(matrix)));
        }
        [TestMethod]
        public void TestMethod2()
        {
            double[][] matrix = new double[3][];
            for (int i = 0; i < matrix.Length; i++)//0*0+0*0+0*0
            {
                matrix[i] = new double[3];
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i][j] = 0;
                }
            }
            Assert.AreEqual(0, Program.GetSum(Program.GetMaxValues(matrix)));
        }
        [TestMethod]
        public void TestMethod3()
        {
            double[][] matrix = new double[3][];
            for (int i = 0; i < matrix.Length; i++)//-1*-1+-1*-1+-1*-1
            {
                matrix[i] = new double[3];
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i][j] = -j-1;
                }
            }
            Assert.AreEqual(3, Program.GetSum(Program.GetMaxValues(matrix)));
        }
    }
}

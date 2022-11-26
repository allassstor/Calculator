using System;

using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RunEstimateTest
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"C:\Users\Пользователь\Desktop\TEST\lab1\Calculator\Calculator\UnitTest\DataTests.xml",
            "Test", 
            DataAccessMethod.Sequential)]

        [TestMethod]
        public void RunEstimateTest()
        {
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["initialazied"]);
            string actual = AnalaizerClass.RunEstimate();
            Assert.AreEqual(expected, actual);
        } 
        [TestMethod]
        public void RunEst1()
        {
            string expected = "&";
            AnalaizerClass.expression = "56+";
            string actual = AnalaizerClass.RunEstimate();
            Assert.AreEqual(expected, actual);
        }[TestMethod]
        public void RunEst2()
        {
            string expected = "17";
            AnalaizerClass.expression = "(5+1)+6+5/(5+5-5)%2";
            string actual = AnalaizerClass.RunEstimate();
            Assert.AreEqual(expected, actual);
        }[TestMethod]
        public void RunEst3()
        {
            string expected = "&Error 08 — Сумарна кількість чисел і операторів перевищує 30.";
            AnalaizerClass.expression = "2-1-2-1-2-1-2-3-1-1-2-2-1-1-2-1-12-1-12-1-2-1-3-1-2-1-2-1-2-1-2-1-2-1-2-1";
            string actual = AnalaizerClass.RunEstimate();
            Assert.AreEqual(expected, actual);
        }[TestMethod]
        public void RunEst4()
        {
            string expected = "&";
            AnalaizerClass.expression = "8-3*";
            string actual = AnalaizerClass.RunEstimate();
            Assert.AreEqual(expected, actual);
        }
    }
}

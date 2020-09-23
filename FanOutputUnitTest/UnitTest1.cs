using System;
using FanOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FanOutputUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        FanOutputModel fanOutput = new FanOutputModel();
        [TestMethod]
        public void TestMethodName()
        {
            Assert.AreEqual("Magnum", fanOutput.Name = "Magnum");
            Assert.AreEqual("Bob", fanOutput.Name = "Bob");
            try
            {
                fanOutput.Name = "I";
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("Navnet skal være minimum 2 karakterer lang (Parameter 'Navn')", e.Message);
            }
        }

        [TestMethod]
        public void TestMethodTemp()
        {
            Assert.AreEqual(15, fanOutput.Temp = 15);
            Assert.AreEqual(25, fanOutput.Temp = 25);
            try
            {
                fanOutput.Temp = 14;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("Temp skal være et tal mellem 15 og 25 (Parameter 'Temp')", e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodTempExceedingLimit()
        {
            fanOutput.Temp = 26;
        }

        [TestMethod]
        public void TestMethodHumidity()
        {
            Assert.AreEqual(30, fanOutput.Humidity = 30);
            Assert.AreEqual(80, fanOutput.Humidity = 80);
            try
            {
                fanOutput.Humidity = 29;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("Fugt skal være  et tal mellem 30 og 80 (Parameter 'Fugt')", e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodHumidityExceedingLimit()
        {
            fanOutput.Humidity = 81;
        }
    }
}

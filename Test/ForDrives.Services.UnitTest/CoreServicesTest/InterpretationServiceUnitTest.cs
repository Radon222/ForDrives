using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForDrives.Services.Core;

namespace ForDrives.Services.UnitTest
{
    [TestClass]
    public class InterpretationServiceUnitTest
    {
        [TestMethod]
        public void ToLetters1Test()
        {
            var interpreter = new InterpretationService();
            var expected = "ABC";
            var actual = interpreter.ToLetters(7);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLettersTest2()
        {
            var interpreter = new InterpretationService();
            var expected = "ENW";
            var actual = interpreter.ToLetters(4202512);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLettersTest3()
        {
            var interpreter = new InterpretationService();
            var expected = "COT";
            var actual = interpreter.ToLetters(540676);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLettersTest4()
        {
            var interpreter = new InterpretationService();
            var expected = "AZ";
            var actual = interpreter.ToLetters(33554433);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLettersTest5()
        {
            var interpreter = new InterpretationService();
            var expected = "HU";
            var actual = interpreter.ToLetters(1048704);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLettersTest6()
        {
            var interpreter = new InterpretationService();
            var expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var actual = interpreter.ToLetters(67108863);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest1()
        {
            var interpreter = new InterpretationService();
            var expected = 1048704;
            var actual = interpreter.ToNumber("HU");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest2()
        {
            var interpreter = new InterpretationService();
            var expected = 33554433;
            var actual = interpreter.ToNumber("AZ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest3()
        {
            var interpreter = new InterpretationService();
            var expected = 540676;
            var actual = interpreter.ToNumber("OCT");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest4()
        {
            var interpreter = new InterpretationService();
            var expected = 4202512;
            var actual = interpreter.ToNumber("NEW");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest5()
        {
            var interpreter = new InterpretationService();
            var expected = 7;
            var actual = interpreter.ToNumber("ABC");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest6()
        {
            var interpreter = new InterpretationService();
            var expected = 67108863;
            var actual = interpreter.ToNumber("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest7()
        {
            var interpreter = new InterpretationService();
            var expected = 0;
            var actual = interpreter.ToNumber("");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToNumberTest8()
        {
            var interpreter = new InterpretationService();
            var expected = 0;
            var actual = interpreter.ToNumber(null);

            Assert.AreEqual(expected, actual);
        }

    }
}

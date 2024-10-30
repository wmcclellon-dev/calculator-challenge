using NUnit.Framework;
using CalculatorChallenge;
using System;

namespace SimpleCalculatorTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, calculator.Add(""));
        }

        [Test]
        public void Add_SingleNumber_ReturnsTheNumber()
        {
            Assert.AreEqual(20, calculator.Add("20"));
        }

        [Test]
        public void Add_TwoNumbers_ReturnsTheirSum()
        {
            Assert.AreEqual(5001, calculator.Add("1,5000"));
        }

        [Test]
        public void Add_NegativeAndPositiveNumber_ReturnsTheirSum()
        {
            Assert.AreEqual(1, calculator.Add("4,-3"));
        }

        [Test]
        public void Add_MultipleNumbers_ReturnsTheirSum()
        {
            Assert.AreEqual(78, calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12"));
        }

        [Test]
        public void Add_InvalidNumber_TreatsAsZero()
        {
            Assert.AreEqual(5, calculator.Add("5,tytyt"));
        }

        [Test]
        public void Add_NumbersWithNewlineDelimiter_ReturnsTheirSum()
        {
            Assert.AreEqual(6, calculator.Add("1\n2,3"));
        }

        [Test]
        public void Add_NegativeNumbers_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Add("1,-2,3,-4"));
            Assert.AreEqual("Negatives not allowed: -2, -4", ex.Message);
        }
    }
}

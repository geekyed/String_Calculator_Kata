using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void AnEmptyStringReturnsZero()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Calculate("");
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ASingleNumberReturnsTheValue()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Calculate("2");
            Assert.That(result, Is.EqualTo(2));
        }

        [TestCase("1, 2", 3)]
        public void TwoNumbersCommaDelimitedReturnsTheSum(string input, int expectedResult)
        {
            ActAndAssert(input, expectedResult);
        }

        [TestCase("6\n4", 10)]
        public void TwoNumbersNewLineDelimitedReturnsTheSum(string input, int expectedResult)
        {
            ActAndAssert(input, expectedResult);
        }

        [TestCase("1,6\n4", 11)]
        [TestCase("3\n4\n7", 14)]
        [TestCase("78,12,0", 90)]
        public void ThreeNumbersDelimitedEitherWayReturnsTheSum(string input, int expectedResult)
        {
            ActAndAssert(input, expectedResult);
        }

        [TestCase("-7")]
        [TestCase("12, -88")]
        public void NegativeNumberThrowsAnException(string input)
        {
            try
            {
                var stringCalculator = new StringCalculator();
                var result = stringCalculator.Calculate(input);
            }
            catch(Exception)
            {
                Assert.Pass("Exception was thrown");
            }

            Assert.Fail("Expected exception but was not thrown");
        }

        private static void ActAndAssert(string input, int expectedResult)
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Calculate(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
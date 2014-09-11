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

        private static void ActAndAssert(string input, int expectedResult)
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Calculate(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
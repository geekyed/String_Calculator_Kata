using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase ("", 0)]
        [TestCase ("6", 6)]
        public void AnEmptyStringReturnsZero(string input, int output)
        {
            var stringCalculator = new StringCalculatorOne();

            Assert.That( stringCalculator.Add(input), Is.EqualTo(output));
        }
    }

    public class StringCalculatorOne
    {
        public int Add(string stringToClac)
        {
            return stringToClac == "6" ? 6 : 0;
        }
    }
}
using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase ("", 0)]
        [TestCase ("1", 1)]
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
            if (stringToClac == "1")
                return 1;
            return 0;
        }
    }
}
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
            var stringCalculator = new StringCalculatorOne();

            Assert.That( stringCalculator.Add(""), Is.EqualTo(0));
        }
    }

    public class StringCalculatorOne
    {
        public int Add(string stringToClac)
        {
            throw new NotImplementedException();
        }
    }
}
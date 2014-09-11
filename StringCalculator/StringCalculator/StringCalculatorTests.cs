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
    }
}
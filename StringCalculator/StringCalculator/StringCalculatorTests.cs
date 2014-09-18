using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase ("", 0)]
        [TestCase ("6", 6)]
        [TestCase ("3,2", 5)]
        [TestCase ("6\n0", 6)]
        [TestCase ("1,50\n3", 54)]
        [TestCase ("3,1001,4", 7)]
        public void StringCalculatorAddsString(string input, int output)
        {
            var stringCalculator = new StringCalculatorOne();

            Assert.That( stringCalculator.Add(input), Is.EqualTo(output));
        }

        [Test]
        public void AddingNegativeNumbersThows()
        {
            var stringCalculator = new StringCalculatorOne();

            Assert.Throws<ArithmeticException>(()=>stringCalculator.Add("-1"));
        }
    }

    public class StringCalculatorOne
    {
        public int Add(string stringToAdd)
        {
            if (string.IsNullOrEmpty(stringToAdd))
                return 0;

            var numbers = GetNumbersFromString(stringToAdd).ToList();

            if (AreNumbersNegative(numbers))
                throw new ArithmeticException();

            return numbers.Where(number => number <= 1000).Sum();

        }

        private static bool AreNumbersNegative(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number < 0);
        }

        private static IEnumerable<int> GetNumbersFromString(string stringToAdd)
        {
            return stringToAdd.Split(new [] {',', '\n'}).Select(Int32.Parse);
        }
    }
}
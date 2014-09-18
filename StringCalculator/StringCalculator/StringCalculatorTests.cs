using System;
using System.Collections.Generic;
using System.Globalization;
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
        [TestCase ("//#\n3,2#1", 6)]
        [TestCase ("//[#^]\n3^2#1", 6)]
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
            var input = stringToAdd; 
            if (string.IsNullOrEmpty(stringToAdd))
                return 0;

            var newDelimiters = GetNewDelimiter(stringToAdd);
            if (newDelimiters != null)
                input = stringToAdd.Split('\n')[1];

            var numbers = GetNumbersFromString(input, newDelimiters).ToList();

            if (AreNumbersNegative(numbers))
                throw new ArithmeticException();

            return numbers.Where(number => number <= 1000).Sum();

        }

        private char[] GetNewDelimiter(string stringToAdd)
        {
            if (stringToAdd.StartsWith("//[")) 
                return stringToAdd.Substring(4, stringToAdd.IndexOf(']')).ToCharArray();

            return null;
        }

        private static bool AreNumbersNegative(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number < 0);
        }

        private static IEnumerable<int> GetNumbersFromString(string stringToAdd, IEnumerable<char> newDelimiter)
        {
            var delimiters = new List<char> {',', '\n'};
            if (newDelimiter != null)
                delimiters.AddRange(newDelimiter);
            return stringToAdd.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);
        }
    }
}
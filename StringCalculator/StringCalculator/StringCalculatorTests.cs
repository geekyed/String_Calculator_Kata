using System;
using System.Collections.Generic;
using System.Linq;
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
            if (string.IsNullOrEmpty(stringToAdd))
                return 0;

            var newDelimiters = GetNewDelimiters(stringToAdd);
            if (newDelimiters.Any())
                stringToAdd = stringToAdd.Split('\n')[1];

            var numbers = GetNumbersFromString(stringToAdd, newDelimiters).ToList();

            if (AreNumbersNegative(numbers))
                throw new ArithmeticException();

            return numbers.Where(number => number <= 1000).Sum();

        }

        private List<char> GetNewDelimiters(string stringToAdd)
        {
            if (stringToAdd.StartsWith("//[")) 
                return stringToAdd.Substring(3, stringToAdd.IndexOf(']') - 1).ToList();
            if (stringToAdd.StartsWith("//"))
                return new List<char>{stringToAdd.ElementAt(2)};

            return new List<char>();
        }

        private static bool AreNumbersNegative(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number < 0);
        }

        private static IEnumerable<int> GetNumbersFromString(string stringToAdd, IEnumerable<char> newDelimiters)
        {
            var delimiters = new List<char> {',', '\n'};
            if (newDelimiters != null)
                delimiters.AddRange(newDelimiters);
            return stringToAdd.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);
        }
    }
}
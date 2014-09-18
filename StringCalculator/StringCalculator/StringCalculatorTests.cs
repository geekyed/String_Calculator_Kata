﻿using System;
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
        [TestCase ("6\n0", 5)]
        public void StringCalculatorAddsString(string input, int output)
        {
            var stringCalculator = new StringCalculatorOne();

            Assert.That( stringCalculator.Add(input), Is.EqualTo(output));
        }
    }

    public class StringCalculatorOne
    {
        public int Add(string stringToClac)
        {
            if (string.IsNullOrEmpty(stringToClac))
                return 0;

            return stringToClac.Split(',').Select(Int32.Parse).Sum();
        }
    }
}
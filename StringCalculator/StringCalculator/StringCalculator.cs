using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Calculate(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var values = input.Split(new [] { ",", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            if(values.Any(x => Int32.Parse(x) < 0))
            {
                throw new InvalidOperationException("Negative numbers are not allowed!");
            }

            var result = values.Sum(x => Int32.Parse(x));

            return result;
        }
    }
}


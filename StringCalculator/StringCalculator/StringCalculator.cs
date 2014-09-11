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

            var valuesAsInt = values.Select(x => Int32.Parse(x));

                if(valuesAsInt.Any(x => x < 0))
            {
                throw new InvalidOperationException("Negative numbers are not allowed!");
            }

            return valuesAsInt.Sum();
        }
    }
}


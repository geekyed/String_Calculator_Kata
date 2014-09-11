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

            var values = input.Split(new [] { ","}, StringSplitOptions.RemoveEmptyEntries);

            var result = values.Sum(x => Int32.Parse(x));

            return result;
        }
    }
}


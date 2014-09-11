using System;
using System.Linq;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalculator
    {
        private List<string> Delimiters = new List<string> { ",", "\n"};

        public int Calculate(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if(input.StartsWith("//"))
            {
                Delimiters.Add(input[2].ToString());

                input = input.TrimStart('/');
            }

            var values = input.Split(Delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var valuesAsInt = values.Select(x => Int32.Parse(x));

            if(valuesAsInt.Any(x => x < 0))
            {
                throw new InvalidOperationException("Negative numbers are not allowed!");
            }

            return valuesAsInt.Where(x => x <= 1000).Sum();
        }
    }
}


using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        private List<string> _delimiters = new List<string> { ",", "\n"};

        public int Calculate(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return 0;
            }

            AddCustomDelimiters(ref input);

            var values = input.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var valuesAsInt = values.Select(x => Int32.Parse(x));

            if(valuesAsInt.Any(x => x < 0))
            {
                throw new InvalidOperationException("Negative numbers are not allowed!");
            }

            return valuesAsInt.Where(x => x <= 1000).Sum();
        }

        private void AddCustomDelimiters(ref string input)
        {
            if (input.StartsWith("//"))
            {
                if (input[3] != '\n')
                {
                    var newDelimiter = Regex.Match(input, @"\[([^]]*)\]").Groups[1].Value;
                    _delimiters.Add(newDelimiter);
                }
                else
                {
                    _delimiters.Add(input[2].ToString());
                }

                string[] lines = input.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
                input = string.Join(Environment.NewLine, lines);
            }
        }
    }
}


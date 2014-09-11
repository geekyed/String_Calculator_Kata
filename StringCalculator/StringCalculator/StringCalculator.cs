using System;

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

            var result = Int32.Parse(input);
            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roman
{
    public class ToRoman
    {
        private string[][] _numeralsByPowersOfTen =
        {
            new[] {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
            new[] {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
            new[] {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
            new[] {"", "M", "MM", "MMM", "IV", "V", "VI", "VII", "VIII", "IX"}
        };

        public string FromInt(int number)
        {
            return BreakIntoDigits(number)
                .Zip(_numeralsByPowersOfTen, (digit, numerals) => numerals[digit])
                .Reverse()
                .Aggregate(string.Concat);
        }

        private IEnumerable<int> BreakIntoDigits(int number)
        {
            do
            {
                yield return number % 10;
                number /= 10;
            } while (number > 0);
        }
    }
}

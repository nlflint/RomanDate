using System.Collections.Generic;
using System.Linq;

namespace Roman
{
    public class ToRoman
    {
        private readonly string[][] _numeralSetsByPowersOfTen =
        {
            new[] {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
            new[] {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
            new[] {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
            new[] {"", "M", "MM", "MMM", "IV", "V", "VI", "VII", "VIII", "IX"}
        };

        public string FromInt(int number)
        {
            return BreakIntoDigits(number)
                .Zip(_numeralSetsByPowersOfTen, NumeralFromDigit)
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

        private string NumeralFromDigit(int digit, string[] numeralSet) => numeralSet[digit];
        
        public string FromDate(string date)
        {
            return string.Join('/', date
                .Split('/')
                .Select(int.Parse)
                .Select(FromInt));

        }
    }
}

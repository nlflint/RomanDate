using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ClassLibrary1
{
    public class Roman
    {
        private readonly ITestOutputHelper output;

        public Roman(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test()
        {
            Assert.Equal("I", ToRoman(1));
            Assert.Equal("II", ToRoman(2));
            Assert.Equal("IV", ToRoman(4));
            Assert.Equal("V", ToRoman(5));
            Assert.Equal("VIII", ToRoman(8));
            Assert.Equal("IX", ToRoman(9));
            Assert.Equal("", ToRoman(0));

            Assert.Equal("X", ToRoman(10));
            Assert.Equal("XLVI", ToRoman(46));
            Assert.Equal("XXXIX", ToRoman(39));
            Assert.Equal("LI", ToRoman(51));
            Assert.Equal("XCIX", ToRoman(99));

            Assert.Equal("DXIII", ToRoman(513));
            Assert.Equal("CCCXXVI", ToRoman(326));
            Assert.Equal("CLXXXVIII", ToRoman(188));
            Assert.Equal("DCCCLXXXII", ToRoman(882));
            Assert.Equal("CMLXX", ToRoman(970));
            Assert.Equal("CMXCIX", ToRoman(999));

            Assert.Equal("M", ToRoman(1000));
            Assert.Equal("MM", ToRoman(2000));
            Assert.Equal("MMM", ToRoman(3000));
            Assert.Equal("IV", ToRoman(4000));
            Assert.Equal("V", ToRoman(5000));
            Assert.Equal("VI", ToRoman(6000));
            Assert.Equal("VII", ToRoman(7000));
            Assert.Equal("VIII", ToRoman(8000));
            Assert.Equal("IX", ToRoman(9000));
            Assert.Equal("IXCMXCIX", ToRoman(9999));
        }

        private string[][] _numeralsByPowersOfTen =
        {
            new[] {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
            new[] {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
            new[] {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
            new[] {"", "M", "MM", "MMM", "IV", "V", "VI", "VII", "VIII", "IX"}
        };
        
        private string ToRoman(int number)
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
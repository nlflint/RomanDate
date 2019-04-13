using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    public class Roman
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(ToRoman(1), "I");
            Assert.Equal(ToRoman(2), "II");
            Assert.Equal(ToRoman(4), "IV");
            Assert.Equal(ToRoman(5), "V");
            Assert.Equal(ToRoman(8), "VIII");
            Assert.Equal(ToRoman(9), "IX");
            Assert.Equal(ToRoman(0), "");

            Assert.Equal(ToRoman(10), "X");
            Assert.Equal(ToRoman(46), "XLVI");
            Assert.Equal(ToRoman(39), "XXXIX");
            Assert.Equal(ToRoman(51), "LI");
            Assert.Equal(ToRoman(99), "XCIX");

            Assert.Equal(ToRoman(513), "DXIII");
            Assert.Equal(ToRoman(326), "CCCXXVI");
            Assert.Equal(ToRoman(188), "CLXXXVIII");
            Assert.Equal(ToRoman(882), "DCCCLXXXII");
            Assert.Equal(ToRoman(970), "CMLXX");
            Assert.Equal(ToRoman(999), "CMXCIX");

        }

        private Dictionary<int, string> Ones = new Dictionary<int, string>
        {
            {0,"" },
            {1,"I" },
            {2,"II" },
            {3,"III" },
            {4,"IV" },
            {5,"V" },
            {6,"VI" },
            {7,"VII" },
            {8,"VIII" },
            {9,"IX" },
        };

        private Dictionary<int, string> Tens = new Dictionary<int, string>
        {
            {0,"" },
            {1,"X" },
            {2,"XX" },
            {3,"XXX" },
            {4,"XL" },
            {5,"L" },
            {6,"LX" },
            {7,"LXX" },
            {8,"LXXX" },
            {9,"XC" },
        };

        private Dictionary<int, string> Hundreds = new Dictionary<int, string>
        {
            {0,"" },
            {1,"C" },
            {2,"CC" },
            {3,"CCC" },
            {4,"CD" },
            {5,"D" },
            {6,"DC" },
            {7,"DCC" },
            {8,"DCCC" },
            {9,"CM" },
        };

        private string ToRoman(int number)
        {

            return Hundreds[DigitAtPosition(number, 2)] +
                Tens[DigitAtPosition(number, 1)] +
                Ones[DigitAtPosition(number, 0)];
        }

        private static int DigitAtPosition(int number, int position)
        {
            var asdf = (int) Math.Pow(10,position);
            return number / asdf % 10;
        }
    }
}
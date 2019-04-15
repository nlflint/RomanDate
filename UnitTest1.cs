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
        public void NumberToRomanTests()
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

        }
        
        private string ToRoman(int number)
        {   
            var denominationSetfactory = new DenominationSetFactory();

            return Enumerable
                .Range(0, denominationSetfactory.SupportedPowersOfTenCount)
                .Select(denominationSetfactory.Make)
                .Zip(BreakIntoDigits(number), ConvertDigitToRoman)
                .Reverse()
                .Aggregate(string.Concat);
        }
        private IEnumerable<int> BreakIntoDigits(int number) {
            do {
                yield return number  % 10;
                number /= 10;
            } while (number > 0);
        }

        private string ConvertDigitToRoman(DenominationSet set, int digit) {
            if (digit == 0) return "";
            if (digit < 4) return new String(set.Small.First(),digit);
            if (digit == 4) return set.Small + set.Medium;
            if (digit == 5) return set.Medium;
            if (digit < 9) return set.Medium + new String(set.Small.First(),digit - 5);
            return set.Small + set.Large;
        }
    }

    public class DenominationSetFactory {
        private List<string> _denominations = new [] {"I","V","X","L","C","D","M"}.ToList();
        public DenominationSet Make(int powerOfTen) {
            var subSet = _denominations.Skip(2 * powerOfTen).Take(3).ToList();
            return new DenominationSet(subSet[0], subSet[1], subSet[2]);
        }

        public int SupportedPowersOfTenCount => (_denominations.Count - 1) / 2;
    }

    public class DenominationSet {
        public DenominationSet(string small, string medium, string large)
        {
            
            Small = small;
            Medium = medium;
            Large = large;
        }

        public string Small {get;}
        public string Medium {get;}
        public string Large {get;}
    }
}
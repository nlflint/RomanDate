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
        
        private List<Dictionary<int, string>> RomanSetByMagnitude = new List<Dictionary<int, string>>
        {
            new Dictionary<int, string>
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
            },
            new Dictionary<int, string>
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
            },
            new Dictionary<int, string>
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
            }
        };
        
        
        private List<string> Denominations = new [] {"I","V","X","L","C","D","M"}.ToList();
        private string ToRoman(int number)
        {
            var digitsByMagnitude = BreakIntoDigits(number);

            var denominationsByMagnitude = Enumerable
                .Range(0, (Denominations.Count - 1) / 2)
                .Select(magnitude => new DenominationSet(Denominations.Skip(2 * magnitude).Take(3).ToList()));

                var blah = denominationsByMagnitude.Skip(1).First();
                Console.WriteLine("num: ",  blah.Small);
                // .Zip(digitsByMagnitude, DigitToRoman)
                // .Aggregate(string.Concat);

            return RomanSetByMagnitude
                .Select(
                    (romanSet, idx) => romanSet[DigitAtPosition(number, idx)])
                .Reverse()    
                .Aggregate(string.Concat);

            // return Enumerable
            //     .Range(0,3)
            //     .Aggregate("", (acc, power) => {
            //         var powerSet = RomanSetByMagnitude[power];
            //         return powerSet[DigitAtPosition(number, power)] + acc;
            // });
        }

        private string DigitToRoman(DenominationSet set, int digit) {
            if (digit == 0) return "";
                    if (digit < 4) return new String(set.Small.First(),digit);
                    if (digit == 4) return set.Small + set.Medium;
                    if (digit == 5) return set.Medium;
                    if (digit < 9) return set.Medium + new String(set.Small.First(),digit - 5);
                    return set.Medium + set.Large;
        }
        private IEnumerable<int> BreakIntoDigits(int number) {
            while(number > 0) {
                yield return number  % 10;
                number /= 10;
            }
        }

        private string ConvertOrderOfMagnitude(List<string> Denominations, int magnitude) {
            return "asdf";
        }
        private static int DigitAtPosition(int number, int position)
        {
            var asdf = (int) Math.Pow(10,position);
            return number / asdf % 10;
        }
    }
}
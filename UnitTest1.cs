using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Roman
{
    public class ToRoman_FromInt_Tests
    {
        private roman.ToRoman _toRoman;

        public ToRoman_FromInt_Tests()
        {
            _toRoman = new roman.ToRoman();
        }

        private string ToRoman(int number) => _toRoman.FromInt(number);

        [Fact]
        public void OnesPlace()
        {
            Assert.Equal("I", ToRoman(1));
            Assert.Equal("II", ToRoman(2));
            Assert.Equal("III", ToRoman(3));
            Assert.Equal("IV", ToRoman(4));
            Assert.Equal("V", ToRoman(5));
            Assert.Equal("VI", ToRoman(6));
            Assert.Equal("VII", ToRoman(7));
            Assert.Equal("VIII", ToRoman(8));
            Assert.Equal("IX", ToRoman(9));
            Assert.Equal("", ToRoman(0));
        }

        [Fact]
        public void TensPlace()
        {
            Assert.Equal("X", ToRoman(10));
            Assert.Equal("XX", ToRoman(20));
            Assert.Equal("XXX", ToRoman(30));
            Assert.Equal("XL", ToRoman(40));
            Assert.Equal("L", ToRoman(50));
            Assert.Equal("LX", ToRoman(60));
            Assert.Equal("LXX", ToRoman(70));
            Assert.Equal("LXXX", ToRoman(80));
            Assert.Equal("XC", ToRoman(90));
            Assert.Equal("XCIX", ToRoman(99));
        }

        [Fact]
        public void HundredsPlace()
        {
            Assert.Equal("C", ToRoman(100));
            Assert.Equal("CC", ToRoman(200));
            Assert.Equal("CCC", ToRoman(300));
            Assert.Equal("CD", ToRoman(400));
            Assert.Equal("D", ToRoman(500));
            Assert.Equal("DC", ToRoman(600));
            Assert.Equal("DCC", ToRoman(700));
            Assert.Equal("DCCC", ToRoman(800));
            Assert.Equal("CM", ToRoman(900));
            Assert.Equal("CMXCIX", ToRoman(999));
        }

        [Fact]
        public void ThousandsPlace()
        {
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
    }
}
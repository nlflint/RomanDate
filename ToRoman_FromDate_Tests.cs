using Xunit;

namespace Roman
{
    public class ToRoman_FromDate_Tests
    {
        private ToRoman _toRoman;

        public ToRoman_FromDate_Tests()
        {
            _toRoman = new ToRoman();
        }

        private string ToRoman(string date) => _toRoman.FromDate(date);

        [Fact]
        public void FirstDay()
        {
            Assert.Equal("I/I/I", ToRoman("1/1/0001"));
        }

        [Fact]
        public void FirstMillenium()
        {
            Assert.Equal("V/XXIX/DLXXXIX", ToRoman("5/29/0589"));
        }

        [Fact]
        public void SecondMillenium()
        {
            Assert.Equal("V/V/MDLXVII", ToRoman("5/5/1567"));
        }

        [Fact]
        public void ThirdMillenium()
        {
            Assert.Equal("IV/XV/MMXIX", ToRoman("4/15/2019"));
        }

        [Fact]
        public void FarFuture()
        {
            Assert.Equal("IV/XV/MMMCMXCIX", ToRoman("4/15/3999"));
        }

        [Fact]
        public void Year4000()
        {
            Assert.Equal("IV/XV/IVDXI", ToRoman("4/15/4511"));
        }

        [Fact]
        public void AroundTheHorn()
        {
            Assert.Equal("I/I/VIICDLI", ToRoman("1/1/7451"));
        }
    }
}
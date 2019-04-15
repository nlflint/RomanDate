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
        public void FirstMillenium()
        {
            Assert.Equal("I/I/I", ToRoman("1/1/0001"));

        }
    }
}
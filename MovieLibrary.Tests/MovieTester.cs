using System;
using System.IO;
using Xunit;

namespace MovieLibrary.Tests
{
    public class MovieTester
    {
        private readonly MainProgram _mp;
        public MovieTester()
        {
            _mp = new MainProgram(new String[] { "../../../../MovieLibrary/movies.ini" });
        }
        [Fact]
        public void TestGetHighestRatedMovie()
        {
            var result = _mp.GetHighestRatedMovie(_mp.movies);
            Assert.Equal("The Shawshank Redemption", result.Title);
        }
    }
}

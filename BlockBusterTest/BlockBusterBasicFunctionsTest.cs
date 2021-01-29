using BlockBuster;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlockBusterTest
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void getMovieByIdTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieById(11);
            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }
        [Fact]
        public void getAllMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 50);
        }
        [Fact]
        public void getAllCheckedOutMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }
    }
}

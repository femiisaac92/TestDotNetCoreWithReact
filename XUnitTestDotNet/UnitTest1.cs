using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Controllers;
using TestDotNetCoreWithReact.Models;
using TestDotNetCoreWithReact.Repository;
using TestDotNetCoreWithReact.Repository.DB;
using Xunit;

namespace XUnitTestDotNet
{
    public class UnitTest1
    {
        private List<MovieSearch> _moivemockSearch;
        [Fact]
        public void Test1()
        {
            // Arrange Test the API
            SearchRequest searchRequest = new SearchRequest { S = "Avengers" };
            #region Mock Data
            List<MovieSearch> mockSearch  = new List<MovieSearch>();
            mockSearch.Add(new MovieSearch { imdbID = "2828282", Poster = "jpg", Title = "Avengers Dark Age", Type = "Movies", Year = "2015" });
            mockSearch.Add(new MovieSearch { imdbID = "2828283", Poster = "jpg", Title = "Avengers [End Game]", Type = "Movies", Year = "2019" });
            _moivemockSearch = mockSearch;
            #endregion
            var mockRepo = new Mock<IMoviesRepository>();
            var mockDb = new Mock<ISearchRepository>();
            mockRepo.Setup(repo => repo.Search<MovieSearchResult>(searchRequest)).Returns(MockData);            
            var moviecontroller = new MoviesController(mockRepo.Object, mockDb.Object);
            var dd =  moviecontroller.Get(searchRequest);
            var model = Assert.IsAssignableFrom<List<MovieSearch>>(dd);
            Assert.True(model.Count > 0);
        }

        public MovieSearchResult MockData
        {
            get
            {
                return new MovieSearchResult
                {
                    Response="True",
                    Search = _moivemockSearch,
                    TotalResults = "22828"
                };
            }
        }
    }
}

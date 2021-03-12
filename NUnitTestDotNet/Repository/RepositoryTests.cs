using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDotNetCoreWithReact.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Models;
using Moq;

namespace Repository.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        [TestMethod()]
        public void Search()
        {
            SearchRequest searchRequest = new SearchRequest { S = "Avengers" };
            var mockMovies = new Mock<IMoviesRepository>();
            //var mockSearch = new Mock<TestDotNetCoreWithReact.Repository.DB.ISearchRepository>();
            var ddd = mockMovies.Setup(x => x.Search<MovieSearchResult>(searchRequest)).Returns<MovieSearchResult>(x => x);            
            Assert.IsNotNull(ddd);
        }
    }
}
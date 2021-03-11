using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Models;
using TestDotNetCoreWithReact.Repository;
using TestDotNetCoreWithReact.Repository.DB;

namespace TestDotNetCoreWithReact.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMoviesRepository MRP;
        
        public MoviesController(IMoviesRepository movies, ISearchRepository searchLog):base(searchLog)
        {
            MRP = movies;            
        }
        [HttpGet]
        public IEnumerable<MovieSearch> Get(SearchRequest Search)
        {
            var cacheData = SearchCacheRecords(Search.S);
            if (cacheData.Count() > 0)
                return cacheData;
            var data =  MRP.Search<MovieSearchResult>(Search);
            if (data.Search != null)
                LogIntoDB(Search.S,data);
            return data==null ? new List<MovieSearch>() : data.Search;
        }
        [HttpGet]
        public MovieDetails Details(SearchRequest Search)
        {
            var data = MRP.Search<MovieDetails>(Search);
            return data == null ? new MovieDetails() : data;
        }
    }
}

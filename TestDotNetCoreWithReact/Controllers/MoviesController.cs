using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Models;
using TestDotNetCoreWithReact.Repository;

namespace TestDotNetCoreWithReact.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMoviesRepository MRP; 
        public MoviesController(IMoviesRepository movies)
        {
            MRP = movies;
        }
        [HttpGet]
        public IEnumerable<MovieSearch> Get(SearchRequest Search)
        {
            var data =  MRP.Search<MovieSearchResult>(Search);
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

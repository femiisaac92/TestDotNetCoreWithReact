using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Models;
using TestDotNetCoreWithReact.Repository.DB;

namespace TestDotNetCoreWithReact.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ISearchRepository DBSRLOG;
        public BaseController(ISearchRepository search)
        {
            DBSRLOG = search;
        }
        [NonAction]
        protected void LogIntoDB(string SearchFor, MovieSearchResult result)
        {
            var search = DBSRLOG.AddEditSearch(
                new Entities.Search
                {
                    SearchFor = SearchFor,
                    Response = result.Response,
                    TotalRecords = result.TotalResults
                });
            if (search != null && result.Search.Count > 0)
                if (search.Id > 0)
                    foreach (var item in result.Search)
                           DBSRLOG.AddEditSearchResult(
                        new Entities.SearchResult { Search=search, imdbID = item.imdbID, Poster = item.Poster, Title = item.Title, Type = item.Type, Year = item.Year }
                        );
        }

        protected IEnumerable<MovieSearch> SearchCacheRecords(string search)
        {
            List<MovieSearch> list = new List<MovieSearch>();
            var data = DBSRLOG.GetSearch(search);
            if(data!=null)
            {
                var _data = DBSRLOG.GetSearchResultBySearchId(data.Id);
                foreach (var item in _data)
                    list.Add(
                        new MovieSearch { Year = item.Year, imdbID = item.imdbID, Poster = item.Poster, Title = item.Title, Type = item.Type }
                        );
                return list;
            }
            return list;
        }
    }
}


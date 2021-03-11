using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Configuration;
using TestDotNetCoreWithReact.Entities;

namespace TestDotNetCoreWithReact.Repository.DB
{
    public class SearchRepository : ISearchRepository
    {
        private readonly MovieDbContext _context;

        public SearchRepository(MovieDbContext context)
        {
            _context = context;
        }
        public Search AddEditSearch(Search search)
        {
            var data = _context.Search.Where(e => e.SearchFor.ToUpper() == search.SearchFor.ToUpper()).FirstOrDefault();
            if (data != null)
                return data;
            else
                _context.Search.Add(search);            
            _context.SaveChanges();
            return search;
        }

        public SearchResult AddEditSearchResult(SearchResult search)
        {
            var data = _context.SearchResult.Where(e => e.imdbID.ToUpper() == search.imdbID.ToUpper()).FirstOrDefault();
            if (data != null)
                return data;
            else
                _context.SearchResult.Add(search);
            _context.SaveChanges();
            return search;
        }

        public Search GetSearch(string name)
        {
            var data = _context.Search.Where(e => e.SearchFor.ToUpper() == name.ToUpper()).FirstOrDefault();
            return data;
        }

        public SearchResult GetSearchResult(string imdbID)
        {
            var data = _context.SearchResult.Where(e => e.imdbID.ToUpper() == imdbID.ToUpper()).FirstOrDefault();
            return data;
        }
        public List<SearchResult> GetSearchResultBySearchId(int Id)
        {
            var data = _context.SearchResult.Where(e=>e.Search.Id==Id).ToList();
            return data;
        }
    }
}

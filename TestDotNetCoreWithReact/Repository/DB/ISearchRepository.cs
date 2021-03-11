using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Entities;

namespace TestDotNetCoreWithReact.Repository.DB
{
    public interface ISearchRepository
    {
        public Search GetSearch(string name);
        public SearchResult GetSearchResult(string name);

        public Search AddEditSearch(Search search);
        public SearchResult AddEditSearchResult(SearchResult search);
        public List<SearchResult> GetSearchResultBySearchId(int Id);
    }
}

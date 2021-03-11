using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Models;
using RestSharp;
namespace TestDotNetCoreWithReact.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IRestClient _restClient;
        private readonly string _url;
        private readonly string _apiKey;
        public MoviesRepository(string Url,string Api)
        {
            _apiKey = Api;
            _url = Url;
        }

        public T  Search<T>(SearchRequest search)
        {
            search.ApiKey = _apiKey;
            var url = _url + search.ToQuery();
            var data = ExecuteGet<T>(url);
            return data;
        }

        private T ExecuteGet<T>(string url)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                var response = client.Execute<T>(request);
                return response.Data;
            }
            catch (Exception)
            {

                throw;
            }            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TestDotNetCoreWithReact.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }


    #region API Model
    public class MovieSearch
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
    public class MovieSearchResult
    {
        public List<MovieSearch> Search { get; set; } = new List<MovieSearch>();
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }

    public class SearchRequest
    {
        public string S { get; set; }
        public MoviesType? Type { get; set; }
        public string Y { get; set; }
        public string D { get; set; }
        public string I { get; set; }
        public string ApiKey { get; set; }

        public string ToQuery()
        {
            if (this == null) return "";
            var ddd = this.GetType().GetProperties();
            var dddWhere = ddd.Where(p => p.GetValue(this, null) != null);//Attribute.IsDefined(p, typeof(DataMemberAttribute)) &&
            return "?" + string.Join("&", dddWhere
                                       .Select(p => $"{p.Name.ToLower()}={Uri.EscapeDataString(p.GetValue(this).ToString())}"));
        }         
    }

    public enum MoviesType
    {
        Movie, Series, Episode
    }
    #endregion

    public class MovieDetails
    {
        public string Title { get; set; }
        public string Year  { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string  Writer { get; set; }

        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }

        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
        public string MyProperty { get; set; }
        public List<Ratings> Ratings { get; set; } = new List<Ratings>();
    }
    public class Ratings
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
  }

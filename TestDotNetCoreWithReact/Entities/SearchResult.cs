using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestDotNetCoreWithReact.Entities
{
    public class SearchResult
    {
        public string Title { get; set; }
        public string Year { get; set; }
        [Key]
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public Search Search { get; set; }
    }
}

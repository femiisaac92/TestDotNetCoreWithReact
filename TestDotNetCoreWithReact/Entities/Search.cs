using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestDotNetCoreWithReact.Entities
{
    public class Search
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SearchFor { get; set; }

        public string Response { get; set; }

        public string TotalRecords { get; set; }

        public List<SearchResult> searchResults { get; set; }
    }
}

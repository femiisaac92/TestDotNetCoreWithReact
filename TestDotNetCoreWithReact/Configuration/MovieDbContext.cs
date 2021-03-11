using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreWithReact.Entities;

namespace TestDotNetCoreWithReact.Configuration
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Search> Search { get; set; }
        public DbSet<SearchResult> SearchResult { get; set; }
      
       
    }
}

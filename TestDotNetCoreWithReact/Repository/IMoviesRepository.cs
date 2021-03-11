using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDotNetCoreWithReact.Repository
{
    public interface IMoviesRepository
    {
        public T Search<T>(Models.SearchRequest search);
    }
}

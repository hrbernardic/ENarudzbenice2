using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class QueryResult<T> : QueryParametersBase
    {
        public IList<T> Results { get; set; }

        public QueryResult()
        {
            Results = new List<T>();
        }
    }
}

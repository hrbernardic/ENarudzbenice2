using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class QueryResponse<T> : QueryParametersBase
    {
        public IList<T> Results { get; set; }

        public QueryResponse()
        {
            Results = new List<T>();
        }
    }
}

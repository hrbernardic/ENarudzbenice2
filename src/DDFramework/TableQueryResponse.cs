using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class TableQueryResponse<T>
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public IList<T> Results { get; set; }


        public TableQueryResponse()
        {
            Results = new List<T>();
        }
    }
}

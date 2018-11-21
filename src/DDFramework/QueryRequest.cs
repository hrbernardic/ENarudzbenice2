using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class QueryRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortProperty { get; set; }
        public string SortOrder { get; set; }
        public string GlobalFilter { get; set; }  
    }
}

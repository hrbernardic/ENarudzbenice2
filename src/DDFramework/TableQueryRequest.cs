using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class TableQueryRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; }
        public string SortProperty { get; set; }
        public string SortOrder { get; set; }
        public string GlobalFilter { get; set; }

        public TableQueryRequest(TableQueryRequest request)
        {
            if (request is null)
            {
                GlobalFilter = "";
                PageIndex = 1;
                PageSize = 10;
                PageIndex = 0;
                SortOrder = "";
                SortProperty = "";
            }
            else
            {
                GlobalFilter = request.GlobalFilter;
                PageSize = request.PageSize;
                PageIndex = request.PageIndex;
                SortOrder = request.SortOrder;
                SortProperty = request.SortProperty;
            }
        }
    }
}

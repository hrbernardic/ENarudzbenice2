﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public class QueryParametersBase
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
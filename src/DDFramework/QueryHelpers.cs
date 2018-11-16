using System;
using System.Collections.Generic;
using System.Text;

namespace DDFramework
{
    public static class QueryHelpers
    {
        public static bool IsDescending(string sortOrder)
        {
            return !string.IsNullOrEmpty(sortOrder) && sortOrder.ToLower().Equals("desc");
        }
    }
}

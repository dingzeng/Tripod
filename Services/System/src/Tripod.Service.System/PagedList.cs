using System;
using System.Collections;
using System.Collections.Generic;

namespace Tripod.Service.System
{
    public class PagedList<T> where T : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<T> List { get; set; }
    }
}
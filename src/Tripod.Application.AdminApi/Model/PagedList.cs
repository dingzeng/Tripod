using System;
using System.Collections.Generic;

namespace Tripod.Application.AdminApi.Model
{
    public class PagedList<T>
    {
        public PagedList()
        {
            
        }
        
        public PagedList(IList<T> list, int totalCount)
        {
            this.List = list;
            this.TotalCount = totalCount;
        }

        public IList<T> List { get; set; }

        public int TotalCount { get; set; }
    }
}
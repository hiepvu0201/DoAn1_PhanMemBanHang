using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string SortOrderName { get; set; }
        public string SortOrder { get; set; }

        public string SearchPropertyName { get; set; }
        public string SearchValue { get; set; }
    }
}

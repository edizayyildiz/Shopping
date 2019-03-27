using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    public interface ISearchCommand
    {
        bool IsAdvancedSearch { get; set; }
        string SortOrder { get; set; }
        string SortField { get; set; }
        bool IsPagedSearch { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}

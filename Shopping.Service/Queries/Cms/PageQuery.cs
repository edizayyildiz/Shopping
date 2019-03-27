using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class PageQuery : Query
    {

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Photo { get; set; }
        public string CustomHtml { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

    }
}

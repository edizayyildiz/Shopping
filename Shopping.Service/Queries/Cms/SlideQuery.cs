using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class SlideQuery:Query
    {
        
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string Style { get; set; }
        public string Photo { get; set; }
        public int Position { get; set; }
        public string SliderId { get; set; }
        public string SliderName { get; set; }
        public bool IsActive { get; set; }
    }
}

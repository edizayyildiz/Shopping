using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries.Commerce
{
    public class AdvertisementQuery : Query
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Html { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public string Style { get; set; }
        public string ButtonText { get; set; }
        public string Url { get; set; }

    }
}

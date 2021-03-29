using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.DataLayer.DataEntity
{
    public class SearchForRestautrant:Pagination
    {
        public LocationDetails location { get; set; }
        public AddtitionalFeatureForSearch search { get; set; }
    }
}

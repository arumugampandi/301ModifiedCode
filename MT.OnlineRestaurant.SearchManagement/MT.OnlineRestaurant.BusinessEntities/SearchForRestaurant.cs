using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessEntities
{
    public class SearchForRestaurant: Pagination
    {
        public LocationDetails location { get; set; }
        public AdditionalFeatureForSearch search { get; set; }
    }
}

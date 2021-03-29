using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessEntities
{
   public class Pagination
   {
       public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 100;

    }
}

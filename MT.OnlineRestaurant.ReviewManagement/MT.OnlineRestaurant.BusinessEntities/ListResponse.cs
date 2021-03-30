using System.Collections.Generic;

namespace MT.OnlineRestaurant.BusinessEntities
{
   public class ListResponse<T>
   {
       public int TotalRecord { get; set; }
        public List<T> Data { get; set; }
    }
}

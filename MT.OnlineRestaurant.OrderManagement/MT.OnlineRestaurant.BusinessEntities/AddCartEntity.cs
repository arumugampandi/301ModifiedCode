using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessEntities
{
   public class AddCartEntity
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public List<CartDetailEntity> CartDetails { get; set; }

        
    }
}

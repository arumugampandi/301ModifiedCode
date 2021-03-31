using System.Collections.Generic;

namespace MT.OnlineRestaurant.BusinessEntities
{
   public class CartInformation
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public IReadOnlyCollection<CartDetailEntity> CartDetails { get; set; }
    }
}

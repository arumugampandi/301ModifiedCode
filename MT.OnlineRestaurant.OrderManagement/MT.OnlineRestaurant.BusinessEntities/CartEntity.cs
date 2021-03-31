using System;

namespace MT.OnlineRestaurant.BusinessEntities
{
    public class CartEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

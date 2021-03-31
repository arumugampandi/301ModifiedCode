namespace MT.OnlineRestaurant.BusinessEntities
{
    public class CartDetailEntity
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

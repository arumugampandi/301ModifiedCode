namespace MT.OnlineRestaurant.DataLayer.Context
{
    public partial class TblCartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual TblCart TblCart { get; set; }
    }
}

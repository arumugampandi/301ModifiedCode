namespace MT.OnlineRestaurant.Models
{
    public class RestaurantLocationInfo
    {
        public int Id { get; }
        public decimal? XAxis { get; }
        public decimal? YAxis { get; }

        public RestaurantLocationInfo(int id, decimal? xAxis, decimal? yAxis)
        {
            Id = id;
            XAxis = xAxis;
            YAxis = yAxis;
        }
    }
}

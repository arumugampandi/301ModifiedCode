namespace MT.OnlineRestaurant.Models
{
    public class RestaurantRatingInfo
    {
        public int Id { get; }
        public int RestaurantId { get; }
        public double Rating { get; }


        public RestaurantRatingInfo(int id, int restaurantId, double rating)
        {
            Id = id;
            Rating = rating;
            RestaurantId = restaurantId;
        }
    }
}

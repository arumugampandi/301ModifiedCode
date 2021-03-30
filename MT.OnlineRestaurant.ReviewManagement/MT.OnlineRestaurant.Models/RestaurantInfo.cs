namespace MT.OnlineRestaurant.Models
{
    public class RestaurantInfo
    {
        public int Id { get; }
        public string Name { get; }
        public int LocationId { get; }

        public RestaurantInfo(int id,string name,int locationId)
        {
            Id = id;
            Name = name;
            LocationId = locationId;
        }
    }
}

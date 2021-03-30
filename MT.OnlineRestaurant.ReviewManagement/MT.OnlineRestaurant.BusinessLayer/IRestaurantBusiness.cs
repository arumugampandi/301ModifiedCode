using MT.OnlineRestaurant.BusinessEntities;
using System.Linq;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public interface IRestaurantBusiness
    {

        IQueryable<RestaurantRating> GetRestaurantRating(int restaurantId);
        Task<RestaurantRating> GetRestaurantRating(int id, int restaurantId, int customerId);
        void RestaurantRating(RestaurantRating restaurantRating);
        Task<bool> RestaurantRating(UpdateRestaurantRating updateRestaurantRating);
       
    }
}

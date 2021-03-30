using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using MT.OnlineRestaurant.Models;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public interface IRestaurantRatingRepository
    {
        IQueryable<TblRating> GetRestaurantRating(int restaurantId);

        Task<TblRating> GetRestaurantRating(int id, int restaurantId, int customerId);
        void RestaurantRating(TblRating tblRating);
        Task<bool> UpdateRestaurantRating(TblRating tblRating);
        
        
    }
}

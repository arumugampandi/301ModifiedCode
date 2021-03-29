using MT.OnlineRestaurant.DataLayer.DataEntity;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public interface ISearchRepository
    {
        TblRestaurant GetResturantDetails(int restaurantID);
        IQueryable<TblRating> GetRestaurantRating(int restaurantID);

        IQueryable<MenuDetails> GetRestaurantMenu(int restaurantID);

        IQueryable<TblRestaurantDetails> GetTableDetails(int restaurantID);
        IQueryable<RestaurantSearchDetails> GetRestaurantsBasedOnLocation(LocationDetails location_Details);
        IQueryable<RestaurantSearchDetails> GetRestaurantsBasedOnMenu(AddtitionalFeatureForSearch searchDetails);
        IQueryable<RestaurantSearchDetails> SearchForRestaurant(SearchForRestautrant searchDetails);

        /// <summary>
        /// Recording the customer rating the restaurants
        /// </summary>
        /// <param name="tblRating"></param>
        void RestaurantRating(TblRating tblRating);
        TblMenu ItemInStock(int restaurantID,int MenuID);

        IQueryable<RestaurantSearchDetails> ApplyPaginationInSearchRestaurant(
            IQueryable<RestaurantSearchDetails> restaurantSearchDetails, Pagination pagination);

        Task<bool> UpdateRestaurantRating(TblRating tblRating);
        Task<TblRating> GetRestaurantRating(int id, int restaurantId,int customerId);

    }
}

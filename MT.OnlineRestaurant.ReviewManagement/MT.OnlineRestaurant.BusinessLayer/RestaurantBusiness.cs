using MT.OnlineRestaurant.BusinessEntities;
using System;
using System.Collections.Generic;
using MT.OnlineRestaurant.DataLayer.Repository;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using System.Linq;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class RestaurantBusiness : IRestaurantBusiness
    {
        private readonly IRestaurantRatingRepository _restaurantRatingRepository;
        public RestaurantBusiness(IRestaurantRatingRepository restaurantRatingRepository)
        {
            _restaurantRatingRepository = restaurantRatingRepository;
        }


        public IQueryable<RestaurantRating> GetRestaurantRating(int restaurantId)
        {
            List<RestaurantRating> restaurantRatings = new List<RestaurantRating>();
            IQueryable<TblRating> rating;
            rating = _restaurantRatingRepository.GetRestaurantRating(restaurantId);
            foreach (var item in rating)
            {
                RestaurantRating ratings = new RestaurantRating
                {
                    Id = item.Id,
                    rating = item.Rating,
                    RestaurantId = item.TblRestaurantId,
                    user_Comments = item.Comments,
                    customerId = item.TblCustomerId,
                };
                restaurantRatings.Add(ratings);
            }

            return restaurantRatings.AsQueryable();
        }
        public async Task<RestaurantRating> GetRestaurantRating(int id, int restaurantId,
            int customerId)
        {
            ValidateRestaurantRatingRequest(id, restaurantId, customerId);
            var response = await _restaurantRatingRepository.GetRestaurantRating(id, restaurantId, customerId);
            if (response == null) return null;
            return new RestaurantRating
            {
                Id = response.Id,
                RestaurantId = response.TblRestaurantId,
                customerId = response.TblCustomerId,
                user_Comments = response.Comments,
                rating = response.Rating
            };
        }

        public void RestaurantRating(RestaurantRating restaurantRating)
        {
            if (restaurantRating != null)
            {
                TblRating rating = new TblRating()
                {
                    Rating = restaurantRating.rating,
                    TblRestaurantId = restaurantRating.RestaurantId,
                    Comments = restaurantRating.user_Comments,
                    TblCustomerId = restaurantRating.customerId
                };

                _restaurantRatingRepository.RestaurantRating(rating);
            }
        }

        public async Task<bool> RestaurantRating(UpdateRestaurantRating updateRestaurantRating)
        {

            if (updateRestaurantRating == null) return false;
            var getRatingDetails = await _restaurantRatingRepository.GetRestaurantRating(updateRestaurantRating.Id,
                updateRestaurantRating.RestaurantId, updateRestaurantRating.customerId);
            if (getRatingDetails == null) return false;

            var rating = new TblRating()
            {
                Rating = updateRestaurantRating.rating,
                TblRestaurantId = updateRestaurantRating.RestaurantId,
                Comments = updateRestaurantRating.user_Comments,
                TblCustomerId = updateRestaurantRating.customerId,
                Id = updateRestaurantRating.Id
            };
            return await _restaurantRatingRepository.UpdateRestaurantRating(rating);
        }

        private void ValidateRestaurantRatingRequest(int id, int restaurantId,
            int customerId)
        {
            if (id <= 0 || restaurantId <= 0 || customerId <= 0)
                throw new ArgumentException("Invalid Input");
        }
    }
}

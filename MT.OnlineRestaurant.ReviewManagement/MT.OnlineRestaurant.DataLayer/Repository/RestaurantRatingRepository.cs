using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MT.OnlineRestaurant.Models;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public class RestaurantRatingRepository : IRestaurantRatingRepository
    {
        private readonly RestaurantManagementContext _db;
        public RestaurantRatingRepository(RestaurantManagementContext connection)
        {
            _db = connection;
        }

        public IQueryable<TblRating> GetRestaurantRating(int restaurantId)
        {
            if (_db != null)
            {
                return (from rating in _db.TblRating
                        join restaurant in _db.TblRestaurant on
                            rating.TblRestaurantId equals restaurant.Id
                        where rating.TblRestaurantId == restaurantId
                        select new TblRating
                        {
                            Rating = rating.Rating,
                            Comments = rating.Comments,
                            TblRestaurant = restaurant,
                        }).AsQueryable();
            }
            return Enumerable.Empty<TblRating>().AsQueryable();
        }
        public async Task<TblRating> GetRestaurantRating(int id, int restaurantId, int customerId)
        {
            var ratingEntity = await _db.TblRating.FirstOrDefaultAsync(x => x.Id == id && x.TblRestaurantId == restaurantId && x.TblCustomerId == customerId);
            return ratingEntity;
        }

        public void RestaurantRating(TblRating tblRating)
        {
            tblRating.RecordTimeStampCreated = DateTime.Now;
            _db.Set<TblRating>().Add(tblRating);
            _db.SaveChanges();
        }

       

        public async Task<bool> UpdateRestaurantRating(TblRating tblRating)
        {
            var ratingValue = _db.TblRating.FirstOrDefault(x => x.Id == tblRating.Id);

            if (ratingValue != null)
            {
                ratingValue.Comments = tblRating.Comments ?? default;
                ratingValue.Rating = tblRating.Rating;
                ratingValue.RecordTimeStamp = DateTime.Now;
                _db.Set<TblRating>().Update(ratingValue);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;

        }
    }
}

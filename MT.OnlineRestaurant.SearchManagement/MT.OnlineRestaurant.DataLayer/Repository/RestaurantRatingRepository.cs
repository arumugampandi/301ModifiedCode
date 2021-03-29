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

        public async Task<IReadOnlyCollection<RestaurantRatingInfo>> GetRestaurantRating()
        {
            var averageCalculateResponse = await (from row in _db.TblRating
                                                  group row by row.TblRestaurantId into rows
                                                  select new
                                                  {
                                                      Id = rows.Key,
                                                      AverageScore = rows.Average(row => Convert.ToDouble(row.Rating)),
                                                      RestaurantId = rows.FirstOrDefault().TblRestaurantId
                                                  }).ToListAsync();

            return averageCalculateResponse.Select(x => new RestaurantRatingInfo(x.Id, x.RestaurantId, x.AverageScore)).ToList();
        }

        public async Task<IReadOnlyCollection<RestaurantRatingInfo>> GetRestaurantRating(int restaurantId)
        {
            var averageCalculateResponse = await (from row in _db.TblRating 
                where row.TblRestaurantId == restaurantId 
                group row by row.TblRestaurantId into rows
                                                 
               select new
                {
                    Id = rows.Key,
                    AverageScore = rows.Average(row => Convert.ToDouble(row.Rating)),
                    RestaurantId = rows.FirstOrDefault().TblRestaurantId
                }).ToListAsync();

            return averageCalculateResponse.Select(x => new RestaurantRatingInfo(x.Id, x.RestaurantId, x.AverageScore)).ToList();
        }
    }
}

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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantManagementContext _db;
        public RestaurantRepository(RestaurantManagementContext connection)
        {
            _db = connection;
        }

        public async Task<IReadOnlyCollection<RestaurantInfo>> GetRestaurantByName(string name)
        {
            var restaurantFilter = string.IsNullOrWhiteSpace(name) ? _db.TblRestaurant.Where(x => x.Name.Contains(name)) : _db.TblRestaurant.Select(x => x);
            return await (restaurantFilter.Select(x => new RestaurantInfo(x.Id, x.Name, x.TblLocationId))).ToListAsync();
        }
    }
}

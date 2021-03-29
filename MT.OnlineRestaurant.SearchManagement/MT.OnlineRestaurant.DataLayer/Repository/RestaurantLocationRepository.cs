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
    public class RestaurantLocationRepository : IRestaurantLocationRepository
    {
        private readonly RestaurantManagementContext _db;
        public RestaurantLocationRepository(RestaurantManagementContext connection)
        {
            _db = connection;
        }

        public async Task<IReadOnlyCollection<RestaurantLocationInfo>> GetRestaurantLocation()
        {
            var locationResponse =_db.TblLocation.Select(x => x);
            return await (locationResponse.Select(x => new RestaurantLocationInfo(x.Id, x.X, x.Y))).ToListAsync();
        }
    }
}

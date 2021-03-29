using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MT.OnlineRestaurant.Models;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<RestaurantInfo>> GetRestaurantByName(string name);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MT.OnlineRestaurant.DataLayer.Context;

namespace MT.OnlineRestaurant.DataLayer.interfaces
{
    public interface ICartRepository
    {
        Task<IReadOnlyCollection<TblCartDetail>> GetCartDetails(int cartId);
        Task<TblCart> GetCart(int cartId);
        Task<TblCart> GetCartExistForCustomer(int customerId);

        Task<bool> AddCartDetails(List<TblCartDetail> tblCartDetails);
        Task<int> AddCart(TblCart tblCart);

        Task UpdateCartDetails();
        Task DeleteCartDetails();
    }
}

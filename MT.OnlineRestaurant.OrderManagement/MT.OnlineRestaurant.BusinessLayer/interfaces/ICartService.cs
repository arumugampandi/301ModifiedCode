using System.Threading.Tasks;
using MT.OnlineRestaurant.BusinessEntities;

namespace MT.OnlineRestaurant.BusinessLayer.interfaces
{
    public interface ICartService
    {
        Task<bool> AddCartInfo(AddCartEntity addCartDetails);
     
        Task DeleteCartDetails(int cartId);

        Task<CartInformation> GetCartDetails(int customerId);
    }
}

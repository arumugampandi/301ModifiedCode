using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer.interfaces;
using MT.OnlineRestaurant.DataLayer.Context;
using MT.OnlineRestaurant.DataLayer.interfaces;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddCartInfo(AddCartEntity addCartDetails)
        {
            var cartExist = await _cartRepository.GetCartExistForCustomer(addCartDetails.CustomerId);
            int cartId;
            if (cartExist == null)
            {
                cartId = await AddCart(new CartEntity()
                { RestaurantId = addCartDetails.RestaurantId, CustomerId = addCartDetails.CustomerId });
            }
            else
            {
                cartId = cartExist.Id;
            }
            await DeleteCartDetails(cartId);
            await AddCartDetails(addCartDetails.CartDetails,cartId);
            return true;
        }



        private async Task<bool> AddCartDetails(IEnumerable<CartDetailEntity> cartDetailEntities,int cartId)
        {
            var tblCartDetails = cartDetailEntities.Select(x => new TblCartDetail
            {
                CartId = cartId,
                ItemId = x.ItemId,
                ItemName = x.ItemName,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
            return await _cartRepository.AddCartDetails(tblCartDetails);

        }

        private async Task<int> AddCart(CartEntity cartEntity)
        {
            var tblCart = new TblCart()
            {
                RestaurantId = cartEntity.RestaurantId,
                CustomerId = cartEntity.CustomerId,
                CreateOn = DateTime.Now
            };
            return await _cartRepository.AddCart(tblCart);
        }


        public async Task DeleteCartDetails(int cartId)
        {
            await _cartRepository.DeleteCartDetails(cartId);
        }

        public async Task<CartInformation> GetCartDetails(int customerId)
        {
            var cart = await _cartRepository.GetCartExistForCustomer(customerId);
            var cartDetails = await _cartRepository.GetCartDetails(cart.Id);
            var response = new CartInformation()
            {
                CartId = cart.Id,
                RestaurantId = cart.RestaurantId,
                CustomerId = cart.CustomerId,
                CartDetails = cartDetails.Select(x => new CartDetailEntity()
                {
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()
            };
            return response;
        }


    }
}

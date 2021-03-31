using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MT.OnlineRestaurant.DataLayer.Context;
using MT.OnlineRestaurant.DataLayer.interfaces;

namespace MT.OnlineRestaurant.DataLayer
{
   public class CartRepository : ICartRepository
    {
        private readonly OrderManagementContext _context;

        public CartRepository(OrderManagementContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCartDetails(List<TblCartDetail> tblCartDetails)
        {
            await _context.TblCartDetails.AddRangeAsync(tblCartDetails);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<int> AddCart(TblCart tblCart)
        {
            await _context.TblCarts.AddAsync(tblCart);
            await _context.SaveChangesAsync();
            return tblCart.Id;
        }


        public async Task<IReadOnlyCollection<TblCartDetail>> GetCartDetails(int cartId)
        {
            var response = await _context.TblCartDetails.Where(x => x.CartId == cartId).ToListAsync();
            return response;
        }

        public async Task<TblCart> GetCart(int cartId)
        {
            var response = await _context.TblCarts.FirstOrDefaultAsync(x => x.Id == cartId);
            return response;
        }

        public async Task<TblCart> GetCartExistForCustomer(int customerId)
        {
            var response = await _context.TblCarts.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return response;
        }

        public async Task<bool> UpdateCartDetails(List<TblCartDetail> tblCartDetails)
        {
            _context.Set<TblCartDetail>().UpdateRange(tblCartDetails);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteCartDetails(int cartId)
        {
            var cartDetails = await _context.TblCartDetails.Where(x => x.CartId == cartId).ToListAsync();
            _context.Set<TblCartDetail>().RemoveRange(cartDetails);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            var cartDetail = await _context.TblCarts.Where(x => x.Id == cartId).ToListAsync();
            _context.Set<TblCart>().RemoveRange(cartDetail);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}

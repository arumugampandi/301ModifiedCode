using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MT.OnlineRestaurant.DataLayer.Context;
using MT.OnlineRestaurant.DataLayer.interfaces;

namespace MT.OnlineRestaurant.DataLayer
{
    class CartRepository : ICartRepository
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

        public Task DeleteCartDetails()
        {
            throw new NotImplementedException();
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

        public Task UpdateCartDetails()
        {
            throw new NotImplementedException();
        }
    }
}

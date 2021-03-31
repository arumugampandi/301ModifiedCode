using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer.interfaces;

namespace MT.OnlineRestaurant.OrderAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartService"></param>
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCartEntity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/AddCartDetails")]
        public async Task<IActionResult> Post([FromBody] AddCartEntity addCartEntity)
        {
            var response = await _cartService.AddCartInfo(addCartEntity);
            if (response)
                return Ok("Successfully Added");
            return BadRequest("Failure in adding");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CartDetails")]
        public async Task<IActionResult> GetCartDetails(int customerId)
        {
            var response = await _cartService.GetCartDetails(customerId);
            if (response != null)
                return Ok(response);
            return BadRequest("Not Available");
        }
    }
}
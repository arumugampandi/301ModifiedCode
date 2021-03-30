using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;


namespace MT.OnlineRestaurant.ReviewManagement.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ReviewController : Controller
    {
        private readonly IRestaurantBusiness _businessRepo;
        public ReviewController(IRestaurantBusiness businessRepo)
        {
            _businessRepo = businessRepo;
        }
        

        [HttpGet]
        [Route("RestaurantRating")]
        public IActionResult GetRestaurantRating([FromQuery] int restaurantId)
        {
            var restaurantRatings = _businessRepo.GetRestaurantRating(restaurantId);
            return restaurantRatings != null ? this.Ok(restaurantRatings) : this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

        [HttpPost]
        [Route("RestaurantRating")]
        public IActionResult RestaurantRating([FromQuery] RestaurantRating restaurantRating)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            _businessRepo.RestaurantRating(restaurantRating);

            return this.Ok("Submitted the reviews");
        }

        [HttpPut]
        [Route("RestaurantRating")]
        public async Task<IActionResult> PutRestaurantRating([FromQuery] UpdateRestaurantRating updateRestaurantRating)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var response = await _businessRepo.RestaurantRating(updateRestaurantRating);
            if (!response)
                return BadRequest("No reviews are found.");
            return this.Ok("Submitted the reviews");
        }

        [HttpGet]
        [Route("RestaurantRatings")]
        public async Task<IActionResult> RestaurantRatings(int id, int restaurantId, int customerId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var response = await _businessRepo.GetRestaurantRating(id, restaurantId, customerId);
            if (response == null)
                return BadRequest("No reviews are found.");
            return this.Ok(response);
        }
    }
}
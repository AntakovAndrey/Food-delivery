using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrostructure;
using WebAPI.Infrostructure.Entities;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : Controller
	{
		[HttpGet(Name = "GetAllRestaurants")]
		public IEnumerable<Restaurant> GetAll()
		{
			List<Restaurant> restaurants;
			using(ApplicationContext db = new ApplicationContext()) 
			{
				restaurants = db.Restaurants.ToList();
			}
			return restaurants;
		}

	}
}

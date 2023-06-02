using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrostructure;
using WebAPI.Infrostructure.Entities;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantCategoryController : Controller
	{
		[HttpGet(Name = "GetAllRestaurantCategories")]
		public IEnumerable<RestaurantCategory> GetAll()
		{
			List<RestaurantCategory> categories;
			using(ApplicationContext db = new())
			{
				categories = db.RestaurantCategories.ToList();
			}
			return categories;
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : Controller
	{
		[HttpGet(Name = "GetAllCarts")]
		public IEnumerable<Restaurant> GetAll()
		{
			List<Restaurant> restaurants;
			using(ApplicationContext db = new ApplicationContext()) 
			{
				restaurants = db.Restaurants.Include(r=>r.Category).ToList();
			}
			return restaurants;
		}

		[HttpGet]
		[Route("/[controller]/[action]/{id}")]
		public Restaurant GetById(int id)
	{
			Restaurant restaurant;
			using (ApplicationContext db = new ApplicationContext())
			{
				restaurant = db.Restaurants.Include(r=>r.Category).First(r => r.Id == id);
			}
			return restaurant;
		}

		[HttpGet]
		[Route("/[controller]/[action]/{categoryId}")]
		public IEnumerable<Restaurant> GetByCategoryId(int categoryId)
		{
			List<Restaurant> restaurants;
			using (ApplicationContext db = new ())
			{
				restaurants = db.Restaurants.Include(r => r.Category).Where(r=>r.CategoryId==categoryId).ToList();
			}
			return restaurants;
		}

		[HttpGet]
		[Route("/[controller]/[action]/{id}")]
		public IEnumerable<Dish> GetDishesByRestaurantId(int id)
		{
            List<Dish> dishes=new List<Dish>();
            using (ApplicationContext db = new ())
            {
				dishes =  db.Dishes.Where(d=>d.Restaurant.Id==id).ToList();
            }
            return dishes;
        }

        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public IEnumerable<DishCategory> GetDishCategoriesByRestaurantId(int id)
        {
            List<DishCategory> dishCategories = new List<DishCategory>();
            using (ApplicationContext db = new())
            {
                dishCategories = db.Dishes.Where(d=>d.Restaurant.Id == id).Select(d=>d.Category).Distinct().ToList();
            }
            return dishCategories;
        }

        [HttpPost(Name ="AddRestaurant")]
		public IActionResult AddRestaurant(Restaurant restaurant)
		{
			try
			{
				using (ApplicationContext db = new())
				{
					db.Restaurants.Add(restaurant);
					db.SaveChanges();
				}
				return Ok();
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
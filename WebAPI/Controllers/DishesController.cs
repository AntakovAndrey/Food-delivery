using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DishesController : Controller
	{
		[HttpGet]
		public IEnumerable<Dish> GetAll()
		{
			List<Dish> dishes;
			using(ApplicationContext db = new())
			{
				dishes = db.Dishes.ToList();
			}
			return dishes;
		}

        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public Dish GetById(int id)
        {
			Dish dish;
            using (ApplicationContext db = new())
            {
                dish = db.Dishes.Where(d=>d.Id==id).First();
            }
            return dish;
        }
        [HttpGet]
        [Route("/[controller]/[action]/{categoryId}")]
        public List<Dish> GetByCategoryId(int categoryId)
        {
            List<Dish> dishes;
            using (ApplicationContext db = new())
            {
                dishes = db.Dishes.Where(d => d.Category.Id==categoryId).ToList();
            }
            return dishes;
        }
    }
}

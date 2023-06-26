using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        [HttpGet(Name = "GetAllRestaurants")]
        public IEnumerable<Cart> GetAll()
        {
            List<Cart> carts;
            using(ApplicationContext db = new())
            {
                carts = db.Carts.ToList();
            }
            return carts;
        }

        [HttpPost("AddItemToCart")]
        public IActionResult AddDishToCart(int cartId, int dishId)
        {
            try
            {
                using (ApplicationContext db = new()) 
                {
                    Cart cart = db.Carts.FirstOrDefault(c=>c.Id == cartId);
                    Dish dish = db.Dishes.Where(d => d.Id == dishId).FirstOrDefault();
                    db.CartDishes.Add(new CartDishes { Cart = cart,DishId = dish.Id });
                    db.CartDishes.Where(c => c.Cart.Id == cartId).FirstOrDefault().DishId = dish.Id;
                    db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return Ok(cartId);
        }

        

    }
}
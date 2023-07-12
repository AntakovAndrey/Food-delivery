using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Entities;
using WebAPI.Models;

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

        [HttpPost]
        [Route("AddDishToCart")]
        public IActionResult AddDishToCart([FromBody]AddDishToCartModel addDishToCartModel)
        {
            try
            {
                using (ApplicationContext db = new()) 
                {
                    db.CartDishes.Add(new CartDishes { CartId =addDishToCartModel.CartId,Dish = db.Dishes.First(d=>d.Id== addDishToCartModel.DishId) });
                    
                    int restaurantId = db.Dishes.Include(d => d.Restaurant).First(d => d.Id == addDishToCartModel.DishId).Restaurant.Id;
                    Cart c = db.Carts.First(c => c.Id == addDishToCartModel.CartId);
                    c.RestaurantId = restaurantId;
                    db.Carts.Update(c);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return Ok(addDishToCartModel.CartId);
        }

        [HttpDelete]
        [Route("RemoveDishFromCart")]
        public IActionResult RemoveDishFromCart([FromBody]AddDishToCartModel deleteDishFromCartModel)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.CartDishes.Remove(db.CartDishes.First(cd => cd.CartId == deleteDishFromCartModel.CartId && cd.DishId == deleteDishFromCartModel.DishId));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Removed");
        }

        [HttpDelete]
        [Route("/[controller]/[action]/{cartDishId}")]
        public IActionResult RemoveDishFromCart(int cartDishId)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.CartDishes.Remove(db.CartDishes.First(dc => dc.Id == cartDishId));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Removed");
        }

        [HttpGet]
        [Route("/[controller]/[action]/{cartId}")]  
        public IActionResult GetCartDishesByCartId(int cartId) 
        {
            try
            {
                List<CartDishes> cartDishes;
                using (ApplicationContext db = new())
                {
                    cartDishes = db.CartDishes.Include(cd => cd.Dish).Where(cd => cd.CartId == cartId).ToList();
                }
                return Json(cartDishes);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
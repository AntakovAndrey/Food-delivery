using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Entities;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpPost("ApplyOrder")]
        public IActionResult ApplyOrder(int orderId, int deliverymanId)
        {
            try
            {
                using(ApplicationContext db = new())
                {
                    db.Orders.First(o => o.Id == orderId).Deliveryman = db.Users.First(u => u.Id == deliverymanId);
                    db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex) 
            { return BadRequest(ex.Message); }
        }
        
        [HttpPost("CreateOrder")]
        public Order CreateOrder(int userId, string address)
        {
            Order order = new Order();
            order.Address = address;

            using (ApplicationContext db = new())
            {
                order.Customer = db.Users.First(u => u.Id == userId);
                db.Orders.Add(order);
                db.SaveChanges();
            }
            return order;
        }

        [HttpPost("AddDishesToOrder")]
        public IActionResult AddDishesToOreder(int orderId, int cartId, int userId)
        {
            try
            {
                List<OrderDishes> orderDishes = new List<OrderDishes>();
                using (ApplicationContext db = new())
                {
                    foreach (var dish in db.CartDishes.Where(c => c.Cart.Id == cartId))
                    {
                        orderDishes.Add(new OrderDishes { DishId = dish.DishId, OrderId = orderId, User = db.Users.First(u => u.Id == userId) });
                    }
                    db.OrderDishes.AddRange(orderDishes);
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

using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Entities;
using WebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Infrastructure.Enums;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("/[controller]/[action]")]
        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            using(ApplicationContext db = new ApplicationContext()) 
            {
                orders = db.Orders.ToList();
            }
            return orders;
        }
        [HttpGet]
        [Route("/[controller]/[action]/{userId}")]
        public List<Order> GetAllByUserId(int userId)
        {
            List<Order> orders = new List<Order>();
            using (ApplicationContext db = new ApplicationContext())
            {
                orders = db.Orders.Include(o=>o.Restaurant).Where(o=>o.CustomerId==userId).ToList();
            }
            return orders;
        }
        [HttpGet]
        [Route("/[controller]/[action]/{userId}")]
        public List<Order> GetActualByUserId(int userId)
        {
            List<Order> orders = new List<Order>();
            using (ApplicationContext db = new ApplicationContext())
            {
                orders = db.Orders.Include(o=>o.Restaurant).Where(o => o.CustomerId == userId&&o.OrderStatus!=OrderStatus.delivered).ToList();
            }
            return orders;
        }
        [HttpGet]
        [Route("/[controller]/[action]/{restaurantId}")]
        public List<Order> GetAllByRestaurantId(int restaurantId)
        {
            List<Order> orders = new List<Order>();
            using (ApplicationContext db = new ApplicationContext())
            {
                orders = db.Orders.Where(o => o.RestaurantId == restaurantId).ToList();
            }
            return orders;
        }
        [HttpGet]
        [Route("/[controller]/[action]/{restaurantId}")]
        public List<Order> GetActualByRestauarntId(int restaurantId)
        {
            List<Order> orders = new List<Order>();
            using (ApplicationContext db = new ApplicationContext())
            {
                orders = db.Orders.Where(o => o.RestaurantId == restaurantId).ToList();
            }
            return orders;
        }

        [HttpPost("ApplyOrderToDeliver")]
        public IActionResult ApplyOrderToDeliver([FromBody] ApplyOrderToDeliver applyOrder)
        {
            try
            {
                using(ApplicationContext db = new())
                {
                    db.Orders.First(o => o.Id == applyOrder.OrderId).Deliveryman = db.Users.First(u => u.Id == applyOrder.DeliverymanId);
                    db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex) 
            { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("/[controller]/[action]/{orderId}")]
        public List<OrderDishes> GetOrderDishes(int orderId) 
        {
            List<OrderDishes> orderDishes = new List<OrderDishes>();
            using(ApplicationContext db =new ApplicationContext()) 
            {
                orderDishes = db.OrderDishes.Include(od=>od.Dish).Where(od=>od.OrderId==orderId).ToList();
            }
            return orderDishes;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public List<Order> GetAllUndeliveredOrders()
        {
            List<Order> orders;
            using (ApplicationContext db = new())
            {
                orders = db.Orders.Where(o=>o.DeliverymanId==null&& o.OrderStatus !=OrderStatus.delivering && o.OrderStatus != OrderStatus.delivered).ToList();
            }
            return orders;
        }

        [HttpGet]
        [Route("/[controller]/[action]/{orderId}")]
        public IActionResult SetOrderCooking(int orderId)
        {
            using(ApplicationContext db = new())
            {
                Order order = db.Orders.First(o=>o.Id==orderId);
                order.OrderStatus = OrderStatus.cooking;
                db.Orders.Update(order);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpGet]
        [Route("/[controller]/[action]/{orderId}")]
        public IActionResult SetOrderCooked(int orderId)
        {
            using (ApplicationContext db = new())
            {
                Order order = db.Orders.First(o => o.Id == orderId);
                order.OrderStatus = OrderStatus.cooked;
                db.Orders.Update(order);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpGet]
        [Route("/[controller]/[action]/{orderId}")]
        public IActionResult SetOrderDelivering(int orderId)
        {
            using (ApplicationContext db = new())
            {
                Order order = db.Orders.First(o => o.Id == orderId);
                order.OrderStatus = OrderStatus.delivering;
                db.Orders.Update(order);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpGet]
        [Route("/[controller]/[action]/{orderId}")]
        public IActionResult SetOrderDelivered(int orderId)
        {
            using (ApplicationContext db = new())
            {
                Order order = db.Orders.First(o => o.Id == orderId);
                order.OrderStatus = OrderStatus.delivered;
                db.Orders.Update(order);
                db.SaveChanges();
            }
            return Ok();
        }


        [HttpGet]
        [Route("/[controller]/[action]")]
        public List<OrderDishes> GetAllOrderDishes()
        {
            List<OrderDishes> orderDishes = new List<OrderDishes>();
            using (ApplicationContext db = new ApplicationContext())
            {
                orderDishes = db.OrderDishes.Include(o=>o.Dish).ToList();
            }
            return orderDishes;
        }

        [HttpPost("CreateOrder")]
        public Order CreateOrder([FromBody] AddOrderModel addOrderModel)
        {
            
            Order order = new Order { Address = addOrderModel.Address, CustomerId = addOrderModel.UserID,DateTimeCreated=DateTime.Now,OrderStatus=OrderStatus.applied};
            using (ApplicationContext db = new())
            {
                int cartId = db.Carts.First(c => c.UserId == order.CustomerId).Id;
                int restaurantId =(int)db.Carts.First(c => c.Id == cartId).RestaurantId;
                order.RestaurantId = restaurantId;
                db.Orders.Add(order);
                db.SaveChanges();
                order = db.Orders.First(o=>o.DateTimeCreated==order.DateTimeCreated&&o.CustomerId==addOrderModel.UserID);
                double sum = 0;
                foreach (var dish in db.CartDishes.Include(d=>d.Dish).Where(cd => cd.CartId == cartId))
                {
                    db.OrderDishes.Add(new OrderDishes { OrderId = order.Id, DishId = dish.Id });
                    sum += dish.Dish.Price;   
                }
                db.SaveChanges();
                order.TotalPrice=sum;
                db.Orders.Update(order);
                db.CartDishes.RemoveRange(db.CartDishes.Where(cd => cd.CartId == cartId));
                db.SaveChanges();
                
            }
            return order;
        }

        


    }
}

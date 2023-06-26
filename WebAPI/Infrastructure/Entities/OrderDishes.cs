namespace WebAPI.Infrastructure.Entities
{
    public class OrderDishes
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get;set; }
    }
}

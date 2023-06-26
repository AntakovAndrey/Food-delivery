namespace WebAPI.Infrastructure.Entities
{
    public class CartDishes
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public int DishId { get; set; }
    }
}
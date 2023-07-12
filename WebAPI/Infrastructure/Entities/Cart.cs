namespace WebAPI.Infrastructure.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int? RestaurantId { get; set; }
    }
}
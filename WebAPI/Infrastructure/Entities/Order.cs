using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Infrastructure.Enums;

namespace WebAPI.Infrastructure.Entities
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		[ForeignKey("CustomerId")]
		public User Customer { get; set; }
		public int CustomerId { get; set; }
		public Restaurant? Restaurant { get; set; }
		public int? RestaurantId { get; set; }
		public User? Deliveryman { get; set; }
        public int? DeliverymanId { get; set; }
        [Required]
		public DateTime DateTimeCreated { get; set; }
		public string Address { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public double? TotalPrice { get; set; }
	}
}
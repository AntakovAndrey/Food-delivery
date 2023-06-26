using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Entities
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		[ForeignKey("CustomerId")]
		public User Customer { get; set; }
		[ForeignKey("DeliveryManId")]
		public User? Deliveryman { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public double TotalPrice { get; set; }
	}
}
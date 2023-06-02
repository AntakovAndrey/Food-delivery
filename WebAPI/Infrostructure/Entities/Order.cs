using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrostructure.Entities
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		public User? Customer { get; set; }
		[Required]
		public User? Deliveryman { get; set; }
		[Required]
		public string? Address { get; set; }
		[Required]
		public double TotalPrice { get; set; }
	}
}
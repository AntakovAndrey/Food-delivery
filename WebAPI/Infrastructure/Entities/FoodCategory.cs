using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrastructure.Entities
{
	public class DishCategory
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		public List<Dish> Dishes { get; set; }
	}
}

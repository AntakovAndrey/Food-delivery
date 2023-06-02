using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrostructure.Entities
{
	public class FoodCategory
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
	}
}

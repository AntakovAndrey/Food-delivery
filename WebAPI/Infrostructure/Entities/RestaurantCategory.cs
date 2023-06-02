using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrostructure.Entities
{
	public class RestaurantCategory
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		//public List<Restaurant> Restaurants { get; set; }
	}
}
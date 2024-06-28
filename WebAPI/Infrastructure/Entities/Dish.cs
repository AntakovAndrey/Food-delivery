namespace WebAPI.Infrastructure.Entities
{
	public class Dish
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public string PhotoURL { get;set; }
		public int Weight { get; set; }
		public int CategoryId { get; set; }
		public DishCategory Category { get; set; }
		public Restaurant Restaurant { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrastructure.Entities
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		public Role? Role { get; set; }
	}
}

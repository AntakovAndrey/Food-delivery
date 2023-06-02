using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrostructure.Entities
{
    public class Restaurant
    {
        public int Id {get;set;}
        [Required]
        public string? Name {get;set;}
        [Required]
        public double Rating {get;set;}
        [Required]
        public string? PhotoURL { get;set;}
        public int CategoryId { get;set;}
		[Required]
		public RestaurantCategory Category { get;set;}
    }
}